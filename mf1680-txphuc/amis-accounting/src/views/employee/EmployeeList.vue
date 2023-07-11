<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">{{ MISAResource[globalStore.lang].Page.Employee.Title }}</h1>
        <span class="page__title-icon ms-icon--angle-down-24" title="Dropdown"></span>
      </div>

      <div class="page__header-controls">
        <MISAButton @click="employeeStore.openFormForCreate" type="primary">{{
          MISAResource[globalStore.lang].Page.Employee.AddButton
        }}</MISAButton>
      </div>
    </div>

    <div class="page__content">
      <div class="filter-container">
        <div class="filter__left">
          <div :class="['filter__select-infor', { '--active': selectedRowsState.length > 0 }]">
            <div>
              {{ MISAResource[globalStore.lang].Text.Selected }}
              <span id="selected-count" class="text-bold">{{ selectedRowsState.length }}</span>
            </div>
            <MISAButton @click="uncheckedAllRows()" type="link" class="ms-16">{{
              MISAResource[globalStore.lang].Button.UnChecked
            }}</MISAButton>
            <MISAButton
              @click="
                showDeleteConfirmDialog(
                  MISAResource[globalStore.lang].Page.Employee.Dialog.MultipleDeleteConfirmDesc(
                    selectedRowsState.length
                  )
                )
              "
              type="secondary"
              class="ms-24"
              >{{ MISAResource[globalStore.lang].Button.Delete }}</MISAButton
            >
          </div>
        </div>
        <div class="filter__right">
          <MISAInputGroup for="search-input">
            <MISAInput
              @keydown.enter="handleSearchEmployee"
              v-model="searchFieldState"
              :placeholder="MISAResource[globalStore.lang].Page.Employee.SearchPlaceholder"
              id="search-input"
            />
            <MISAInputAction @click="handleSearchEmployee">
              <MISAIcon size="20" icon="search" />
            </MISAInputAction>
          </MISAInputGroup>
          <MISAButton
            @click="handleResetFilter"
            v-tooltip.left="MISAResource[globalStore.lang].Tooltip.Reload"
            type="secondary"
          >
            <template #icon><MISAIcon size="20" icon="reload" /></template>
          </MISAButton>
        </div>
      </div>

      <!-- table -->
      <MISATable
        :columns="columns"
        :data-source="employeeData"
        :selected-rows="selectedRowsState"
        :active-row="activeRowState"
        :loading="isLoading"
        :total-page="pagingInfoState.totalPage"
        :total-records="pagingInfoState.totalRecords"
        :current-page="filterParamsState.pageNumber"
        :page-size="filterParamsState.pageSize"
        @select-row="selectTableRows"
        @active-row="setActiveRow"
        @next-page="handleNextPage"
        @prev-page="handlePrevPage"
        @select-page-size="handleChangePageSize"
        @double-click="employeeStore.openFormForUpdate"
      >
        <template #context-menu>
          <MISAContextMenu small>
            <MISAContextItem @click="employeeStore.openFormForDuplicate(activeRowState)">{{
              MISAResource[globalStore.lang].ContextMenu.Duplicate
            }}</MISAContextItem>
            <MISAContextItem
              @click="
                showDeleteConfirmDialog(
                  MISAResource[globalStore.lang].Page.Employee.Dialog.DeleteConfirmDesc(
                    activeRowState.FullName
                  )
                )
              "
              >{{ MISAResource[globalStore.lang].ContextMenu.Delete }}</MISAContextItem
            >
            <MISAContextItem>{{
              MISAResource[globalStore.lang].ContextMenu.StopUsing
            }}</MISAContextItem>
          </MISAContextMenu>
        </template>
      </MISATable>

      <!-- Modal -->
      <Teleport to="#app">
        <MISADialog v-if="dialogState.active" v-bind="dialogState" @cancel="hideConfirmDialog">
          <MISAButton @click="hideConfirmDialog" type="secondary">{{
            MISAResource[globalStore.lang].Button.Cancel
          }}</MISAButton>
          <MISAButton @click="handleDeleteEmployee" type="danger">{{
            MISAResource[globalStore.lang].Button.Delete
          }}</MISAButton>
        </MISADialog>
      </Teleport>

      <!-- Employee detail -->
      <EmployeeDetail v-if="employeeStore.isOpenForm" @submit="getEmployeeData"></EmployeeDetail>
    </div>
  </div>
