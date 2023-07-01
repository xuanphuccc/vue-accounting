/**
 * Description: Hàm validate inputs
 * Author: txphuc (01/07/2023)
 */
export const validator = (inputs = []) => {
  try {
    const validated = {};

    // Lặp qua các input nếu có 1 rule bất kỳ không thoả mãn
    // thì dừng lặp và trả về lỗi đó
    for (let input of inputs) {
      const key = input.key;
      const value = input.value;
      const rules = input.rules;

      if (Object.keys(validated).length > 0) break;

      for (let rule of rules) {
        const result = rule.checker(value, rule.errorMsg);

        if (result) {
          validated[key] = result;
          break;
        }
      }
    }

    return validated;
  } catch (error) {
    console.warn(error);
    return {};
  }
};

/**
 * Description: Hàm kiểm tra giá trị truyền vào
 * có giá trị hay không
 * Author: txphuc (01/07/2023)
 */
export const required = (value, message) => {
  try {
    if (Array.isArray(value)) {
      return value.length ? null : message || "Vui lòng nhập trường này";
    } else {
      return value ? null : message || "Vui lòng nhập trường này";
    }
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm kiểm tra giá trị truyền vào
 * có phải là định dạng của email hay không
 * Author: txphuc (01/07/2023)
 */
export const email = (value, message) => {
  try {
    var regex =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return regex.test(value) ? null : message || "Vui lòng nhập email";
  } catch (error) {
    console.warn(error);
    return "error";
  }
};

/**
 * Description: Hàm kiểm tra giá trị truyền vào
 * có độ dài lớn hơn giá trị min hay không
 * Author: txphuc (01/07/2023)
 */
export const minLength = (value, min, message) => {
  return value.length >= min ? null : message || `Vui lòng nhập tối thiểu ${min} kí tự`;
};
