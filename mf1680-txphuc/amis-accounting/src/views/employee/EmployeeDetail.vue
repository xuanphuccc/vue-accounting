<template>
  <Teleport to="#app">
    <MISAPopup
      v-focustrap
      @close="handleCloseForm"
      @submit="handleSubmitForm(false)"
      @submit-and-continue="handleSubmitForm()"
      :width="880"
      :title="employeeStore.title"
    >
      <template #header-controls>
        <MISACheckboxVue
          tabindex="22"
          v-model="formData.isCustomer"
          :value="true"
          :checked="formData.isCustomer"
          :label="MISAResource[globalStore.lang]?.Page?.Employee?.IsCustomer?.Title"
        />
        <MISACheckboxVue
          tabindex="23"
          v-model="formData.isSupplier"
          :value="true"
          :checked="formData.isSupplier"
          :label="MISAResource[globalStore.lang]?.Page?.Employee?.IsSupplier?.Title"
        />
      </template>

      <template #default>
        <MISARow :gutter="{ x: 24 }">
          <MISACol span="6">
            <MISARow :gutter="{ x: 8 }">
              <MISACol span="5">
                <MISAFormGroup
                  :error-msg="errorMessages.employeeCode"
                  :label="MISAResource[globalStore.lang]?.Page?.Employee?.EmployeeCode?.Title"
                  for="employee-code"
                  required-mark
                  space-bottom
                >
                  <MISAInput
                    tabindex="1"
                    v-model="formData.employeeCode"
                    @blur="errorMessages.employeeCode = validateEmployeeCode(formData.employeeCode)"
                    @input="errorMessages.employeeCode = null"
                    id="employee-code"
                    auto-focus
                    ref="employeeCodeRef"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup
                  :error-msg="errorMessages.fullName"
                  :label="MISAResource[globalStore.lang]?.Page?.Employee?.FullName?.Title"
                  for="full-name"
                  required-mark
                  space-bottom
                >
                  <MISAInput
                    tabindex="2"
                    v-model="formData.fullName"
                    @blur="errorMessages.fullName = validateFullName(formData.fullName)"
                    @input="errorMessages.fullName = null"
                    id="full-name"
                    ref="fullNameRef"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup
                  :error-msg="errorMessages.departmentId"
                  :label="MISAResource[globalStore.lang]?.Page?.Employee?.Department?.Title"
                  for="input-department"
                  required-mark
                  space-bottom
                >
                  <MISASelect
                    tabindex="3"
                    v-model="formData.departmentId"
                    @close="errorMessages.departmentId = validateDepartment(formData.departmentId)"
                    :options="departmentOptions"
                    id="input-department"
                    :placeholder="MISAResource[globalStore.lang]?.PlaceHolder?.SelectAValue"
                    clear-icon
                    ref="departmentRef"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup
                  :label="MISAResource[globalStore.lang]?.Page?.Employee?.Position?.Title"
                  for="input-position"
                  space-bottom
                >
                  <MISASelect
                    tabindex="4"
                    v-model="formData.positionId"
                    :options="positionOptions"
                    :search="true"
                    id="input-position"
                    :placeholder="MISAResource[globalStore.lang]?.PlaceHolder?.SelectAValue"
                  />
                </MISAFormGroup>
              </MISACol>
            </MISARow>
          </MISACol>
          <MISACol span="6">
            <MISARow :gutter="{ x: 8 }">
              <MISACol span="5">
                <MISAFormGroup
                  :label="MISAResource[globalStore.lang]?.Page?.Employee?.DateOfBirth?.Title"
                  for="input-date-of-birth"
                  space-bottom
                >
                  <MISADatePicker
                    tabindex="5"
                    v-model="formData.dateOfBirth"
                    :max-date="new Date()"
                    position="left"
                    id="input-date-of-birth"
                  />
                  <!-- {{ console.log(formData.dateOfBirth) }} -->
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup
                  :label="MISAResource[globalStore.lang]?.Page?.Employee?.Gender?.Title"
                  for=""
                  space-bottom
                >
                  <div class="d-flex col-gap-16">
                    <MISARadioButton
                      tabindex="6"
                      v-model="formData.gender"
                      :value="enums.gender.MALE + ''"
                      :label="MISAResource[globalStore.lang]?.Gender?.Male"
                    />
                    <MISARadioButton
                      tabindex="7"
                      v-model="formData.gender"
                      :value="enums.gender.FEMALE + ''"
                      :label="MISAResource[globalStore.lang]?.Gender?.Female"
                    />
                    <MISARadioButton
                      tabindex="8"
                      v-model="formData.gender"
                      :value="enums.gender.OTHER + ''"
                      :label="MISAResource[globalStore.lang]?.Gender?.Other"
                    />
                  </div>
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup
                  :error-msg="errorMessages.identityNumber"
                  :tooltip="MISAResource[globalStore.lang]?.Page?.Employee?.IdentityNumber?.Desc"
                  :label="MISAResource[globalStore.lang]?.Page?.Employee?.IdentityNumber?.Title"
                  for="input-identity-number"
                  space-bottom
                >
                  <MISAInput
                    tabindex="9"
                    v-model="formData.identityNumber"
                    @blur="
                      errorMessages.identityNumber = validateIdentityNumber(formData.identityNumber)
                    "
                    @input="errorMessages.identityNumber = null"
                    id="input-identity-number"
                    ref="identityNumberRef"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="5">
                <MISAFormGroup
                  :label="MISAResource[globalStore.lang]?.Page?.Employee?.IdentityDate?.Title"
                  for="input-identity-date"
                  space-bottom
                >
                  <MISADatePicker
                    tabindex="10"
                    v-model="formData.identityDate"
                    :max-date="new Date()"
                    position="right"
                    id="input-identity-date"
                  />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup
                  :error-msg="errorMessages.identityPlace"
                  :label="MISAResource[globalStore.lang]?.Page?.Employee?.IdentityPlace?.Title"
                  for="input-identity-place"
                  space-bottom
                >
                  <MISAInput
                    tabindex="11"
                    v-model="formData.identityPlace"
                    @blur="
                      errorMessages.identityPlace = validateIdentityPlace(formData.identityPlace)
                    "
                    @input="errorMessages.identityPlace = null"
                    id="input-identity-place"
                    ref="identityPlaceRef"
                  />
                </MISAFormGroup>
              </MISACol>
            </MISARow>
          </MISACol>
        </MISARow>

        <MISARow :gutter="{ x: 8 }">
          <MISACol span="12">
            <MISAFormGroup
              :error-msg="errorMessages.address"
              :label="MISAResource[globalStore.lang]?.Page?.Employee?.Address?.Title"
              for="input-address"
              space-bottom
            >
              <MISAInput
                tabindex="12"
                v-model="formData.address"
                @blur="errorMessages.address = validateAddress(formData.address)"
                @input="errorMessages.address = null"
                id="input-address"
                ref="addressRef"
              />
            </MISAFormGroup>
          </MISACol>
        </MISARow>

        <MISARow :gutter="{ x: 8 }">
          <MISACol span="3">
            <MISAFormGroup
              :tooltip="MISAResource[globalStore.lang]?.Page?.Employee?.MobilePhone?.Desc"
              :error-msg="errorMessages.mobilePhoneNumber"
              :label="MISAResource[globalStore.lang]?.Page?.Employee?.MobilePhone?.Title"
              for="input-mobile-phone"
              space-bottom
            >
              <MISAInput
                tabindex="13"
                v-model="formData.mobilePhoneNumber"
                @blur="
                  errorMessages.mobilePhoneNumber = validateMobilePhone(formData.mobilePhoneNumber)
                "
                @input="errorMessages.mobilePhoneNumber = null"
                id="input-mobile-phone"
                ref="mobilePhoneNumberRef"
              />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup
              :tooltip="MISAResource[globalStore.lang]?.Page?.Employee?.LandlinePhone?.Desc"
              :error-msg="errorMessages.landlineNumber"
              :label="MISAResource[globalStore.lang]?.Page?.Employee?.LandlinePhone?.Title"
              for="input-landline-phone"
              space-bottom
            >
              <MISAInput
                tabindex="14"
                v-model="formData.landlineNumber"
                @blur="
                  errorMessages.landlineNumber = validateLandlineNumber(formData.landlineNumber)
                "
                @input="errorMessages.landlineNumber = null"
                id="input-landline-phone"
                ref="landlineNumberRef"
              />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup
              :error-msg="errorMessages.email"
              :label="MISAResource[globalStore.lang]?.Page?.Employee?.Email?.Title"
              for="input-email"
              space-bottom
            >
              <MISAInput
                tabindex="15"
                v-model="formData.email"
                @blur="errorMessages.email = validateEmail(formData.email)"
                @input="errorMessages.email = null"
                id="input-email"
                ref="emailRef"
              />
            </MISAFormGroup>
          </MISACol>
        </MISARow>

        <MISARow :gutter="{ x: 8 }">
          <MISACol span="3">
            <MISAFormGroup
              :error-msg="errorMessages.bankAccount"
              :label="MISAResource[globalStore.lang]?.Page?.Employee?.BankAccount?.Title"
              for="bank-account"
              space-bottom
            >
              <MISAInput
                tabindex="16"
                v-model="formData.bankAccount"
                @blur="errorMessages.bankAccount = validateBankAccount(formData.bankAccount)"
                @input="errorMessages.bankAccount = null"
                id="bank-account"
                ref="bankAccountRef"
              />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup
              :error-msg="errorMessages.bankName"
              :label="MISAResource[globalStore.lang]?.Page?.Employee?.BankName?.Title"
              for="bank-name"
              space-bottom
            >
              <MISAInput
                tabindex="17"
                v-model="formData.bankName"
                @blur="errorMessages.bankName = validateBankName(formData.bankName)"
                @input="errorMessages.bankName = null"
                id="bank-name"
                ref="bankNameRef"
              />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup
              :error-msg="errorMessages.bankBranch"
              :label="MISAResource[globalStore.lang]?.Page?.Employee?.BankBranch?.Title"
              for="branch"
              space-bottom
            >
              <MISAInput
                tabindex="18"
                v-model="formData.bankBranch"
                @blur="errorMessages.bankBranch = validateBankBranch(formData.bankBranch)"
                @input="errorMessages.bankBranch = null"
                id="branch"
                ref="bankBranchRef"
              />
            </MISAFormGroup>
          </MISACol>
        </MISARow>
      </template>

      <template #controls-left>
        <MISAButton
          v-tippy="{ content: 'ESC' }"
          tabindex="21"
          @click="handleCloseForm"
          type="secondary"
          >{{ MISAResource[globalStore.lang]?.Button?.Cancel }}</MISAButton
        >
      </template>
      <template #controls-right>
        <MISAButton
          tabindex="20"
          v-tippy="{ content: 'Ctrl + S' }"
          @click="handleSubmitForm(false)"
          :loading="loading.submit"
          type="secondary"
        >
          {{ MISAResource[globalStore.lang]?.Button?.Save }}
        </MISAButton>
        <MISAButton
          tabindex="19"
          v-tippy="{ content: 'Ctrl + Shift + S' }"
          @click="handleSubmitForm()"
          :loading="loading.submitAndContinue"
          type="primary"
        >
          {{ MISAResource[globalStore.lang]?.Button?.SaveAndContinue }}
        </MISAButton>
      </template>
    </MISAPopup>

    <!-- dialog cảnh bảo đóng form -->
    <Teleport to="#app">
      <MISADialog
        v-if="closeFormDialogState.active"
        @cancel="closeDialog"
        v-bind="closeFormDialogState"
      >
        <template #left-controls>
          <MISAButton tabindex="3" @click="closeDialog" type="secondary">{{
            MISAResource[globalStore.lang]?.Button?.Cancel
          }}</MISAButton>
        </template>
        <template #right-controls>
          <MISAButton @click="employeeStore.closeForm()" tabindex="2" type="secondary">{{
            MISAResource[globalStore.lang]?.Button?.No
          }}</MISAButton>
          <MISAButton @click="confirmChangeOnCloseForm" tabindex="1" auto-focus type="primary">{{
            MISAResource[globalStore.lang]?.Button?.Yes
          }}</MISAButton>
        </template>
      </MISADialog>
    </Teleport>
  </Teleport>
