<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">
          {{ MISAResource[globalStore.lang]?.Page?.Department?.Title }}
        </h1>
        <MISAIcon icon="angle-down" />
      </div>

      <div class="page__header-controls">
        <MISAButton v-tippy="{ content: 'Ctrl + 1' }" type="primary">{{
          MISAResource[globalStore.lang]?.Page?.Department?.AddButton
        }}</MISAButton>
      </div>
    </div>

    <div class="page__content">
      <div class="filter-container">
        <div class="filter__left">
          <div :class="['filter__select-infor', { '--active': selectedRowsState.length > 0 }]">
            <div>
              {{ MISAResource[globalStore.lang]?.Text?.Selected }}
              <span id="selected-count" class="text-bold">{{ selectedRowsState.length }}</span>
            </div>
            <MISAButton @click="uncheckedAllRows()" type="link" class="ms-16">{{
              MISAResource[globalStore.lang]?.Button?.UnChecked
            }}</MISAButton>
            <MISAButton
              v-tippy="{ content: 'Ctrl + D' }"
              @click="
                showDeleteConfirmDialog(
                  MISAResource[globalStore.lang]?.Page?.Department?.Dialog
                    ?.MultipleDeleteConfirmDesc
                )
              "
              type="danger"
              class="ms-24"
              >{{ MISAResource[globalStore.lang]?.Button?.Delete }}</MISAButton
            >
          </div>
        </div>
        <div class="filter__right">
          <MISAInputGroup for="search-input">
            <MISAInput
              @keydown.enter="handleSearchEmployee"
              v-model="searchFieldState"
              :placeholder="MISAResource[globalStore.lang]?.Page?.Department?.SearchPlaceholder"
              id="search-input"
            />
            <MISAInputAction @click="handleSearchEmployee">
              <MISAIcon size="20" icon="search" />
            </MISAInputAction>
          </MISAInputGroup>

          <MISAButton
            @click="handleResetFilter"
            v-tippy="{ content: MISAResource[globalStore.lang]?.Tooltip?.Reload }"
            type="secondary"
          >
            <template #icon><MISAIcon size="20" icon="reload" /></template>
          </MISAButton>

          <MISAButton
            v-tippy="{ content: MISAResource[globalStore.lang]?.Tooltip?.Setting }"
            @click.stop="isCustomizeTable = true"
            type="secondary"
          >
            <template #icon><MISAIcon icon="setting" /></template>
          </MISAButton>
        </div>
      </div>

      <!-- table -->
      <MISATable
        @select-row="selectTableRows"
        @active-row="setActiveRow"
        @double-click="employeeStore.openFormForUpdate"
        :columns="columns"
        :data-source="departmentData"
        :selected-rows="selectedRowsState"
        :active-row="activeRowState"
        :loading="loading.table"
      >
        <template #context-menu>
          <MISAContextMenu width="180" small>
            <MISAContextItem @click="employeeStore.openFormForDuplicate(activeRowState)">{{
              MISAResource[globalStore.lang]?.ContextMenu?.Duplicate
            }}</MISAContextItem>
            <MISAContextItem
              @click="
                showDeleteConfirmDialog(
                  MISAResource[
                    globalStore.lang
                  ]?.Page?.Department?.Dialog?.DeleteConfirmDesc?.replace(
                    '@code',
                    activeRowState.DepartmentCode
                  )
                )
              "
              >{{ MISAResource[globalStore.lang]?.ContextMenu?.Delete }}</MISAContextItem
            >
            <MISAContextItem>{{
              MISAResource[globalStore.lang]?.ContextMenu?.StopUsing
            }}</MISAContextItem>
          </MISAContextMenu>
        </template>

        <template #footer>
          <MISATableFooter
            @next-page="handleNextPage"
            @prev-page="handlePrevPage"
            @select-page-size="handleChangePageSize"
            :total-page="pagingInfoState.totalPage"
            :total-records="pagingInfoState.totalRecords"
            :current-page="filterParamsState.page"
            :page-size="filterParamsState.pageSize"
          />
        </template>
      </MISATable>

      <!-- Dialog xác nhận xoá -->
      <Teleport to="#app">
        <MISADialog v-if="dialogState.active" v-bind="dialogState" @cancel="hideConfirmDialog">
          <template #right-controls>
            <MISAButton tabindex="2" @click="hideConfirmDialog" type="secondary">{{
              MISAResource[globalStore.lang]?.Button?.Cancel
            }}</MISAButton>
            <MISAButton auto-focus tabindex="1" @click="handleDeleteDepartment" type="danger">{{
              MISAResource[globalStore.lang]?.Button?.Delete
            }}</MISAButton>
          </template>
        </MISADialog>
      </Teleport>

      <!-- Table customize -->
      <MISATableCusomize
        :columns="columns"
        :default-columns="defaultColumns"
        @change="applyTableCustomize"
        @close="isCustomizeTable = false"
        v-if="isCustomizeTable"
      />
    </div>
  </div>
