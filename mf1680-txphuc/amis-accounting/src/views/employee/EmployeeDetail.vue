<template>
  <Teleport to="#app">
    <MISAPopup
      @close="employeeStore.closeForm"
      @submit="handleSubmitForm()"
      :width="860"
      :title="employeeStore.mode === enums.form.mode.CREATE ? 'Thêm nhân viên' : 'Sửa nhân viên'"
    >
      <template #default>
        <MISARow :gutter="{ x: 24 }">
          <MISACol span="6">
            <MISARow :gutter="{ x: 8 }">
              <MISACol span="5">
                <MISAFormGroup
                  :error-msg="validatedInputs.employeeCode"
                  label="Mã"
                  for="input-id"
                  class="mb-24"
                  required-mark
                >
                  <MISAInput
                    tabindex="1"
                    v-model="formData.employeeCode"
                    @blur="validateEmployeeCode"
                    @input="validatedInputs.employeeCode = null"
                    focus
                    id="input-id"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup
                  :error-msg="validatedInputs.fullName"
                  label="Tên"
                  for="input-name"
                  class="mb-24"
                  required-mark
                >
                  <MISAInput
                    tabindex="2"
                    v-model="formData.fullName"
                    @blur="validateFullName"
                    @input="validatedInputs.fullName = null"
                    id="input-name"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup label="Đơn vị" for="input-department" class="mb-24" required-mark>
                  <MISASelect
                    tabindex="3"
                    v-model="formData.departmentId"
                    :options="departmentOptions"
                    id="input-department"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup label="Chức danh" for="input-position" class="mb-24">
                  <MISASelect
                    tabindex="4"
                    v-model="formData.positionId"
                    :options="positionOptions"
                    id="input-position"
                    :search="true"
                  />
                </MISAFormGroup>
              </MISACol>
            </MISARow>
          </MISACol>
          <MISACol span="6">
            <MISARow :gutter="{ x: 8 }">
              <MISACol span="5">
                <MISAFormGroup label="Ngày sinh" for="input-date-of-birth" class="mb-24">
                  <MISAInput
                    tabindex="5"
                    v-model="formData.dateOfBirth"
                    type="date"
                    id="input-date-of-birth"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup label="Giới tính" for="" class="mb-24">
                  <div class="d-flex col-gap-16">
                    <MISARadioButton tabindex="6" v-model="formData.gender" value="0" label="Nam" />
                    <MISARadioButton tabindex="7" v-model="formData.gender" value="1" label="Nữ" />
                    <MISARadioButton
                      tabindex="8"
                      v-model="formData.gender"
                      value="2"
                      label="Khác"
                    />
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
                  <MISAInput
                    tabindex="9"
                    v-model="formData.identityNumber"
                    id="input-identity-number"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="5">
                <MISAFormGroup label="Ngày cấp" for="input-identity-date" class="mb-24">
                  <MISAInput
                    tabindex="10"
                    v-model="formData.identityDate"
                    type="date"
                    id="input-identity-date"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup label="Nơi cấp" for="input-identity-place" class="mb-24">
                  <MISAInput
                    tabindex="11"
                    v-model="formData.identityPlace"
                    id="input-identity-place"
                  />
                </MISAFormGroup>
              </MISACol>
            </MISARow>
          </MISACol>
        </MISARow>

        <MISARow :gutter="{ x: 8 }">
          <MISACol span="12">
            <MISAFormGroup label="Địa chỉ" for="input-address" class="mb-24">
              <MISAInput tabindex="12" v-model="formData.address" id="input-address" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="4">
            <MISAFormGroup label="Số điện thoại" for="input-phone-number">
              <MISAInput tabindex="13" v-model="formData.phoneNumber" id="input-phone-number" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="4">
            <MISAFormGroup label="Email" for="input-email">
              <MISAInput tabindex="14" v-model="formData.email" id="input-email" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="4">
            <MISAFormGroup label="Tiền lương" for="input-salary">
              <MISAInput
                tabindex="15"
                :model-value="formData.salary"
                @update:modelValue="
                  (value) => {
                    formData.salary = convertNumberToCurrency(value);
                  }
                "
                id="input-salary"
              />
            </MISAFormGroup>
          </MISACol>
        </MISARow>
      </template>

      <template #controls-left>
        <MISAButton tabindex="18" @click="employeeStore.closeForm" type="secondary">Huỷ</MISAButton>
      </template>
      <template #controls-right>
        <MISAButton tabindex="17" @click="handleSubmitForm(false)" type="secondary">
          <MISASpinner v-if="loading.submit" absolute />
          <span :style="{ opacity: loading.submit ? 0 : 1 }">Cất</span>
        </MISAButton>
        <MISAButton tabindex="16" @click="handleSubmitForm()" type="primary">
          <MISASpinner v-if="loading.submitAndContinue" absolute />
          <span :style="{ opacity: loading.submitAndContinue ? 0 : 1 }">Cất và thêm</span>
        </MISAButton>
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
import MISAPopup from "@/components/base/popup/MISAPopup.vue";
import MISADialog from "@/components/base/dialog/MISADialog.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISAFormGroup from "@/components/base/input/MISAFormGroup.vue";
import MISAInput from "@/components/base/input/MISAInput.vue";
import MISARadioButton from "@/components/base/radio-button/MISARadioButton.vue";
import MISASelect from "@/components/base/select/MISASelect.vue";
import MISASpinner from "@/components/base/spinner/MISASpinner.vue";
import MISARow from "@/components/base/grid/MISARow.vue";
import MISACol from "@/components/base/grid/MISACol.vue";

