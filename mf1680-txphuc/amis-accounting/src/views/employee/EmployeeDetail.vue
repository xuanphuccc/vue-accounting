<template>
  <Teleport to="#app">
    <MISAPopup
      @close="employeeStore.closeForm"
      @submit="handleSubmitForm()"
      :width="880"
      :title="
        employeeStore.mode === enums.form.mode.CREATE
          ? MISAResource[globalStore.lang].Page.Employee.Form.CreateTitle
          : MISAResource[globalStore.lang].Page.Employee.Form.UpdateTitle
      "
    >
      <template #default>
        <MISARow :gutter="{ x: 24 }">
          <MISACol span="6">
            <MISARow :gutter="{ x: 8 }">
              <MISACol span="5">
                <MISAFormGroup
                  :error-msg="validatedInputs.employeeCode"
                  :label="MISAResource[globalStore.lang].Page.Employee.EmployeeCode.Title"
                  for="input-id"
                  required-mark
                  space-bottom
                >
                  <MISAInput
                    tabindex="1"
                    v-model="formData.employeeCode"
                    @blur="validateEmployeeCode"
                    @input="validatedInputs.employeeCode = null"
                    focus
                    id="input-id"
                    ref="employeeCodeRef"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup
                  :error-msg="validatedInputs.fullName"
                  :label="MISAResource[globalStore.lang].Page.Employee.FullName.Title"
                  for="input-name"
                  required-mark
                  space-bottom
                >
                  <MISAInput
                    tabindex="2"
                    v-model="formData.fullName"
                    @blur="validateFullName"
                    @input="validatedInputs.fullName = null"
                    id="input-name"
                    ref="fullNameRef"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup
                  :error-msg="validatedInputs.department"
                  :label="MISAResource[globalStore.lang].Page.Employee.Department.Title"
                  for="input-department"
                  required-mark
                  space-bottom
                >
                  <MISASelect
                    tabindex="3"
                    v-model="formData.departmentId"
                    @focusout="validateDepartment"
                    :options="departmentOptions"
                    id="input-department"
                    ref="departmentRef"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup
                  :label="MISAResource[globalStore.lang].Page.Employee.Position.Title"
                  for="input-position"
                  space-bottom
                >
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
                <MISAFormGroup
                  :label="MISAResource[globalStore.lang].Page.Employee.DateOfBirth.Title"
                  for="input-date-of-birth"
                  space-bottom
                >
                  <MISAInput
                    tabindex="5"
                    v-model="formData.dateOfBirth"
                    type="date"
                    id="input-date-of-birth"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup
                  :label="MISAResource[globalStore.lang].Page.Employee.Gender.Title"
                  for=""
                  space-bottom
                >
                  <div class="d-flex col-gap-16">
                    <MISARadioButton
                      tabindex="6"
                      v-model="formData.gender"
                      :value="enums.gender.MALE + ''"
                      :label="MISAResource[globalStore.lang].Gender.Male"
                    />
                    <MISARadioButton
                      tabindex="7"
                      v-model="formData.gender"
                      :value="enums.gender.FEMALE + ''"
                      :label="MISAResource[globalStore.lang].Gender.Female"
                    />
                    <MISARadioButton
                      tabindex="8"
                      v-model="formData.gender"
                      :value="enums.gender.OTHER + ''"
                      :label="MISAResource[globalStore.lang].Gender.Other"
                    />
                  </div>
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup
                  v-tooltip.top="MISAResource[globalStore.lang].Page.Employee.IdentityNumber.Desc"
                  :label="MISAResource[globalStore.lang].Page.Employee.IdentityNumber.Title"
                  for="input-identity-number"
                  space-bottom
                >
                  <MISAInput
                    tabindex="9"
                    v-model="formData.identityNumber"
                    id="input-identity-number"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="5">
                <MISAFormGroup
                  :label="MISAResource[globalStore.lang].Page.Employee.IdentityDate.Title"
                  for="input-identity-date"
                  space-bottom
                >
                  <MISAInput
                    tabindex="10"
                    v-model="formData.identityDate"
                    type="date"
                    id="input-identity-date"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup
                  :label="MISAResource[globalStore.lang].Page.Employee.IdentityPlace.Title"
                  for="input-identity-place"
                  space-bottom
                >
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
            <MISAFormGroup
              :label="MISAResource[globalStore.lang].Page.Employee.Address.Title"
              for="input-address"
              space-bottom
            >
              <MISAInput tabindex="12" v-model="formData.address" id="input-address" />
            </MISAFormGroup>
          </MISACol>
        </MISARow>

        <MISARow :gutter="{ x: 8 }">
          <MISACol span="3">
            <MISAFormGroup
              v-tooltip.top="MISAResource[globalStore.lang].Page.Employee.MobilePhone.Desc"
              :label="MISAResource[globalStore.lang].Page.Employee.MobilePhone.Title"
              for="input-mobile-phone"
              space-bottom
            >
              <MISAInput
                tabindex="13"
                v-model="formData.mobilePhoneNumber"
                id="input-mobile-phone"
              />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup
              v-tooltip.top="MISAResource[globalStore.lang].Page.Employee.LandlinePhone.Desc"
              :label="MISAResource[globalStore.lang].Page.Employee.LandlinePhone.Title"
              for="input-landline-phone"
              space-bottom
            >
              <MISAInput
                tabindex="14"
                v-model="formData.landlineNumber"
                id="input-landline-phone"
              />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup
              :label="MISAResource[globalStore.lang].Page.Employee.Email.Title"
              for="input-email"
              space-bottom
            >
              <MISAInput tabindex="15" v-model="formData.email" id="input-email" />
            </MISAFormGroup>
          </MISACol>
        </MISARow>

        <MISARow :gutter="{ x: 8 }">
          <MISACol span="3">
            <MISAFormGroup
              :label="MISAResource[globalStore.lang].Page.Employee.BankAccount.Title"
              for="bank-account"
            >
              <MISAInput tabindex="16" v-model="formData.bankAccount" id="bank-account" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup
              :label="MISAResource[globalStore.lang].Page.Employee.BankName.Title"
              for="bank-name"
            >
              <MISAInput tabindex="17" v-model="formData.bankName" id="bank-name" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup
              :label="MISAResource[globalStore.lang].Page.Employee.BankBranch.Title"
              for="branch"
            >
              <MISAInput tabindex="18" v-model="formData.bankBranch" id="branch" />
            </MISAFormGroup>
          </MISACol>
        </MISARow>
      </template>

      <template #controls-left>
        <MISAButton tabindex="21" @click="employeeStore.closeForm" type="secondary">{{
          MISAResource[globalStore.lang].Button.Cancel
        }}</MISAButton>
      </template>
      <template #controls-right>
        <MISAButton tabindex="20" @click="handleSubmitForm(false)" type="secondary">
          <MISASpinner v-if="loading.submit" absolute />
          <span :style="{ opacity: loading.submit ? 0 : 1 }">{{
            MISAResource[globalStore.lang].Button.Save
          }}</span>
        </MISAButton>
        <MISAButton tabindex="19" @click="handleSubmitForm()" type="primary">
          <MISASpinner v-if="loading.submitAndContinue" absolute />
          <span :style="{ opacity: loading.submitAndContinue ? 0 : 1 }">{{
            MISAResource[globalStore.lang].Button.SaveAndContinue
          }}</span>
        </MISAButton>
      </template>
    </MISAPopup>

    <!-- delete confirm dialog -->
    <MISADialog
      v-if="dialogState.active"
      v-bind="dialogState"
      @cancel="closeDialog"
      @ok="closeDialog"
      :ok-text="MISAResource[globalStore.lang].Button.OK"
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
import { useGlobalStore } from "@/stores/global-store";
import { useEmployeeStore } from "@/stores/employee-store";
import { useToastStore } from "@/stores/toast-store";
import enums from "@/helper/enum";
import MISAResource from "@/helper/resource";
import { validator, required } from "@/helper/validator";