</template>

<script setup>
import { onMounted, onUnmounted, ref, watch } from "vue";

import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISAInput from "@/components/base/input/MISAInput.vue";
import MISAInputGroup from "@/components/base/input/MISAInputGroup.vue";
import MISAInputAction from "@/components/base/input/MISAInputAction.vue";
import MISATable from "@/components/base/table/MISATable.vue";
import MISATableFooter from "@/components/base/table/MISATableFooter.vue";
import MISATableCusomize from "@/components/base/table-customize/MISATableCustomize.vue";
import MISAContextMenu from "@/components/base/context-menu/MISAContextMenu.vue";
import MISAContextItem from "@/components/base/context-menu/MISAContextItem.vue";
import MISADialog from "@/components/base/dialog/MISADialog.vue";
import departmentApi from "@/api/department-api";
import enums from "@/helper/enum";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "@/stores/global-store";
import { useEmployeeStore } from "@/stores/employee-store";
import { useToastStore } from "@/stores/toast-store";

// ---- Store ----
const globalStore = useGlobalStore();
const employeeStore = useEmployeeStore();
const toastStore = useToastStore();

// ---- Data & Paging & Filter ----
const departmentData = ref([]);
const searchFieldState = ref("");
const filterParamsState = ref({
  page: 1,
  pageSize: 25,
  search: "",
});
const pagingInfoState = ref({
  totalPage: 0,
  totalRecords: 0,
});

// ---- Selected records ----
const selectedRowsState = ref([]);
const activeRowState = ref(null);

// ---- Dialog ----
const dialogState = ref({
  active: false,
  type: "warning",
  title: "",
  description: "",
});

// ---- Other ----
const loading = ref({
  table: false,
  excel: false,
});
const isCustomizeTable = ref(false);

const defaultColumns = [
  {
    key: 1,
    title: MISAResource[globalStore.lang]?.Page?.Department?.DepartmentCode?.SubTitle,
    dataIndex: "DepartmentCode",
    originName: "DepartmentCode",
    width: 150,
    sticky: "left",
  },
  {
    key: 2,
    title: MISAResource[globalStore.lang]?.Page?.Department?.DepartmentName?.SubTitle,
    dataIndex: "DepartmentName",
    originName: "DepartmentName",
    width: 260,
  },
  {
    key: 3,
    title: MISAResource[globalStore.lang]?.Page?.Department?.Description?.SubTitle,
    dataIndex: "Description",
    originName: "Description",
    width: 800,
  },
];
const columns = ref([]);

/**
 * Description: Gán lại giá trị cột khi ngôn ngữ thay đổi
 * Author: txphuc (11/07/2023)
 */
watch(
  () => globalStore.lang,
  () => {
    columns.value = defaultColumns;
  },
  {
    immediate: true,
  }
);

/**
 * Description: Hàm load dữ liệu danh sách nhân viên từ api
 * Author: txphuc (27/06/2023)
 */
