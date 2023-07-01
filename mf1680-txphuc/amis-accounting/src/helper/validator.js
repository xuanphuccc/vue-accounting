/**
 * Description: Hàm validate input
 * Author: txphuc (01/07/2023)
 */
export const validator = (input = { value: "", rules: [] }) => {
  try {
    let errorMsg = null;
    for (let rule of input.rules) {
      const message = rule.checker(input.value, rule.errorMsg);

      if (message) {
        errorMsg = message;
        break;
      }
    }

    return errorMsg;
  } catch (error) {
    console.warn(error);
    return "error";
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
