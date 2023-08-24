import Vue from "vue";
import Vuex from "vuex";
import commonStore from "./common-store";
import employeeStore from "./employee-store";
import toastStore from "./toast-store";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    commonStore,
    employeeStore,
    toastStore,
  },
});
