<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">Nhân viên</h1>
        <span class="page__title-icon ms-icon--angle-down-24" title="Dropdown"></span>
      </div>

      <div class="page__header-controls">
        <MISAButton @click="togglePopup" type="primary">Thêm mới nhân viên</MISAButton>
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
            <MISAButton @click="removeAllSelectedRows()" type="secondary">Bỏ chọn</MISAButton>
            <MISAButton type="danger">Xoá</MISAButton>
          </div>
        </div>
        <div class="filter__right">
          <MISAInputGroup for="search-input">
            <MISAInput placeholder="Tìm theo mã, tên nhân viên" id="search-input" />
            <MISAInputAction icon="ms-icon--search-20" />
          </MISAInputGroup>
          <MISAButton @click="getEmployeeData" type="secondary" icon="ms-icon--reload-20" />
        </div>
      </div>

      <!-- table -->
      <MISATable
        :columns="columns"
        :data-source="employeeData"
        :selected-rows="selectedRowsState"
        @select-row="selectRows"
        :loading="isLoading"
      >
        <template #name="row">
          <MISAButton type="link">{{ row["name"] }}</MISAButton>
        </template>

        <template #table-actions="row">
          <MISATableAction icon="ms-icon--pen-24"></MISATableAction>
          <MISATableAction>
            <template #action-dropdown>
              <!-- context menu -->
              <MISAContextMenu>
                <MISAContextItem icon="ms-icon--duplicate-24"> Nhân bản </MISAContextItem>
                <MISAContextItem @click="showDeleteConfirmDialog(row)" icon="ms-icon--trash">
                  Xoá
                </MISAContextItem>
                <MISAContextItem icon="ms-icon--circle-slash-24"> Ngừng sử dụng </MISAContextItem>
              </MISAContextMenu>
            </template>
          </MISATableAction>
        </template>
      </MISATable>

      <!-- Modal -->
      <Teleport to="#app">
        <MISADialog
          v-bind="dialogState"
          @close="dialogState.active = false"
          @cancel="dialogState.active = false"
        />
      </Teleport>

      <!-- Employee detail -->
      <EmployeeDetail :active="popupState" @close="togglePopup"></EmployeeDetail>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";

import MISAButton from "../../components/base/button/MISAButton.vue";
import MISAInput from "../../components/base/input/MISAInput.vue";
import MISAInputGroup from "../../components/base/input/MISAInputGroup.vue";
import MISAInputAction from "../../components/base/input/MISAInputAction.vue";
import MISATable from "../../components/base/table/MISATable.vue";
import MISADialog from "../../components/base/dialog/MISADialog.vue";
import MISAContextMenu from "../../components/base/context-menu/MISAContextMenu.vue";
import MISAContextItem from "../../components/base/context-menu/MISAContextItem.vue";
import MISATableAction from "../../components/base/table/MISATableAction.vue";
import EmployeeDetail from "./EmployeeDetail.vue";
import employeeApi from "../../api/employee-api";
import formatDate from "../../helper/format-date";

const employeeData = ref([]);
const selectedRowsState = ref([]);
const dialogState = ref({
  active: false,
  title: "",
  description: "",
});
const popupState = ref(false);
const isLoading = ref(false);

const columns = ref([
  { key: 1, title: "Mã nhân viên", dataIndex: "EmployeeCode" },
  { key: 2, title: "Tên nhân viên", dataIndex: "FullName" },
  { key: 3, title: "Giới tính", dataIndex: "GenderName" },
  { key: 4, title: "Ngày sinh", dataIndex: "DateOfBirthFormated" },
  { key: 5, title: "Số CMND", dataIndex: "IdentityNumber" },
  { key: 6, title: "Chức danh", dataIndex: "PositionName" },
  { key: 7, title: "Tên đơn vị", dataIndex: "DepartmentName" },
  { key: 8, title: "Số tài khoản", dataIndex: "PhoneNumber" },
  { key: 9, title: "Tên ngân hàng", dataIndex: "PhoneNumber" },
  { key: 10, title: "Chi nhánh TK ngân hàng", dataIndex: "PhoneNumber" },
]);

/**
 * Description: Hàm load dữ liệu nhân viên từ api
 * Author: txphuc (27/06/2023)
 */
const getEmployeeData = async () => {
  isLoading.value = true;

  const response = await employeeApi.getAll();

  // Format dữ liệu hiển thị ra bảng
  employeeData.value = response.data?.map((employee) => {
    employee.key = employee.EmployeeId;
    employee.DateOfBirthFormated = formatDate(employee.DateOfBirth);

    return employee;
  });

  isLoading.value = false;
};
getEmployeeData();

/**
 * Description: Lấy các bản ghi đã được chọn trả về từ bảng.
 * Author: txphuc (24/06/2023).
 */
const selectRows = (value) => {
  selectedRowsState.value = value;
};

/**
 * Description: Bỏ chọn toàn bộ bản ghi trong bảng.
 * Author: txphuc (24/06/2023).
 */
const removeAllSelectedRows = () => {
  selectedRowsState.value = [];
};

/**
 * Description: Hiện dialog xác nhận xoá
 * Author: txphuc (24/06/2023).
 */
const showDeleteConfirmDialog = (data) => {
  dialogState.value = {
    active: true,
    title: "Xoá nhân viên",
    type: "error",
    description: `Bạn có muốn xoá nhân viên ${data.FullName}`,
  };
};

/**
 * Description: Đóng/mở popup chi tiết nhân viên
 * Author: txphuc (25/06/2023).
 */
const togglePopup = () => {
  popupState.value = !popupState.value;
};
</script>

<style scoped></style>
