import { validator, required, codeFormat, maxLength } from "./validator";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "@/stores/global-store";

/**
 * Description: Hàm validate department code
 * Author: txphuc (01/07/2023)
 */
export const validateDepartmentCode = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: required,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Department?.Validate?.DepartmentCode,
        },
        {
          checker: codeFormat,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Department?.Validate?.CodeFormat,
        },
        {
          checker: maxLength,
          max: 20,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Department?.Validate?.MaxLength?.replace(
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
 * Description: Hàm validate department name
 * Author: txphuc (01/07/2023)
 */
export const validateDepartmentName = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: required,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Department?.Validate?.DepartmentName,
        },
        {
          checker: maxLength,
          max: 100,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Department?.Validate?.MaxLength?.replace(
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
 * Description: Hàm validate description
 * Author: txphuc (01/07/2023)
 */
export const validateDescription = (value) => {
  try {
    const globalStore = useGlobalStore();

    const result = validator({
      value: value,
      rules: [
        {
          checker: maxLength,
          max: 255,
          errorMsg: MISAResource[globalStore.lang]?.Page?.Department?.Validate?.MaxLength?.replace(
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