</template>

<script setup>
import { ref, watch } from "vue";

import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISAInput from "@/components/base/input/MISAInput.vue";
import MISAInputGroup from "@/components/base/input/MISAInputGroup.vue";
import MISAInputAction from "@/components/base/input/MISAInputAction.vue";
import MISATable from "@/components/base/table/MISATable.vue";
import MISAContextMenu from "@/components/base/context-menu/MISAContextMenu.vue";
import MISAContextItem from "@/components/base/context-menu/MISAContextItem.vue";
import MISADialog from "@/components/base/dialog/MISADialog.vue";
import EmployeeDetail from "./EmployeeDetail.vue";
import employeeApi from "@/api/employee-api";
import formatDate from "@/helper/format-date";
import MISAResource from "@/helper/resource";
import { useGlobalStore } from "@/stores/global-store";
import { useEmployeeStore } from "@/stores/employee-store";
import { useToastStore } from "@/stores/toast-store";

const employeeData = ref([]);
const searchFieldState = ref("");
const filterParamsState = ref({
  pageNumber: 1,
  pageSize: 10,
  employeeFilter: "",
});
const pagingInfoState = ref({
  totalPage: 0,
  totalRecords: 0,
});
const selectedRowsState = ref([]);
const activeRowState = ref(null);
const dialogState = ref({
  active: false,
  type: "warning",
  title: "",
  description: "",
});
const isLoading = ref(false);

const globalStore = useGlobalStore();
const employeeStore = useEmployeeStore();
const toastStore = useToastStore();

const columns = ref([]);

/**
 * Description: Gán lại giá trị cột khi ngôn ngữ thay đổi
 * Author: txphuc (11/07/2023)
 */
watch(
  () => globalStore.lang,
  () => {
    columns.value = [
      {
        key: 1,
        title: MISAResource[globalStore.lang].Page.Employee.EmployeeCode.SubTitle,
        dataIndex: "EmployeeCode",
        width: 130,
        sticky: "left",
      },
      {
        key: 2,
        title: MISAResource[globalStore.lang].Page.Employee.FullName.SubTitle,
        dataIndex: "FullName",
        width: 200,
        sticky: "left",
      },
      {
        key: 3,
        title: MISAResource[globalStore.lang].Page.Employee.Gender.Title,
        dataIndex: "GenderName",
      },
      {
        key: 4,
        title: MISAResource[globalStore.lang].Page.Employee.DateOfBirth.Title,
        dataIndex: "DateOfBirthFormated",
        align: "center",
      },
      {
        key: 5,
        title: MISAResource[globalStore.lang].Page.Employee.IdentityNumber.Title,
        dataIndex: "IdentityNumber",
        desc: MISAResource[globalStore.lang].Page.Employee.IdentityNumber.Desc,
        align: "right",
      },
      {
        key: 6,
        title: MISAResource[globalStore.lang].Page.Employee.Position.Title,
        dataIndex: "PositionName",
        width: 180,
      },
      {
        key: 7,
        title: MISAResource[globalStore.lang].Page.Employee.Department.Title,
        dataIndex: "DepartmentName",
        width: 240,
      },
      {
        key: 8,
        title: MISAResource[globalStore.lang].Page.Employee.BankAccount.SubTitle,
        dataIndex: "BankAccount",
        align: "right",
        width: 180,
      },
      {
        key: 9,
        title: MISAResource[globalStore.lang].Page.Employee.BankName.Title,
        dataIndex: "BankName",
      },
      {
        key: 10,
        title: MISAResource[globalStore.lang].Page.Employee.BankBranch.SubTitle,
        dataIndex: "BankBranch",
        desc: MISAResource[globalStore.lang].Page.Employee.BankBranch.Desc,
        width: 240,
      },
    ];
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
    isLoading.value = true;

    const response = await employeeApi.filter(filterParamsState.value);

    // Format dữ liệu hiển thị ra bảng
    employeeData.value = response.data?.Data?.map((employee) => {
      employee.key = employee.EmployeeId;
      employee.DateOfBirthFormated = formatDate(employee.DateOfBirth);

      return employee;
    });

    // Lấy dữ liệu phân trang
    pagingInfoState.value.totalRecords = response.data.TotalRecord;
    pagingInfoState.value.totalPage = response.data.TotalPage;

    isLoading.value = false;
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
    getEmployeeData();
  },
  { immediate: true, deep: true }
);

