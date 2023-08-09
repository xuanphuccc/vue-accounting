<template>
  <Teleport to="#app">
    <MISAPopup
      v-focustrap
      @close="handleCloseForm"
      @submit="handleSubmitForm(false)"
      @submit-and-continue="handleSubmitForm()"
      :width="800"
      :title="departmentStore.title"
    >
      <template #default>
        <MISARow :gutter="{ x: 8 }">
          <MISACol span="6">
            <MISAFormGroup
              :error-msg="errorMessages.departmentCode"
              :label="MISAResource[globalStore.lang]?.Page?.Department.DepartmentCode?.Title"
              for="department-code"
              space-bottom
              required-mark
            >
              <MISAInput
                tabindex="1"
                v-model="formData.departmentCode"
                @blur="
                  errorMessages.departmentCode = validateDepartmentCode(formData.departmentCode)
                "
                @input="errorMessages.departmentCode = null"
                id="department-code"
                ref="departmentCodeRef"
                auto-focus
              />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="6">
            <MISAFormGroup
              :error-msg="errorMessages.departmentName"
              :label="MISAResource[globalStore.lang]?.Page?.Department?.DepartmentName?.Title"
              for="department-name"
              space-bottom
              required-mark
            >
              <MISAInput
                tabindex="2"
                v-model="formData.departmentName"
                @blur="
                  errorMessages.departmentName = validateDepartmentName(formData.departmentName)
                "
                @input="errorMessages.departmentName = null"
                id="department-name"
                ref="departmentNameRef"
              />
            </MISAFormGroup>
          </MISACol>
        </MISARow>

        <MISAFormGroup
          :error-msg="errorMessages.description"
          :label="MISAResource[globalStore.lang]?.Page?.Department?.Description?.Title"
          for="description"
          space-bottom
        >
          <MISAInput
            tabindex="3"
            v-model="formData.description"
            @blur="errorMessages.description = validateDescription(formData.description)"
            @input="errorMessages.description = null"
            id="description"
            ref="descriptionRef"
          />
        </MISAFormGroup>
      </template>

      <template #controls-left>
        <MISAButton
          v-tippy="{ content: 'ESC' }"
          tabindex="6"
          @click="handleCloseForm"
          type="secondary"
          >{{ MISAResource[globalStore.lang]?.Button?.Cancel }}</MISAButton
        >
      </template>
      <template #controls-right>
        <MISAButton
          tabindex="5"
          v-tippy="{ content: 'Ctrl + S' }"
          @click="handleSubmitForm(false)"
          :loading="loading.submit"
          type="secondary"
        >
          {{ MISAResource[globalStore.lang]?.Button?.Save }}
        </MISAButton>
        <MISAButton
          tabindex="4"
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
          <MISAButton @click="departmentStore.closeForm()" tabindex="2" type="secondary">{{
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
import MISARow from "@/components/base/grid/MISARow.vue";
import MISACol from "@/components/base/grid/MISACol.vue";

import departmentApi from "@/api/department-api";
import { useGlobalStore } from "@/stores/global-store";
import { useDepartmentStore } from "@/stores/department-store";
import { useToastStore } from "@/stores/toast-store";
import enums from "@/enum/enum";
import MISAResource from "@/resource/resource";

import {
  validateDepartmentCode,
  validateDepartmentName,
  validateDescription,
} from "@/validate/validate-department";

const emit = defineEmits(["submit"]);

// ---- Store ----
const globalStore = useGlobalStore();
const departmentStore = useDepartmentStore();
const toastStore = useToastStore();

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
  departmentCode: "",
  departmentName: "",
  description: null,
};
const formData = ref({ ...initialFormData });

// ---- Thông báo lỗi validate ----
const errorMessages = ref({
  departmentCode: "",
  departmentName: "",
  description: "",
});

// ---- Ref của các input cần validate ----
const departmentCodeRef = ref(null);
const departmentNameRef = ref(null);
const descriptionRef = ref(null);

const modifiedInput = ref(false);
const isLoadData = ref(false);

/**
 * Description: Hàm xử lý gọi api lấy mã đơn vị mới nhất
 * Author: txphuc (28/06/2023)
 */
const getNewDepartmentCode = async () => {
  try {
    if (
      departmentStore.mode === enums.form.mode.CREATE ||
      departmentStore.mode === enums.form.mode.DUPLICATE
    ) {
      const response = await departmentApi.getNewCode();

      formData.value.departmentCode = response.data;

      // Tránh thay đổi trạng thái của form
      isLoadData.value = true;
    }
  } catch (error) {
    console.warn(error);
  }
};
getNewDepartmentCode();

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
    departmentStore.closeForm();
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
        value: formData.value.departmentCode,
        validator: validateDepartmentCode,
        ref: departmentCodeRef.value,
        errorIndex: "departmentCode",
      },
      {
        value: formData.value.departmentName,
        validator: validateDepartmentName,
        ref: departmentNameRef.value,
        errorIndex: "departmentName",
      },
      {
        value: formData.value.description,
        validator: validateDescription,
        ref: descriptionRef.value,
        errorIndex: "description",
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
    departmentStore.mode === enums.form.mode.CREATE ||
    departmentStore.mode === enums.form.mode.DUPLICATE
  ) {
    if (departmentStore.mode === enums.form.mode.CREATE) {
      // Reset dữ liệu form về mặc định
      formData.value = {
        ...initialFormData,
      };
    }

    // Lấy mã mới
    await getNewDepartmentCode();
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

      if (departmentStore.mode === enums.form.mode.CREATE) {
        result = await handleCreateDepartment();
      } else if (departmentStore.mode === enums.form.mode.UPDATE) {
        result = await handleUpdateDepartment();

        if (result) {
          // Reset lại trạng thái form
          modifiedInput.value = false;
        }
      } else if (departmentStore.mode === enums.form.mode.DUPLICATE) {
        result = await handleDuplicateDepartment();
      }
    }

    if (result && isContinue) {
      // Reset intpus và reload bảng
      await resetInputs();
      emit("submit");

      // Focus vào ô đầu tiên
      if (departmentCodeRef.value) {
        departmentCodeRef.value.focus();
      }
    } else if (result) {
      // Đóng form và reload lại bảng
      departmentStore.closeForm();
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
  };

  return data;
};