const getDepartmentData = async () => {
  try {
    loading.value.table = true;

    const response = await departmentApi.getAll();

    // Format dữ liệu hiển thị ra bảng
    departmentData.value = response.data?.map((department) => {
      department.key = department.DepartmentId;

      return department;
    });

    // Lấy dữ liệu phân trang
    const totalRecords = response.data.length;
    const pageSize = 25;

    pagingInfoState.value.totalRecords = totalRecords;
    pagingInfoState.value.totalPage = Math.ceil(totalRecords / pageSize);

    loading.value.table = false;
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xử lý theo dõi sự thay đổi của filter
 * để get lại dữ liệu tương ứng
 * Author: txphuc (30/06/2023)
 */
watch(
  () => filterParamsState.value,
  () => {
    getDepartmentData();
  },
  { immediate: true, deep: true }
);

/**
 * Description: Hàm xoá nhân viên active hoặc đang được chọn
 * Author: txphuc (11/07/2023)
 */
const handleDeleteDepartment = async () => {
  if (activeRowState.value) {
    // Nếu có hàng đang được active thì xoá hàng đó trước
    await deleteActiveDepartment();
  } else {
    // Xoá các hàng đang checked
    await deleteSelectedDepartment();
  }
};

/**
 * Description: Hàm xoá nhiều đơn vị đã được chọn
 * Author: txphuc (27/06/2023)
 */
const deleteSelectedDepartment = async () => {
  try {
    const deleteIds = selectedRowsState.value.map((row) => row.DepartmentId);

    await departmentApi.delete(deleteIds);

    dialogState.value.active = false;
    await getDepartmentData();
    uncheckedAllRows();

    // Hiện toast message xoá thành công
    toastStore.pushSuccessMessage({
      message: MISAResource[globalStore.lang]?.Page?.Department?.Toast?.DeleteSuccess,
    });
  } catch (error) {
    console.warn(error);
    hideConfirmDialog();
  }
};

/**
 * Description: Hàm xoá một đơn vị đang active
 * Author: txphuc (11/07/2023)
 */
const deleteActiveDepartment = async () => {
  try {
    await departmentApi.deleteById(activeRowState.value?.DepartmentId);

    dialogState.value.active = false;
    await getDepartmentData();
    setActiveRow(null);

    // Hiện toast message xoá thành công
    toastStore.pushSuccessMessage({
      message: MISAResource[globalStore.lang]?.Page?.Department?.Toast?.DeleteSuccess,
    });
  } catch (error) {
    console.warn(error);
    hideConfirmDialog();
  }
};

/**
 * Description: Lấy các bản ghi đã được chọn trả về từ bảng.
 * Author: txphuc (24/06/2023).
 */
const selectTableRows = (value) => {
  selectedRowsState.value = value;
};

/**
 * Description: Bỏ chọn toàn bộ bản ghi trong bảng.
 * Author: txphuc (24/06/2023).
 */
const uncheckedAllRows = () => {
  selectedRowsState.value = [];
};

/**
 * Description: Xử lý chọn chỉ một hàng (chờ xoá/nhân bản)
 * Author: txphuc (11/07/2023)
 */
const setActiveRow = (row) => {
  activeRowState.value = row;
};

/**
 * Description: Hiện dialog xác nhận xoá
 * Author: txphuc (24/06/2023).
 */
const showDeleteConfirmDialog = (description) => {
  dialogState.value = {
    active: true,
    title: MISAResource[globalStore.lang]?.Page?.Department?.Dialog?.DeleteConfirmTitle,
    type: "warning",
    description: description,
  };
};

/**
 * Description: Ẩn dialog xác nhận và bỏ hàng được chọn
 * Author: txphuc (27/06/2023).
 */
const hideConfirmDialog = () => {
  dialogState.value.active = false;
  selectedRowsState.value = [];
};

/**
 * Description: Xử lý chuyển trang trang tiếp theo
 * Author: txphuc (30/06/2023)
 */
const handleNextPage = (nextPage) => {
  filterParamsState.value.page = nextPage;
};

/**
 * Description: Xử lý chuyển trang trang trước đó
 * Author: txphuc (30/06/2023)
 */
const handlePrevPage = (prevPage) => {
  filterParamsState.value.page = prevPage;
};

/**
 * Description: Xử lý thay đổi filter để bắt đầu tìm kiếm
 * Author: txphuc (30/06/2023)
 */
const handleSearchEmployee = () => {
  filterParamsState.value.page = 1;
  filterParamsState.value.search = searchFieldState.value;
};

/**
 * Description: Xử lý thay đổi pageSize
 * Author: txphuc (30/06/2023)
 */
const handleChangePageSize = (newPageSize) => {
  filterParamsState.value.pageSize = newPageSize;

  // Reset lại số trang hiện tại
  filterParamsState.value.page = 1;
};

/**
 * Description: Reset filter và load lại dữ liệu
 * Author: txphuc (30/06/2023)
 */
const handleResetFilter = () => {
  filterParamsState.value = {
    ...filterParamsState.value,
    page: 1,
    pageSize: 25,
    search: "",
  };

  searchFieldState.value = "";
};

/**
 * Description: Áp dụng thay đổi khi customize bảng
 * Author: txphuc (22/07/2023)
 */
const applyTableCustomize = (newColums) => {
  columns.value = newColums;
};

/**
 * Description: Xử lý sự kiện bàn phím
 * Author: txphuc (01/08/2023)
 */
const handleKeyboardEvent = (e) => {
  try {
    const keyCode = e.keyCode;
    // const shiftKey = e.shiftKey;
    const ctrlKey = e.ctrlKey;

    switch (keyCode) {
      case enums.key.NUM_1:
        if (ctrlKey) {
          employeeStore.openFormForCreate();
        }
        break;
      case enums.key.D:
        e.preventDefault();
        if (ctrlKey) {
          if (selectedRowsState.value.length > 0) {
            showDeleteConfirmDialog(
              MISAResource[globalStore.lang]?.Page?.Department?.Dialog?.MultipleDeleteConfirmDesc
            );
          }
        }
        break;
      default:
        break;
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Thêm sự kiện bàn phím khi component được mounted
 * Author: txphuc (01/08/2023)
 */
onMounted(() => {
  document.addEventListener("keydown", handleKeyboardEvent);
});

/**
 * Description: Huỷ sự kiện bàn phím khi component được unMounted
 * Author: txphuc (01/08/2023)
 */
onUnmounted(() => {
  document.removeEventListener("keydown", handleKeyboardEvent);
});
</script>

<style scoped></style>
