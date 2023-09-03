import { extend } from "vee-validate";
import { required, email, numeric } from "vee-validate/dist/rules";
// import { setInteractionMode } from "vee-validate";

// setInteractionMode("lazy");

/**
 * Description: Validate bắt buộc nhập
 * Author: txphuc (02/09/2023)
 */
extend("required", {
  ...required,
  message: "{_field_} không được bỏ trống",
});

/**
 * Description: Validate phải là ký tự số
 * Author: txphuc (02/09/2023)
 */
extend("numeric", {
  ...numeric,
  message: "{_field_} không đúng định dạng",
});

/**
 * Description: Validate định dạng email
 * Author: txphuc (02/09/2023)
 */
extend("email", {
  ...email,
  message: "Email không đúng định dạng",
});

/**
 * Description: Validate định dạng số điện thoại
 * Author: txphuc (02/09/2023)
 */
extend("mobile", {
  validate: (value) => {
    const regex = /^0\d{9}$/;
    return regex.test(value);
  },
  message: "{_field_} không đúng định dạng",
});
