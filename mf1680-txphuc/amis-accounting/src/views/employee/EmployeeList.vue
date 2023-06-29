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
            <MISAButton @click="removeAllSelectedRows()" type="link" class="ms-16"
              >Bỏ chọn</MISAButton
            >
            <MISAButton type="secondary" class="ms-24">Xoá</MISAButton>
          </div>
        </div>
        <div class="filter__right">
          <MISAInputGroup for="search-input">
            <MISAInput placeholder="Tìm theo mã, tên nhân viên" id="search-input" />
            <MISAInputAction icon="ms-icon--search-20" />
          </MISAInputGroup>
          <MISAButton
            @click="getEmployeeData"
            v-tooltip.left="'Tải lại'"
            type="secondary"
            icon="ms-icon--reload-20"
          />
        </div>
      </div>

      <!-- table -->
      <MISATable
        :columns="columns"
        :data-source="employeeData"
        :selected-rows="selectedRowsState"
        @select-row="selectTableRows"
        :loading="isLoading"
      >
        <template #FullName="row">
          <MISAButton type="link">{{ row["FullName"] }}</MISAButton>
        </template>

        <template #table-actions="row">
          <MISATableAction
            @click="employeeStore.openFormForUpdate(row)"
            title="Chỉnh sửa"
            icon="ms-icon--pen-24"
          ></MISATableAction>
          <MISATableAction title="Thêm">
            <template #action-dropdown>
              <!-- context menu -->
              <MISAContextMenu>
                <MISAContextItem icon="ms-icon--duplicate-24"> Nhân bản </MISAContextItem>
                <MISAContextItem
                  @click="
                    () => {
                      showDeleteConfirmDialog(row);
                      setSingleSelectedRow(row);
                    }
                  "
                  icon="ms-icon--trash"
                >
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
          @ok="deleteSelectedEmployee"
          @close="hideConfirmDialog"
          @cancel="hideConfirmDialog"
        />
      </Teleport>

      <!-- Employee detail -->
      <EmployeeDetail v-if="employeeStore.isOpenForm" @submit="getEmployeeData"></EmployeeDetail>
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
import { useEmployeeStore } from "@/stores/employee-store";

const employeeData = ref([]);
const selectedRowsState = ref([]);
const dialogState = ref({
  active: false,
  title: "",
  description: "",
});
const isLoading = ref(false);
const employeeStore = useEmployeeStore();

const columns = ref([
  { key: 1, title: "Mã nhân viên", dataIndex: "EmployeeCode" },
  { key: 2, title: "Tên nhân viên", dataIndex: "FullName" },
  { key: 3, title: "Giới tính", dataIndex: "GenderName" },
  { key: 4, title: "Ngày sinh", dataIndex: "DateOfBirthFormated", align: "center" },
  { key: 5, title: "Số CMND", dataIndex: "IdentityNumber", desc: "Số Chứng minh nhân dân" },
  { key: 6, title: "Chức danh", dataIndex: "PositionName" },
  { key: 7, title: "Tên đơn vị", dataIndex: "DepartmentName" },
  { key: 8, title: "Email", dataIndex: "Email" },
  { key: 9, title: "Số điện thoại", dataIndex: "PhoneNumber" },
  { key: 10, title: "Lương", dataIndex: "Salary", align: "right" },
]);

/**
 * Description: Hàm load dữ liệu nhân viên từ api
 * Author: txphuc (27/06/2023)
 */
const getEmployeeData = async () => {
  try {
    isLoading.value = true;

    const response = await employeeApi.getAll();

    // Format dữ liệu hiển thị ra bảng
    employeeData.value = response.data?.map((employee) => {
      employee.key = employee.EmployeeId;
      employee.DateOfBirthFormated = formatDate(employee.DateOfBirth);

      return employee;
    });

    isLoading.value = false;
  } catch (error) {
    console.warn(error);
  }
};
getEmployeeData();

/**
 * Description: Hàm xoá nhân viên đã được chọn
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
    removeAllSelectedRows();
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
 * Description: Set cột đang được chọn để xác nhận xoá
 * Author: txphuc (27/06/2023)
 */
const setSingleSelectedRow = (row) => {
  selectedRowsState.value = [row];
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
 * Description: Ẩn dialog xác nhận và bỏ hàng được chọn
 * Author: txphuc (27/06/2023).
 */
const hideConfirmDialog = () => {
  dialogState.value.active = false;
  selectedRowsState.value = [];
};
</script>

<style scoped></style>