</template>

<script setup>
import { ref, watch } from "vue";

import MISAPopup from "@/components/base/popup/MISAPopup.vue";
import MISADialog from "@/components/base/dialog/MISADialog.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISAFormGroup from "@/components/base/input/MISAFormGroup.vue";
import MISAInput from "@/components/base/input/MISAInput.vue";
import MISADatePicker from "@/components/base/date-picker/MISADatePicker.vue";
import MISARadioButton from "@/components/base/radio-button/MISARadioButton.vue";
import MISACheckboxVue from "@/components/base/checkbox/MISACheckbox.vue";
import MISASelect from "@/components/base/select/MISASelect.vue";
import MISARow from "@/components/base/grid/MISARow.vue";
import MISACol from "@/components/base/grid/MISACol.vue";

import employeeApi from "@/api/employee-api";
import departmentApi from "@/api/department-api";
import positionApi from "@/api/position-api";
import formatDate from "@/helper/format-date";
import { useGlobalStore } from "@/stores/global-store";
import { useEmployeeStore } from "@/stores/employee-store";
import { useToastStore } from "@/stores/toast-store";
import enums from "@/enum/enum";
import MISAResource from "@/resource/resource";

import {
  validateEmployeeCode,
  validateFullName,
  validateDepartment,
  validateIdentityNumber,
  validateIdentityPlace,
  validateAddress,
  validateMobilePhone,
  validateLandlineNumber,
  validateEmail,
  validateBankAccount,
  validateBankName,
  validateBankBranch,
} from "@/validate/validate-employee";

