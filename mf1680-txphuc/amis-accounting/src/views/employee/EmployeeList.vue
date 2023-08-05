<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">
          {{ MISAResource[globalStore.lang]?.Page?.Employee?.Title }}
        </h1>
        <MISAIcon icon="angle-down" />
      </div>

      <div class="page__header-controls">
        <MISAButton
          v-tippy="{ content: 'Ctrl + 1' }"
          @click="employeeStore.openFormForCreate"
          type="primary"
          >{{ MISAResource[globalStore.lang]?.Page?.Employee?.AddButton }}</MISAButton
        >
      </div>
    </div>

    <div class="page__content">
      <div class="filter-wrapper">
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
                    MISAResource[globalStore.lang]?.Page?.Employee?.Dialog
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
                :placeholder="MISAResource[globalStore.lang]?.Page?.Employee?.SearchPlaceholder"
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
              v-tippy="{ content: MISAResource[globalStore.lang]?.Tooltip?.ExportExcel }"
              :loading="loading.excel"
              type="secondary"
            >
              <template #icon><MISAIcon icon="excel-gray" no-color /></template>

              <template #dropdown>
                <MISAContextMenu width="215" small>
                  <MISAContextItem @click="downloadAllRecords">
                    {{ MISAResource[globalStore.lang]?.ContextMenu?.ExportAllToExcel }}
                  </MISAContextItem>
                  <MISAContextItem @click="downloadSelectedRecords">
                    {{ MISAResource[globalStore.lang]?.ContextMenu?.ExportListToExcel }}
                  </MISAContextItem>
                </MISAContextMenu>
              </template>
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

        <!-- filter view -->
        <MISAFilterView @filter-change="filterParamsChange" :filters="filterParams" />
      </div>

      <!-- table -->
      <MISATable
        @select-row="selectTableRows"
        @active-row="setActiveRow"
        @double-click="employeeStore.openFormForUpdate"
        :columns="columns"
        :data-source="employeeData"
        :selected-rows="selectedRowsState"
        :active-row="activeRowState"
        :loading="loading.table"
        :sort="filterRequestState"
        :filters="filterParams"
        @filter-change="filterParamsChange"
        @sort-column-change="
          (object) => {
            filterRequestState.sortColumn = object.sortColumn;
            filterRequestState.sortOrder = object.sortOrder;
          }
        "
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
                  ]?.Page?.Employee?.Dialog?.DeleteConfirmDesc?.replace(
                    '@code',
                    activeRowState.EmployeeCode
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
            :current-page="filterRequestState.page"
            :page-size="filterRequestState.pageSize"
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
            <MISAButton auto-focus tabindex="1" @click="handleDeleteEmployee" type="danger">{{
              MISAResource[globalStore.lang]?.Button?.Delete
            }}</MISAButton>
          </template>
        </MISADialog>
      </Teleport>

      <!-- Employee detail -->
      <EmployeeDetail v-if="employeeStore.isOpenForm" @submit="getEmployeeData"></EmployeeDetail>

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
import MISAFilterView from "@/components/base/filter-view/MISAFilterView.vue";
import MISAContextMenu from "@/components/base/context-menu/MISAContextMenu.vue";
import MISAContextItem from "@/components/base/context-menu/MISAContextItem.vue";
import MISADialog from "@/components/base/dialog/MISADialog.vue";
import EmployeeDetail from "./EmployeeDetail.vue";
import employeeApi from "@/api/employee-api";
import formatDate from "@/helper/format-date";
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
const employeeData = ref([]);
const searchFieldState = ref("");
const filterRequestState = ref({
  page: 1,
  pageSize: 10,
  search: "",
  sortColumn: null,
  sortOrder: null,
});
const filterParams = ref([]);
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
    title: MISAResource[globalStore.lang]?.Page?.Employee?.EmployeeCode?.SubTitle,
    dataIndex: "EmployeeCode",
    originName: "EmployeeCode",
    width: 180,
    sticky: "left",
  },
  {
    key: 2,
    title: MISAResource[globalStore.lang]?.Page?.Employee?.FullName?.SubTitle,
    dataIndex: "FullName",
    originName: "FullName",
    width: 200,
    sticky: "left",
  },
  {
    key: 3,
    title: MISAResource[globalStore.lang]?.Page?.Employee?.Gender?.Title,
    dataIndex: "GenderFormated",
    originName: "Gender",
    width: 140,
  },
  {
    key: 4,
    title: MISAResource[globalStore.lang]?.Page?.Employee?.DateOfBirth?.Title,
    dataIndex: "DateOfBirthFormated",
    originName: "DateOfBirth",
    type: Date,
    align: "center",
    width: 200,
  },
  {
    key: 5,
    title: MISAResource[globalStore.lang]?.Page?.Employee?.IdentityNumber?.Title,
    dataIndex: "IdentityNumber",
    originName: "IdentityNumber",
    desc: MISAResource[globalStore.lang]?.Page?.Employee?.IdentityNumber?.Desc,
    align: "left",
    width: 180,
  },
  {
    key: 6,
    title: MISAResource[globalStore.lang]?.Page?.Employee?.Position?.Title,
    dataIndex: "PositionName",
    originName: "PositionName",
    width: 180,
  },
  {
    key: 7,
    title: MISAResource[globalStore.lang]?.Page?.Employee?.Department?.Title,
    dataIndex: "DepartmentName",
    originName: "DepartmentName",
    width: 240,
  },
  {
    key: 8,
    title: MISAResource[globalStore.lang]?.Page?.Employee?.BankAccount?.SubTitle,
    dataIndex: "BankAccount",
    originName: "BankAccount",
    align: "left",
    width: 180,
  },
  {
    key: 9,
    title: MISAResource[globalStore.lang]?.Page?.Employee?.BankName?.Title,
    dataIndex: "BankName",
    originName: "BankName",
    width: 360,
  },
  {
    key: 10,
    title: MISAResource[globalStore.lang]?.Page?.Employee?.BankBranch?.SubTitle,
    dataIndex: "BankBranch",
    originName: "BankBranch",
    desc: MISAResource[globalStore.lang]?.Page?.Employee?.BankBranch?.Desc,
    width: 260,
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
const getEmployeeData = async () => {
  try {
    loading.value.table = true;

    const response = await employeeApi.filter(filterRequestState.value);

    // Format dữ liệu hiển thị ra bảng
    employeeData.value = response.data?.Data?.map((employee) => {
      employee.key = employee.EmployeeId;
      employee.DateOfBirthFormated = formatDate(employee.DateOfBirth);
      employee.GenderFormated =
        employee.Gender === enums.gender.MALE
          ? MISAResource[globalStore.lang]?.Gender?.Male
          : employee.Gender === enums.gender.FEMALE
          ? MISAResource[globalStore.lang]?.Gender?.Female
          : MISAResource[globalStore.lang]?.Gender?.Other;

      return employee;
    });

    // Lấy dữ liệu phân trang
    const totalRecords = response.data.TotalRecords;
    const pageSize = filterRequestState.value.pageSize;

    pagingInfoState.value.totalRecords = totalRecords;
    pagingInfoState.value.totalPage = Math.ceil(totalRecords / pageSize);

    loading.value.table = false;
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Download excel danh sách nhân viên
 * Author: txphuc (21/07/2023)
 */
const downloadExcel = async (employeeIds = []) => {
  try {
    loading.value.excel = true;

    // Lấy danh sách các cột không bị ẩn
    const requestColumns = columns.value
      .filter((col) => !col.hide)
      .map((col, index) => ({
        dataIndex: col.originName,
        title: col.title,
        index: index + 1,
        width: col.width,
        align: col.align,
      }));

    const response = await employeeApi.downloadExcel(requestColumns, employeeIds);

    const blob = new Blob([response.data], {
      type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
    });

    const url = URL.createObjectURL(blob);

    const linkElement = document.createElement("a");
    linkElement.href = url;
    linkElement.download =
      MISAResource[globalStore.lang]?.Page?.Employee?.ExcelExportFileName ?? "export.xlsx";
    linkElement.click();

    loading.value.excel = false;
  } catch (error) {
    console.warn(error);
    loading.value.excel = false;
  }
};

/**
 * Description: Download tất cả danh sách nhân viên
 * Author: txphuc(26/07/2023)
 */
const downloadAllRecords = async () => {
  await downloadExcel();
};

/**
 * Description: Download tất cả danh sách nhân viên
 * Author: txphuc(26/07/2023)
 */
const downloadSelectedRecords = async () => {
  // Danh sách Id của các bản ghi cần xuất
  const employeeIds = selectedRowsState.value.map((employee) => employee.EmployeeId);

  if (employeeIds.length > 0) {
    await downloadExcel(employeeIds);
  }
};

/**
 * Description: Xử lý theo dõi sự thay đổi của filter
 * để get lại dữ liệu tương ứng
 * Author: txphuc (30/06/2023)
 */
watch(
  () => filterRequestState.value,
  () => {
    getEmployeeData();
  },
  { immediate: true, deep: true }
);

/**
 * Description: Xử lý theo dõi sự thay đổi của mảng filterParams
 * để chuyển thành filterRequest sau đó có thể gọi API
 * Author: txphuc (05/08/2023)
 */
watch(
  () => filterParams.value,
  () => {
    const formatedFilters = {};
    filterParams.value.forEach((ft) => {
      formatedFilters[ft.column] = ft.value;
      formatedFilters[ft.column + "FilterBy"] = ft.filterBy;
    });

    filterRequestState.value = {
      page: 1,
      pageSize: filterRequestState.value.pageSize,
      search: filterRequestState.value.search,
      sortColumn: filterRequestState.value.sortColumn,
      sortOrder: filterRequestState.value.sortOrder,
      ...formatedFilters,
    };
  },
  { deep: true }
);

/**
 * Description: Lấy danh sách filter từ bảng
 * Author: txphuc (05/08/2023)
 */
const filterParamsChange = (filters) => {
  filterParams.value = filters;
};

/**
 * Description: Hàm xoá nhân viên active hoặc đang được chọn
 * Author: txphuc (11/07/2023)
 */
const handleDeleteEmployee = async () => {
  if (activeRowState.value) {
    // Nếu có hàng đang được active thì xoá hàng đó trước
    await deleteActiveEmployee();
  } else {
    // Xoá các hàng đang checked
    await deleteSelectedEmployee();
  }
};

/**
 * Description: Hàm xoá nhiều nhân viên đã được chọn
 * Author: txphuc (27/06/2023)
 */
const deleteSelectedEmployee = async () => {
  try {
    const deleteIds = selectedRowsState.value.map((row) => row.EmployeeId);

    await employeeApi.delete(deleteIds);

    dialogState.value.active = false;
    await getEmployeeData();
    uncheckedAllRows();

    // Hiện toast message xoá thành công
    toastStore.pushSuccessMessage({
      message: MISAResource[globalStore.lang]?.Page?.Employee?.Toast?.DeleteSuccess,
    });
  } catch (error) {
    console.warn(error);
    hideConfirmDialog();
  }
};

/**
 * Description: Hàm xoá một nhân viên đang active
 * Author: txphuc (11/07/2023)
 */
const deleteActiveEmployee = async () => {
  try {
    await employeeApi.deleteById(activeRowState.value?.EmployeeId);

    dialogState.value.active = false;
    await getEmployeeData();
    setActiveRow(null);

    // Hiện toast message xoá thành công
    toastStore.pushSuccessMessage({
      message: MISAResource[globalStore.lang]?.Page?.Employee?.Toast?.DeleteSuccess,
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
    title: MISAResource[globalStore.lang]?.Page?.Employee?.Dialog?.DeleteConfirmTitle,
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
  filterRequestState.value.page = nextPage;
};

/**
 * Description: Xử lý chuyển trang trang trước đó
 * Author: txphuc (30/06/2023)
 */
const handlePrevPage = (prevPage) => {
  filterRequestState.value.page = prevPage;
};

/**
 * Description: Xử lý thay đổi filter để bắt đầu tìm kiếm
 * Author: txphuc (30/06/2023)
 */
const handleSearchEmployee = () => {
  filterRequestState.value.page = 1;
  filterRequestState.value.search = searchFieldState.value;
};

/**
 * Description: Xử lý thay đổi pageSize
 * Author: txphuc (30/06/2023)
 */
const handleChangePageSize = (newPageSize) => {
  filterRequestState.value.pageSize = newPageSize;

  // Reset lại số trang hiện tại
  filterRequestState.value.page = 1;
};

/**
 * Description: Reset filter và load lại dữ liệu
 * Author: txphuc (30/06/2023)
 */
const handleResetFilter = () => {
  filterRequestState.value = {
    ...filterRequestState.value,
    page: 1,
    pageSize: 10,
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
              MISAResource[globalStore.lang]?.Page?.Employee?.Dialog?.MultipleDeleteConfirmDesc
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