/**
 * Description: Hàm xoá nhân viên active hoặc đang được chọn
 * Author: txphuc (11/07/2023)
 */
const handleDeleteEmployee = async () => {
  try {
    if (activeRowState.value) {
      // Nếu có hàng đang được active thì xoá hàng đó trước
      await deleteActiveEmployee();
    } else {
      // Xoá các hàng đang checked
      await deleteSelectedEmployee();
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Hàm xoá nhiều nhân viên đã được chọn
 * Author: txphuc (27/06/2023)
 */
const deleteSelectedEmployee = async () => {
  try {
    const responseArr = selectedRowsState.value.map(async (employee) => {
      const response = await employeeApi.delete(employee.EmployeeId);

      return response;
    });

    await Promise.all(responseArr);

    dialogState.value.active = false;
    await getEmployeeData();
    uncheckedAllRows();

    // Hiện toast message xoá thành công
    toastStore.pushSuccessMessage({
      message: MISAResource[globalStore.lang].Page.Employee.Toast.DeleteSuccess,
    });
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Hàm xoá một nhân viên đang active
 * Author: txphuc (11/07/2023)
 */
const deleteActiveEmployee = async () => {
  try {
    await employeeApi.delete(activeRowState.value?.EmployeeId);

    dialogState.value.active = false;
    await getEmployeeData();
    setActiveRow(null);

    // Hiện toast message xoá thành công
    toastStore.pushSuccessMessage({
      message: MISAResource[globalStore.lang].Page.Employee.Toast.DeleteSuccess,
    });
  } catch (error) {
    console.warn(error);
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
    title: MISAResource[globalStore.lang].Page.Employee.Dialog.DeleteConfirmTitle,
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
  filterParamsState.value.pageNumber = nextPage;
};

/**
 * Description: Xử lý chuyển trang trang trước đó
 * Author: txphuc (30/06/2023)
 */
const handlePrevPage = (prevPage) => {
  filterParamsState.value.pageNumber = prevPage;
};

/**
 * Description: Xử lý thay đổi filter để bắt đầu tìm kiếm
 * Author: txphuc (30/06/2023)
 */
const handleSearchEmployee = () => {
  filterParamsState.value.pageNumber = 1;
  filterParamsState.value.employeeFilter = searchFieldState.value;
};

/**
 * Description: Xử lý thay đổi pageSize
 * Author: txphuc (30/06/2023)
 */
const handleChangePageSize = (newPageSize) => {
  filterParamsState.value.pageSize = newPageSize;

  // Reset lại số trang hiện tại
  filterParamsState.value.pageNumber = 1;
};

/**
 * Description: Reset filter và load lại dữ liệu
 * Author: txphuc (30/06/2023)
 */
const handleResetFilter = () => {
  filterParamsState.value = {
    ...filterParamsState.value,
    pageNumber: 1,
    pageSize: 10,
    employeeFilter: "",
  };

  searchFieldState.value = "";
};
</script>

<style scoped></style>
