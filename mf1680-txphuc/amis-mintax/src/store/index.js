import Vue from "vue";
import Vuex from "vuex";
import commonStore from "./common-store";
import employeeRelationshipStore from "./employee-relationship-store";
import toastStore from "./toast-store";
import dialogStore from "./dialog-store";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    commonStore,
    employeeRelationshipStore,
    toastStore,
    dialogStore,
  },
});
