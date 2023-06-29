<template>
  <Teleport to="#app">
    <MISAPopup @close="employeeStore.closeForm" :width="800" title="Thông tin nhân viên">
      <template #default>
        <MISARow :gutter="{ x: 24 }">
          <MISACol span="6">
            <MISARow :gutter="{ x: 8 }">
              <MISACol span="5">
                <MISAFormGroup label="Mã" for="input-id" class="mb-24">
                  <MISAInput v-model="formData.employeeCode" focus id="input-id" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup label="Tên" for="input-name" class="mb-24">
                  <MISAInput v-model="formData.fullName" id="input-name" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup label="Đơn vị" for="input-department" class="mb-24">
                  <MISADropdown
                    v-model="formData.departmentId"
                    :options="departmentOptions"
                    id="input-department"
                  ></MISADropdown>
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup label="Chức danh" for="input-position" class="mb-24">
                  <MISADropdown
                    v-model="formData.positionId"
                    :options="positionOptions"
                    id="input-position"
                  ></MISADropdown>
                </MISAFormGroup>
              </MISACol>
            </MISARow>
          </MISACol>
          <MISACol span="6">
            <MISARow :gutter="{ x: 8 }">
              <MISACol span="5">
                <MISAFormGroup label="Ngày sinh" for="input-date-of-birth" class="mb-24">
                  <MISAInput v-model="formData.dateOfBirth" type="date" id="input-date-of-birth" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup label="Giới tính" for="" class="mb-24">
                  <div class="d-flex col-gap-16">
                    <MISARadioButton v-model="formData.gender" value="0" label="Nam" />
                    <MISARadioButton v-model="formData.gender" value="1" label="Nữ" />
                    <MISARadioButton v-model="formData.gender" value="2" label="Khác" />
                  </div>
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup
                  v-tooltip.top="'Số Chứng minh nhân dân'"
                  label="Số CMND"
                  for="input-identity-number"
                  class="mb-24"
                >
                  <MISAInput v-model="formData.identityNumber" id="input-identity-number" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="5">
                <MISAFormGroup label="Ngày cấp" for="input-identity-date" class="mb-24">
                  <MISAInput v-model="formData.identityDate" type="date" id="input-identity-date" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup label="Nơi cấp" for="input-identity-place" class="mb-24">
                  <MISAInput v-model="formData.identityPlace" id="input-identity-place" />
                </MISAFormGroup>
              </MISACol>
            </MISARow>
          </MISACol>
        </MISARow>

        <MISARow :gutter="{ x: 8 }">
          <MISACol span="12">
            <MISAFormGroup label="Địa chỉ" for="input-address" class="mb-24">
              <MISAInput v-model="formData.address" id="input-address" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="4">
            <MISAFormGroup label="Số điện thoại" for="input-phone-number">
              <MISAInput v-model="formData.phoneNumber" id="input-phone-number" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="4">
            <MISAFormGroup label="Email" for="input-email">
              <MISAInput v-model="formData.email" id="input-email" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="4">
            <MISAFormGroup label="Tiền lương" for="input-salary">
              <MISAInput v-model="formData.salary" id="input-salary" />
            </MISAFormGroup>
          </MISACol>
        </MISARow>
      </template>

      <template #controls-left>
        <MISAButton @click="employeeStore.closeForm" type="secondary">Huỷ</MISAButton>
      </template>
      <template #controls-right>
        <MISAButton type="secondary">Cất</MISAButton>
        <MISAButton
          v-if="employeeStore.mode === 'create'"
          @click="handleCreateEmployee"
          type="primary"
          >Cất và thêm</MISAButton
        >
        <MISAButton v-else @click="handleUpdateEmployee" type="primary">Cất và lưu</MISAButton>
      </template>
    </MISAPopup>

    <MISADialog
      v-if="dialogState.active"
      v-bind="dialogState"
      @cancel="closeDialog"
      @ok="closeDialog"
    />
  </Teleport>
</template>

<script setup>
import MISAPopup from "../../components/base/popup/MISAPopup.vue";
import MISADialog from "@/components/base/dialog/MISADialog.vue";
import MISAButton from "../../components/base/button/MISAButton.vue";
import MISAFormGroup from "../../components/base/input/MISAFormGroup.vue";
import MISAInput from "../../components/base/input/MISAInput.vue";
import MISARadioButton from "../../components/base/radio-button/MISARadioButton.vue";
import MISADropdown from "../../components/base/dropdown-list/MISADropdown.vue";
import MISARow from "../../components/base/grid/MISARow.vue";
import MISACol from "../../components/base/grid/MISACol.vue";

import { ref } from "vue";
import employeeApi from "../../api/employee-api";
import departmentApi from "@/api/department-api";
import positionApi from "@/api/position-api";
import formatDate from "@/helper/format-date";
import { useEmployeeStore } from "@/stores/employee-store";
import { useToastStore } from "@/stores/toast-store";