const emit = defineEmits(["submit"]);

// ---- Store ----
const globalStore = useGlobalStore();
const employeeStore = useEmployeeStore();
const toastStore = useToastStore();

// ---- Data for combobox ----
const departmentOptions = ref([]);
const positionOptions = ref([]);

// ---- Dialog ----
const closeFormDialogState = ref({
  active: false,
  type: enums.dialog.type.WARNING,
  title: MISAResource[globalStore.lang]?.Dialog?.WarningTitle,
  description: MISAResource[globalStore.lang]?.Dialog?.CloseFormWarning,
});

// ---- Loading ----
const loading = ref({
  submit: false,
  submitAndContinue: false,
  form: false,
});

// ---- Form data ----
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
  isCustomer: false,
  isSupplier: false,
  address: null,
  mobilePhoneNumber: null,
  landlineNumber: null,
  email: null,
  bankAccount: null,
  bankName: null,
  bankBranch: null,
};
const formData = ref({ ...initialFormData });

// ---- Thông báo lỗi validate ----
const errorMessages = ref({
  employeeCode: null,
  fullName: null,
  departmentId: null,
  identityNumber: null,
  identityPlace: null,
  address: null,
  mobilePhoneNumber: null,
  landlineNumber: null,
  email: null,
  bankAccount: null,
  bankName: null,
  bankBranch: null,
});

