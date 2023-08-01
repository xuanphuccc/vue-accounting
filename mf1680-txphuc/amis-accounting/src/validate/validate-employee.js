import { validator, required, email, codeFormat, maxLength, mobilePhoneFormat } from "./validator";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "@/stores/global-store";

/**
 * Description: Hàm validate employee code
 * Author: txphuc (01/07/2023)
 */
export const validateEmployeeCode = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: required,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.EmployeeCode,
        },
        {
          checker: codeFormat,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.CodeFormat,
        },
        {
          checker: maxLength,
          max: 20,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            20
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate full name
 * Author: txphuc (01/07/2023)
 */
export const validateFullName = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: required,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.FullName,
        },
        {
          checker: maxLength,
          max: 100,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            100
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate department
 * Author: txphuc (01/07/2023)
 */
export const validateDepartment = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: required,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.Department,
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate CMND
 * Author: txphuc (01/08/2023)
 */
export const validateIdentityNumber = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: maxLength,
          max: 25,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            25
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate nơi cấp CMND
 * Author: txphuc (01/08/2023)
 */
export const validateIdentityPlace = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: maxLength,
          max: 255,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            255
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate địa chỉ
 * Author: txphuc (01/08/2023)
 */
export const validateAddress = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: maxLength,
          max: 255,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            255
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate số điện thoại di động
 * Author: txphuc (24/07/2023)
 */
export const validateMobilePhone = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: mobilePhoneFormat,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MobilePhoneFormat,
        },
        {
          checker: maxLength,
          max: 50,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            50
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate số điện thoại cố định
 * Author: txphuc (24/07/2023)
 */
export const validateLandlineNumber = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: mobilePhoneFormat,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MobilePhoneFormat,
        },
        {
          checker: maxLength,
          max: 50,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            50
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate email
 * Author: txphuc (24/07/2023)
 */
export const validateEmail = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: email,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.EmailFormat,
        },
        {
          checker: maxLength,
          max: 100,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            100
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate tài khoản ngân hàng
 * Author: txphuc (01/08/2023)
 */
export const validateBankAccount = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: maxLength,
          max: 25,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            25
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate tên tài khoản ngân hàng
 * Author: txphuc (01/08/2023)
 */
export const validateBankName = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: maxLength,
          max: 255,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            255
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm validate chi nhánh ngân hàng
 * Author: txphuc (01/08/2023)
 */
export const validateBankBranch = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: maxLength,
          max: 255,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Employee?.Validate?.MaxLength?.replace(
            "@char",
            255
          ),
        },
      ],
    });

    return result;
  } catch (error) {
    console.warn(error);
    return "error";
  }
};