/**
 * Description: Hàm xử lý gọi api tạo đơn vị
 * Author: txphuc (28/06/2023)
 */
const handleCreateDepartment = async () => {
  try {
    if (departmentStore.mode === enums.form.mode.CREATE) {
      const data = generateData();

      await departmentApi.create(data);

      // Hiện toast message thành công
      toastStore.pushSuccessMessage({
        message: MISAResource[globalStore.lang]?.Page?.Department?.Toast?.CreateSuccess,
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
      departmentStore.mode === enums.form.mode.UPDATE ||
      departmentStore.mode === enums.form.mode.DUPLICATE
    ) {
      const departmentId = departmentStore.currentDepartment?.DepartmentId;

      // Gọi API lấy thông tin đơn vị cần sửa
      const response = await departmentApi.get(departmentId);
      const departmentData = response.data;

      // Binding dữ liệu vào form
      formData.value = {
        departmentCode: departmentData.DepartmentCode,
        departmentName: departmentData.DepartmentName,
        description: departmentData.Description,
      };

      // Tránh thay đổi trạng thái của form
      isLoadData.value = true;

      // Lấy mã đơn vị mới để nhân bản
      if (departmentStore.mode === enums.form.mode.DUPLICATE) {
        await getNewDepartmentCode();
      }
    }
  } catch (error) {
    console.warn(error);
  }
};
handleLoadDataForUpdate();

/**
 * Description: Hàm xử lý gọi api cập nhật đơn vị
 * Author: txphuc (28/06/2023)
 */
const handleUpdateDepartment = async () => {
  try {
    if (departmentStore.mode === enums.form.mode.UPDATE) {
      const departmentId = departmentStore.currentDepartment.DepartmentId;

      const data = generateData();

      await departmentApi.update(departmentId, data);

      // Hiện toast message thành công
      toastStore.pushSuccessMessage({
        message: MISAResource[globalStore.lang]?.Page?.Department?.Toast?.UpdateSuccess,
      });

      return true;
    }
  } catch (error) {
    console.warn(error);

    return false;
  }
};

/**
 * Description: Hàm xử lý gọi api nhân bản đơn vị
 * Author: txphuc (10/07/2023)
 */
const handleDuplicateDepartment = async () => {
  try {
    if (departmentStore.mode === enums.form.mode.DUPLICATE) {
      const data = generateData();

      await departmentApi.create(data);

      // Hiện toast message nhân bản thành công
      toastStore.pushSuccessMessage({
        message: MISAResource[globalStore.lang]?.Page?.Department?.Toast?.DuplicateSuccess,
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
