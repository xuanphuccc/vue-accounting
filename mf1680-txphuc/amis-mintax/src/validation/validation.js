import { extend } from "vee-validate";
import { required, email } from "vee-validate/dist/rules";
// import { setInteractionMode } from "vee-validate";

// setInteractionMode("aggressive");

// extend("even", {
//   validate: (value) => {
//     return value % 2 === 0;
//   },
//   message: "Hello World",
// });

extend("required", {
  ...required,
  message: "{_field_} không được để trống",
});

extend("email", {
  ...email,
  message: "Email không đúng định dạng",
});
