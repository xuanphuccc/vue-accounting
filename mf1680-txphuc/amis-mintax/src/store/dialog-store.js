import enums from "@/enum/enum";

const dialogStore = {
  namespaced: true,

  state: () => ({
    active: false,
    type: enums.dialog.type.INFO,
    title: "Cảnh báo",
    description: "",
  }),

  mutations: {
    /**
     * Description: Set trạng thái đóng/mở cho dialog
     * Author: txphuc (24/08/2023)
     */
    SET_ACTIVE(state, active) {
      state.active = active;
    },

    /**
     * Description: Set loại dialog
     * Author: txphuc (24/08/2023)
     */
    SET_TYPE(state, type) {
      state.type = type;
    },

    /**
     * Description: Set tiêu đề cho dialog
     * Author: txphuc (24/08/2023)
     */
    SET_TITLE(state, title) {
      state.title = title;
    },

    /**
     * Description: Set mô tả cho dialog
     * Author: txphuc (24/08/2023)
     */
    SET_DESCRIPTION(state, description) {
      state.description = description;
    },
  },
  actions: {
    /**
     * Description: Hiện cảnh báo
     * Author: txphuc: (03/08/2023)
     */
    showWarning({ commit }, description) {
      commit("SET_ACTIVE", true);
      commit("SET_TYPE", enums.dialog.type.WARNING);
      commit("SET_TITLE", "Cảnh báo");
      commit("SET_DESCRIPTION", description);
    },

    /**
     * Description: Đóng dialog
     * Author: txphuc: (03/08/2023)
     */
    closeDialog({ commit }) {
      commit("SET_ACTIVE", false);
      commit("SET_TYPE", enums.dialog.type.INFO);
      commit("SET_TITLE", "");
      commit("SET_DESCRIPTION", "");
    },
  },
  getters: {},
};

export default dialogStore;
