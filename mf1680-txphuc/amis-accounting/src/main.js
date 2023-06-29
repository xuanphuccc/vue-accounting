import "./assets/css/main.css";

import { createApp } from "vue/dist/vue.esm-bundler";
import router from "./router";
import { createPinia } from "pinia";
import App from "./App.vue";

const pinia = createPinia();
const app = createApp(App);

app.use(pinia);
app.use(router);

/**
 * Description: Sử dụng custom directive để hiện tooltip
 * khi sử dụng cần thêm attribute v-tooltip.top="'Nội dung'"
 * vào element muốn hiện tooltip
 * Author: txphuc (28/06/2023)
 */
app.directive("tooltip", (el, binding) => {
  try {
    el.setAttribute("data-tooltip", binding.value);
    el.classList.add("ms-tooltip");

    if (binding.modifiers.left) {
      el.classList.add("--left");
    } else if (binding.modifiers.right) {
      el.classList.add("--right");
    } else if (binding.modifiers.top) {
      el.classList.add("--top");
    } else {
      el.classList.add("--bottom");
    }
  } catch (error) {
    console.warn(error);
  }
});

app.mount("#app");
