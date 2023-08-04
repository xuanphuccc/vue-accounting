import "./assets/css/main.css";
import "tippy.js/dist/tippy.css";

import { createApp } from "vue/dist/vue.esm-bundler";
import router from "./router";
import { createPinia } from "pinia";
import VueTippy from "vue-tippy";
import App from "./App.vue";
import focusTrapDirective from "./directives/focus-trap";

const pinia = createPinia();
const app = createApp(App);

app.use(pinia);
app.use(router);

app.use(VueTippy, {
  directive: "tippy", // => v-tippy
  defaultProps: {
    delay: [400, 0],
    // placement: "auto-top",
  }, // => Global default options * see all props
});

app.directive("focustrap", focusTrapDirective);

app.mount("#app");
