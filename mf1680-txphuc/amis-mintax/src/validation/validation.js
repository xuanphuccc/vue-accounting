import { extend } from "vee-validate";

// extend("even", (value) => {
//   return value % 2 === 0;
// });

extend("even", {
  validate: (value) => {
    return value % 2 === 0;
  },
  message: "Hello World",
});