import { ref } from "vue";
import employeeApi from "@/api/employee-api";
import departmentApi from "@/api/department-api";
import positionApi from "@/api/position-api";
import formatDate from "@/helper/format-date";
import { convertNumberToCurrency } from "@/helper/convert-currency";
import { useEmployeeStore } from "@/stores/employee-store";
import { useToastStore } from "@/stores/toast-store";
import enums from "@/helper/enum";
import { validator, required } from "@/helper/validator";

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
const loading = ref({
  submit: false,
  submitAndContinue: false,
  form: false,
});

const initialFormData = {
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
};
const formData = ref({ ...initialFormData });

const validatedInputs = ref({
  employeeCode: null,
  fullName: null,
});

/**
 * Description: Hàm xử lý gọi api lấy mã nhân viên mới nhất
 * Author: txphuc (28/06/2023)
 */
const getNewEmployeeCode = async () => {
  try {
    if (employeeStore.mode === enums.form.mode.CREATE) {
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
 * Description: Hàm validate input
 * Author: txphuc (01/07/2023)
 */
const handleValidateInputs = () => {
  try {
    return validateEmployeeCode() && validateFullName();
  } catch (error) {
    console.warn(error);
    return false;
  }
};

/**
 * Description: Hàm validate employee code
 * Author: txphuc (01/07/2023)
 */
const validateEmployeeCode = () => {
  try {
    const result = validator({
      value: formData.value.employeeCode,
      rules: [{ checker: required, errorMsg: "Mã là bắt buộc" }],
    });

    validatedInputs.value.employeeCode = result;
    return !result;
  } catch (error) {
    console.warn(error);
    return false;
  }
};

/**
 * Description: Hàm validate full name
 * Author: txphuc (01/07/2023)
 */
const validateFullName = () => {
  try {
    const result = validator({
      value: formData.value.fullName,
      rules: [{ checker: required, errorMsg: "Tên là bắt buộc" }],
    });

    validatedInputs.value.fullName = result;
    return !result;
  } catch (error) {
    console.warn(error);
    return false;
  }
};

/**
 * Description: Hàm reset lại các input về trạng thái ban đầu
 * Author: txphuc (01/07/2023)
 */
const resetInputs = () => {
  try {
    if (employeeStore.mode === enums.form.mode.CREATE) {
      formData.value = {
        ...initialFormData,
      };

      getNewEmployeeCode();
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Hàm xử lý submit form ở các chế độ create/update
 * Author: txphuc (01/07/2023)
 */
const handleSubmitForm = async (isContinue = true) => {
  try {
    let result = false;

    if (handleValidateInputs()) {
      // Bắt đầu loading
      if (isContinue) {
        loading.value.submitAndContinue = true;
      } else {
        loading.value.submit = true;
      }

      if (employeeStore.mode === enums.form.mode.CREATE) {
        result = await handleCreateEmployee();
      } else if (employeeStore.mode === enums.form.mode.UPDATE) {
        result = await handleUpdateEmployee();
      }
    }

    if (result && isContinue) {
      // Reset intpus và reload bảng
      resetInputs();
      emit("submit");
    } else if (result) {
      // Đóng form và reload lại bảng
      employeeStore.closeForm();
      emit("submit");
    }

    // Tắt loading
    loading.value.submit = false;
    loading.value.submitAndContinue = false;
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Hàm xử lý gọi api tạo nhân viên
 * Author: txphuc (28/06/2023)
 */
const handleCreateEmployee = async () => {
  try {
    if (employeeStore.mode === enums.form.mode.CREATE) {
      const data = {
        ...formData.value,
        gender: Number(formData.value.gender),
        salary: Number(formData.value.salary),
      };

      await employeeApi.create(data);

      // Hiện toast message thành công
      toastStore.pushMessage({
        type: "success",
        title: "Thành công!",
        message: "Thêm nhân viên thành công",
      });

      return true;
    }
  } catch (error) {
    console.warn(error);

    // Hiện dialog báo lỗi
    dialogState.value = {
      active: true,
      type: "error",
      title: "Đã có lỗi",
      description: error?.response?.data?.userMsg,
    };

    return false;
  }
};

/**
 * Description: Hàm load dữ liệu để thực hiện update
 * Author: txphuc (28/06/2023)
 */
const handleLoadDataForUpdate = () => {
  try {
    if (employeeStore.mode === enums.form.mode.UPDATE) {
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
    if (employeeStore.mode === enums.form.mode.UPDATE) {
      const employeeId = employeeStore.currentEmployee.EmployeeId;

      const data = {
        ...formData.value,
        gender: Number(formData.value.gender),
        salary: Number(formData.value.salary),
      };

      await employeeApi.update(employeeId, data);

      // Hiện toast message thành công
      toastStore.pushMessage({
        type: "success",
        title: "Thành công!",
        message: "Cập nhật thành công",
      });

      return true;
    }
  } catch (error) {
    console.warn(error);

    // Hiện dialog báo lỗi
    dialogState.value = {
      active: true,
      type: "error",
      title: "Đã có lỗi",
      description: error?.response?.data?.userMsg,
    };

    return false;
  }
};
</script>

<style scoped></style>
