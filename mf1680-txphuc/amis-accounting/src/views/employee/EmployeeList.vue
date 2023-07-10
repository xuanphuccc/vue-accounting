<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">Nhân viên</h1>
        <span class="page__title-icon ms-icon--angle-down-24" title="Dropdown"></span>
      </div>

      <div class="page__header-controls">
        <MISAButton @click="employeeStore.openFormForCreate" type="primary"
          >Thêm mới nhân viên</MISAButton
        >
      </div>
    </div>

    <div class="page__content">
      <div class="filter-container">
        <div class="filter__left">
          <div :class="['filter__select-infor', { '--active': selectedRowsState.length > 0 }]">
            <div>
              Đã chọn
              <span id="selected-count" class="text-bold">{{ selectedRowsState.length }}</span>
            </div>
            <MISAButton @click="uncheckedAllRows()" type="link" class="ms-16">Bỏ chọn</MISAButton>
            <MISAButton
              @click="
                showDeleteConfirmDialog(`Bạn có muốn xoá ${selectedRowsState.length} nhân viên`)
              "
              type="secondary"
              class="ms-24"
              >Xoá</MISAButton
            >
          </div>
        </div>
        <div class="filter__right">
          <MISAInputGroup for="search-input">
            <MISAInput
              @keydown.enter="handleSearchEmployee"
              v-model="searchFieldState"
              placeholder="Tìm theo mã, tên nhân viên"
              id="search-input"
            />
            <MISAInputAction @click="handleSearchEmployee">
              <MISAIcon size="20" icon="search" />
            </MISAInputAction>
          </MISAInputGroup>
          <MISAButton @click="handleResetFilter" v-tooltip.left="'Tải lại'" type="secondary">
            <template #icon><MISAIcon size="20" icon="reload" /></template>
          </MISAButton>
        </div>
      </div>

      <!-- table -->
      <MISATable
        :columns="columns"
        :data-source="employeeData"
        :selected-rows="selectedRowsState"
        :loading="isLoading"
        :total-page="pagingInfoState.totalPage"
        :total-records="pagingInfoState.totalRecords"
        :current-page="filterParamsState.pageNumber"
        :page-size="filterParamsState.pageSize"
        @select-row="selectTableRows"
        @next-page="handleNextPage"
        @prev-page="handlePrevPage"
        @select-page-size="handleChangePageSize"
        @double-click="employeeStore.openFormForUpdate"
      >
        <template #context-menu>
          <MISAContextMenu>
            <MISAContextItem>Nhân bản</MISAContextItem>
            <MISAContextItem
              @click="
                showDeleteConfirmDialog(
                  `Xoá nhân viên ${selectedRowsState[0]?.FullName}. Nhân viên sau khi xoá sẽ không thể khôi phục lại được`
                )
              "
              >Xoá</MISAContextItem
            >
            <MISAContextItem>Ngừng sử dụng</MISAContextItem>
          </MISAContextMenu>
        </template>
      </MISATable>

      <!-- Modal -->
      <Teleport to="#app">
        <MISADialog v-if="dialogState.active" v-bind="dialogState" @cancel="hideConfirmDialog">
          <MISAButton @click="hideConfirmDialog" type="secondary">Huỷ</MISAButton>
          <MISAButton @click="deleteSelectedEmployee" type="danger">Xoá</MISAButton>
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
const dialogState = ref({
  active: false,
  type: "warning",
  title: "",
  description: "",
});
const isLoading = ref(false);

const employeeStore = useEmployeeStore();
const toastStore = useToastStore();

const columns = ref([
  { key: 1, title: "Mã nhân viên", dataIndex: "EmployeeCode", width: 120, sticky: "left" },
  { key: 2, title: "Tên nhân viên", dataIndex: "FullName", width: 200, sticky: "left" },
  { key: 3, title: "Giới tính", dataIndex: "GenderName" },
  { key: 4, title: "Ngày sinh", dataIndex: "DateOfBirthFormated", align: "center" },
  {
    key: 5,
    title: "Số CMND",
    dataIndex: "IdentityNumber",
    align: "right",
    desc: "Số Chứng minh nhân dân",
  },
  { key: 6, title: "Chức danh", dataIndex: "PositionName" },
  { key: 7, title: "Tên đơn vị", dataIndex: "DepartmentName", width: 240 },
  { key: 8, title: "Email", dataIndex: "Email" },
  { key: 9, title: "Số điện thoại", dataIndex: "PhoneNumber", align: "right" },
  { key: 10, title: "Lương", dataIndex: "Salary", align: "right" },
]);

/**
 * Description: Hàm load dữ liệu nhân viên từ api
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
 * Description: Hàm xoá một/nhiều nhân viên đã được chọn
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
    toastStore.pushMessage({
      type: "success",
      title: "Thành công",
      message: "Xoá thành công",
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
 * Description: Hiện dialog xác nhận xoá
 * Author: txphuc (24/06/2023).
 */
const showDeleteConfirmDialog = (description) => {
  dialogState.value = {
    active: true,
    title: "Xoá nhân viên",
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