const emit = defineEmits(["submit"]);

const employeeStore = useEmployeeStore();
const toastStore = useToastStore();

const departmentOptions = ref([]);
const positionOptions = ref([]);
const dialogState = ref({
  active: false,
  type: "warning",
  title: "",
  description: "",
});

const formData = ref({
  employeeCode: "",
  fullName: "",
  departmentId: "",
  positionId: "",
  dateOfBirth: "",
  gender: "0",
  identityNumber: "",
  identityDate: "",
  identityPlace: "",
  address: "",
  phoneNumber: "",
  email: "",
  salary: "",
});

/**
 * Description: Hàm xử lý gọi api lấy mã nhân viên mới nhất
 * Author: txphuc (28/06/2023)
 */
const getNewEmployeeCode = async () => {
  try {
    if (employeeStore.mode === "create") {
      const response = await employeeApi.getNewCode();

      formData.value.employeeCode = response.data;
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Hàm xử lý gọi api lấy dữ liệu đơn vị
 * Author: txphuc (28/06/2023)
 */
const getDepartmentData = async () => {
  try {
    const response = await departmentApi.getAll();

    departmentOptions.value = response.data?.map((department) => ({
      label: department.DepartmentName,
      value: department.DepartmentId,
    }));
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Hàm xử lý gọi api lấy dữ liệu chức danh
 * Author: txphuc (28/06/2023)
 */
const getPositionData = async () => {
  try {
    const response = await positionApi.getAll();

    positionOptions.value = response.data?.map((position) => ({
      label: position.PositionName,
      value: position.PositionId,
    }));
  } catch (error) {
    console.warn(error);
  }
};

getNewEmployeeCode();
getDepartmentData();
getPositionData();

/**
 * Description: Hàm đóng dialog
 * Author: txphuc (29/06/2023)
 */
const closeDialog = () => {
  dialogState.value.active = false;
};

/**
 * Description: Hàm xử lý gọi api tạo nhân viên
 * Author: txphuc (28/06/2023)
 */
const handleCreateEmployee = async () => {
  try {
    if (employeeStore.mode === "create") {
      const data = {
        ...formData.value,
        gender: Number(formData.value.gender),
        salary: Number(formData.value.salary),
      };

      await employeeApi.create(data);

      emit("submit");
      employeeStore.closeForm();

      // Hiện toast message thành công
      toastStore.pushMessage({
        type: "success",
        title: "Thành công!",
        message: "Thêm nhân viên thành công",
      });
    }
  } catch (error) {
    console.warn(error);

    // Hiện dialog báo lỗi
    dialogState.value = {
      active: true,
      type: "error",
      title: "Đã có lỗi",
      description: error?.response?.data?.devMsg,
    };
  }
};

/**
 * Description: Hàm load dữ liệu để thực hiện update
 * Author: txphuc (28/06/2023)
 */
const handleLoadDataForUpdate = () => {
  try {
    if (employeeStore.mode === "update") {
      const currentEmployee = employeeStore.currentEmployee;

      formData.value = {
        employeeCode: currentEmployee.EmployeeCode,
        fullName: currentEmployee.FullName,
        departmentId: currentEmployee.DepartmentId,
        positionId: currentEmployee.PositionId,
        dateOfBirth: formatDate(currentEmployee.DateOfBirth, "YYYY-MM-DD"),
        gender: currentEmployee.Gender + "",
        identityNumber: currentEmployee.IdentityNumber,
        identityDate: formatDate(currentEmployee.IdentityDate, "YYYY-MM-DD"),
        identityPlace: currentEmployee.IdentityPlace,
        address: currentEmployee.Address,
        phoneNumber: currentEmployee.PhoneNumber,
        email: currentEmployee.Email,
        salary: currentEmployee.Salary + "",
      };
    }
  } catch (error) {
    console.warn(error);
  }
};
handleLoadDataForUpdate();

/**
 * Description: Hàm xử lý gọi api cập nhật nhân viên
 * Author: txphuc (28/06/2023)
 */
const handleUpdateEmployee = async () => {
  try {
    if (employeeStore.mode === "update") {
      const employeeId = employeeStore.currentEmployee.EmployeeId;

      const data = {
        ...formData.value,
        gender: Number(formData.value.gender),
        salary: Number(formData.value.salary),
      };

      await employeeApi.update(employeeId, data);

      emit("submit");
      employeeStore.closeForm();

      // Hiện toast message thành công
      toastStore.pushMessage({
        type: "success",
        title: "Thành công!",
        message: "Cập nhật thành công",
      });
    }
  } catch (error) {
    console.warn(error);

    // Hiện dialog báo lỗi
    dialogState.value = {
      active: true,
      type: "error",
      title: "Đã có lỗi",
      description: error?.response?.data?.devMsg,
    };
  }
};
</script>

<style scoped></style>