const emit = defineEmits(["submit"]);

const globalStore = useGlobalStore();
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
  positionId: null,
  dateOfBirth: null,
  gender: enums.gender.MALE + "",
  identityNumber: null,
  identityDate: null,
  identityPlace: null,
  address: null,
  mobilePhoneNumber: null,
  landlineNumber: null,
  email: null,
  bankAccount: null,
  bankName: null,
  bankBranch: null,
};
const formData = ref({ ...initialFormData });

const employeeCodeRef = ref(null);
const fullNameRef = ref(null);
const departmentRef = ref(null);

const validatedInputs = ref({
  employeeCode: null,
  fullName: null,
  department: null,
});

/**
 * Description: Hàm xử lý gọi api lấy mã nhân viên mới nhất
 * Author: txphuc (28/06/2023)
 */
const getNewEmployeeCode = async () => {
  try {
    if (
      employeeStore.mode === enums.form.mode.CREATE ||
      employeeStore.mode === enums.form.mode.DUPLICATE
    ) {
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
    return validateEmployeeCode() && validateFullName() && validateDepartment();
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
      rules: [
        {
          checker: required,
          errorMsg: MISAResource[globalStore.lang].Page.Employee.Validate.EmployeeCode,
        },
      ],
    });

    // Focus vào khi lỗi
    if (result) {
      employeeCodeRef.value?.autoFocus();
    }

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
      rules: [
        {
          checker: required,
          errorMsg: MISAResource[globalStore.lang].Page.Employee.Validate.FullName,
        },
      ],
    });

    // Focus vào khi lỗi
    if (result) {
      fullNameRef.value?.autoFocus();
    }

    validatedInputs.value.fullName = result;
    return !result;
  } catch (error) {
    console.warn(error);
    return false;
  }
};