// ---- Ref của các input cần validate ----
const employeeCodeRef = ref(null);
const fullNameRef = ref(null);
const departmentRef = ref(null);
const identityNumberRef = ref(null);
const identityPlaceRef = ref(null);
const addressRef = ref(null);
const mobilePhoneNumberRef = ref(null);
const landlineNumberRef = ref(null);
const emailRef = ref(null);
const bankAccountRef = ref(null);
const bankNameRef = ref(null);
const bankBranchRef = ref(null);

const modifiedInput = ref(false);
const isLoadData = ref(false);

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

      // Tránh thay đổi trạng thái của form
      isLoadData.value = true;
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
 * Description: Bắt sự thay đổi của các ô input
 * để cảnh báo khi người dùng thoát form mà không cất
 * Author: txphuc (01/08/2023)
 */
watch(
  () => formData.value,
  () => {
    if (isLoadData.value) {
      isLoadData.value = false;

      // Reset trạng thái thay đổi form
      modifiedInput.value = false;
    } else {
      modifiedInput.value = true;
    }
  },
  { deep: true }
);

/**
 * Description: Xử lý đóng form
 * Author: txphuc (01/08/2023)
 */
const handleCloseForm = () => {
  if (modifiedInput.value) {
    // Hiện cảnh báo khi form đã thay đổi mà chưa được lưu
    closeFormDialogState.value.active = true;
  } else {
    employeeStore.closeForm();
  }
};

