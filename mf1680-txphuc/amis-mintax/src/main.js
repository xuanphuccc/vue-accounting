import "devextreme/dist/css/dx.light.css";
import "@/assets/css/main.scss";
import "@/validation/validation";

import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import i18n from "./i18n";

import "floating-vue/dist/style.css";
import FloatingVue from "floating-vue";
import { VTooltip } from "floating-vue";
Vue.use(FloatingVue, {
  distance: 12,
});
Vue.directive("tooltip", VTooltip);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  i18n,
  render: (h) => h(App),
}).$mount("#app");