/**
 * Description: Hàm validate department
 * Author: txphuc (01/07/2023)
 */
const validateDepartment = () => {
  try {
    const result = validator({
      value: formData.value.departmentId,
      rules: [
        {
          checker: required,
          errorMsg: MISAResource[globalStore.lang].Page.Employee.Validate.Department,
        },
      ],
    });

    // Focus vào khi lỗi
    if (result) {
      departmentRef.value?.autoFocus();
    }

    validatedInputs.value.department = result;
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
const resetInputs = async () => {
  try {
    if (
      employeeStore.mode === enums.form.mode.CREATE ||
      employeeStore.mode === enums.form.mode.DUPLICATE
    ) {
      if (employeeStore.mode === enums.form.mode.CREATE) {
        formData.value = {
          ...initialFormData,
        };
      }

      await getNewEmployeeCode();
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Hàm xử lý submit form ở các chế độ create/update/duplicate
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
      } else if (employeeStore.mode === enums.form.mode.DUPLICATE) {
        result = await handleDuplicateEmployee();
      }
    }

    if (result && isContinue) {
      // Reset intpus và reload bảng
      await resetInputs();
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
      };

      await employeeApi.create(data);

      // Hiện toast message thành công
      toastStore.pushSuccessMessage({
        message: MISAResource[globalStore.lang].Page.Employee.Toast.CreateSuccess,
      });

      return true;
    }
  } catch (error) {
    console.warn(error);

    // Hiện dialog báo lỗi
    dialogState.value = {
      active: true,
      type: "error",
      title: MISAResource[globalStore.lang].Dialog.ErrorTitle,
      description: error?.response?.data?.UserMessage,
    };

    return false;
  }
};

/**
 * Description: Hàm load dữ liệu để thực hiện update/duplicate
 * Author: txphuc (28/06/2023)
 */
const handleLoadDataForUpdate = async () => {
  try {
    if (
      employeeStore.mode === enums.form.mode.UPDATE ||
      employeeStore.mode === enums.form.mode.DUPLICATE
    ) {
      const employeeId = employeeStore.currentEmployee?.EmployeeId;

      // Gọi API lấy thông tin nhân viên cần sửa
      const response = await employeeApi.get(employeeId);
      const employeeData = response.data;

      // Binding dữ liệu vào form
      formData.value = {
        employeeCode: employeeData.EmployeeCode,
        fullName: employeeData.FullName,
        departmentId: employeeData.DepartmentId,
        positionId: employeeData.PositionId,
        dateOfBirth: formatDate(employeeData.DateOfBirth, "YYYY-MM-DD"),
        gender: employeeData.Gender + "",
        identityNumber: employeeData.IdentityNumber,
        identityDate: formatDate(employeeData.IdentityDate, "YYYY-MM-DD"),
        identityPlace: employeeData.IdentityPlace,
        address: employeeData.Address,
        mobilePhoneNumber: employeeData.MobilePhoneNumber,
        landlineNumber: employeeData.LandlineNumber,
        email: employeeData.Email,
        bankAccount: employeeData.BankAccount,
        bankName: employeeData.BankName,
        bankBranch: employeeData.BankBranch,
      };

      // Lấy mã nhân viên mới để nhân bản
      if (employeeStore.mode === enums.form.mode.DUPLICATE) {
        await getNewEmployeeCode();
      }
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
      };

      await employeeApi.update(employeeId, data);

      // Hiện toast message thành công
      toastStore.pushSuccessMessage({
        message: MISAResource[globalStore.lang].Page.Employee.Toast.UpdateSuccess,
      });

      return true;
    }
  } catch (error) {
    console.warn(error);

    // Hiện dialog báo lỗi
    dialogState.value = {
      active: true,
      type: "error",
      title: MISAResource[globalStore.lang].Dialog.ErrorTitle,
      description: error?.response?.data?.UserMessage,
    };

    return false;
  }
};

/**
 * Description: Hàm xử lý gọi api nhân bản nhân viên
 * Author: txphuc (10/07/2023)
 */
const handleDuplicateEmployee = async () => {
  try {
    if (employeeStore.mode === enums.form.mode.DUPLICATE) {
      const data = {
        ...formData.value,
        gender: Number(formData.value.gender),
      };

      await employeeApi.create(data);

      // Hiện toast message nhân bản thành công
      toastStore.pushSuccessMessage({
        message: MISAResource[globalStore.lang].Page.Employee.Toast.DuplicateSuccess,
      });

      return true;
    }
  } catch (error) {
    console.warn(error);

    // Hiện dialog báo lỗi
    dialogState.value = {
      active: true,
      type: "error",
      title: MISAResource[globalStore.lang].Dialog.ErrorTitle,
      description: error?.response?.data?.UserMessage,
    };

    return false;
  }
};
</script>

<style scoped></style>