/**
 * Description: Hàm đóng dialog
 * Author: txphuc (29/06/2023)
 */
const closeDialog = () => {
  closeFormDialogState.value.active = false;
};

/**
 * Description: Xử lý khi người dùng xác nhận lưu thay đổi khi đóng form
 * Author: txphuc (01/08/2023)
 */
const confirmChangeOnCloseForm = () => {
  // Đóng dialog
  closeDialog();

  // Submit dữ liệu
  handleSubmitForm(false);
};

/**
 * Description: Hàm validate input
 * Author: txphuc (01/07/2023)
 */
const handleValidateInputs = () => {
  try {
    const inputRefs = [
      {
        value: formData.value.employeeCode,
        validator: validateEmployeeCode,
        ref: employeeCodeRef.value,
        errorIndex: "employeeCode",
      },
      {
        value: formData.value.fullName,
        validator: validateFullName,
        ref: fullNameRef.value,
        errorIndex: "fullName",
      },
      {
        value: formData.value.departmentId,
        validator: validateDepartment,
        ref: departmentRef.value,
        errorIndex: "departmentId",
      },
      {
        value: formData.value.identityNumber,
        validator: validateIdentityNumber,
        ref: identityNumberRef.value,
        errorIndex: "identityNumber",
      },
      {
        value: formData.value.identityPlace,
        validator: validateIdentityPlace,
        ref: identityPlaceRef.value,
        errorIndex: "identityPlace",
      },
      {
        value: formData.value.address,
        validator: validateAddress,
        ref: addressRef.value,
        errorIndex: "address",
      },
      {
        value: formData.value.mobilePhoneNumber,
        validator: validateMobilePhone,
        ref: mobilePhoneNumberRef.value,
        errorIndex: "mobilePhoneNumber",
      },
      {
        value: formData.value.landlineNumber,
        validator: validateLandlineNumber,
        ref: landlineNumberRef.value,
        errorIndex: "landlineNumber",
      },
      {
        value: formData.value.email,
        validator: validateEmail,
        ref: emailRef.value,
        errorIndex: "email",
      },
      {
        value: formData.value.bankAccount,
        validator: validateBankAccount,
        ref: bankAccountRef.value,
        errorIndex: "bankAccount",
      },
      {
        value: formData.value.bankName,
        validator: validateBankName,
        ref: bankNameRef.value,
        errorIndex: "bankName",
      },
      {
        value: formData.value.bankBranch,
        validator: validateBankBranch,
        ref: bankBranchRef.value,
        errorIndex: "bankBranch",
      },
    ];

    // Chứa tất cả thông báo lỗi
    const errorMessagesObj = {};

    // Kết quả validate toàn bộ input
    let result = true;

    // Đánh dấu chỉ một input lỗi được focus
    let focusFlag = 0;

    inputRefs.forEach((input) => {
      const message = input.validator(input.value);

      // Lấy thông báo lỗi
      errorMessagesObj[input.errorIndex] = message;

      if (message) {
        if (input.ref && focusFlag !== 1) {
          // Focus vào input lỗi đầu tiên
          input.ref.focus();
          focusFlag = 1;
        }

        result = false;
      }
    });

    // Hiển thị tất cả thông báo lỗi
    errorMessages.value = errorMessagesObj;

    return result;
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
  if (
    employeeStore.mode === enums.form.mode.CREATE ||
    employeeStore.mode === enums.form.mode.DUPLICATE
  ) {
    if (employeeStore.mode === enums.form.mode.CREATE) {
      // Reset dữ liệu form về mặc định
      formData.value = {
        ...initialFormData,
      };
    }

    // Lấy mã mới
    await getNewEmployeeCode();
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

        if (result) {
          // Reset lại trạng thái form
          modifiedInput.value = false;
        }
      } else if (employeeStore.mode === enums.form.mode.DUPLICATE) {
        result = await handleDuplicateEmployee();
      }
    }

    if (result && isContinue) {
      // Reset intpus và reload bảng
      await resetInputs();
      emit("submit");

      // Focus vào ô đầu tiên
      if (employeeCodeRef.value) {
        employeeCodeRef.value.focus();
      }
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
 * Description: Xử lý format data trước khi gửi
 * Author: txphuc (17/07/2023)
 */
const generateData = () => {
  const data = {
    ...formData.value,
    employeeCode: formData.value.employeeCode.trim(),
    dateOfBirth: formatDate(formData.value.dateOfBirth, "YYYY-MM-DD"),
    identityDate: formatDate(formData.value.identityDate, "YYYY-MM-DD"),
    gender: Number(formData.value.gender),
  };

  return data;
};

/**
 * Description: Hàm xử lý gọi api tạo nhân viên
 * Author: txphuc (28/06/2023)
 */
const handleCreateEmployee = async () => {
  try {
    if (employeeStore.mode === enums.form.mode.CREATE) {
      const data = generateData();

      await employeeApi.create(data);

      // Hiện toast message thành công
      toastStore.pushSuccessMessage({
        message: MISAResource[globalStore.lang]?.Page?.Employee?.Toast?.CreateSuccess,
      });

      return true;
    }
  } catch (error) {
    console.warn(error);

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
        dateOfBirth: employeeData.DateOfBirth && new Date(employeeData.DateOfBirth),
        gender: employeeData.Gender + "",
        identityNumber: employeeData.IdentityNumber,
        identityDate: employeeData.IdentityDate && new Date(employeeData.IdentityDate),
        identityPlace: employeeData.IdentityPlace,
        isCustomer: employeeData.IsCustomer,
        isSupplier: employeeData.IsSupplier,
        address: employeeData.Address,
        mobilePhoneNumber: employeeData.MobilePhoneNumber,
        landlineNumber: employeeData.LandlineNumber,
        email: employeeData.Email,
        bankAccount: employeeData.BankAccount,
        bankName: employeeData.BankName,
        bankBranch: employeeData.BankBranch,
      };

      // Tránh thay đổi trạng thái của form
      isLoadData.value = true;

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

      const data = generateData();

      await employeeApi.update(employeeId, data);

      // Hiện toast message thành công
      toastStore.pushSuccessMessage({
        message: MISAResource[globalStore.lang]?.Page?.Employee?.Toast?.UpdateSuccess,
      });

      return true;
    }
  } catch (error) {
    console.warn(error);

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
      const data = generateData();

      await employeeApi.create(data);

      // Hiện toast message nhân bản thành công
      toastStore.pushSuccessMessage({
        message: MISAResource[globalStore.lang]?.Page?.Employee?.Toast?.DuplicateSuccess,
      });

      return true;
    }
  } catch (error) {
    console.warn(error);

    return false;
  }
};
</script>

<style scoped></style>
