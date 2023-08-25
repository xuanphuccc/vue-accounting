const commonStore = {
  namespaced: true,

  state: () => ({
    // Trạng thái đóng/mở sidebar
    isCompactSidebar: false,

    // Trạng thái tải dữ liệu
    loading: false,
  }),
  mutations: {
    /**
     * Description: Thu gọn/mở rộng sidebar
     * Author: txphuc (15/08/2023)
     */
    TOGGLE_SIDEBAR(state) {
      state.isCompactSidebar = !state.isCompactSidebar;
    },

    /**
     * Description: Set trạng thái loading
     * Author: txphuc (25/08/2023)
     */
    SET_LOADING(state, loading) {
      state.loading = loading;
    },
  },
  actions: {
    /**
     * Description: Set trạng thái loading
     * Author: txphuc (25/08/2023)
     */
    setLoading({ commit }, loading) {
      if (loading == true) {
        commit("SET_LOADING", loading);
      } else {
        setTimeout(() => {
          commit("SET_LOADING", loading);
        }, 500);
      }
    },

    /**
     * Description: Thu gọn/mở rộng sidebar
     * Author: txphuc (15/08/2023)
     */
    toggleSidebar({ commit }) {
      commit("TOGGLE_SIDEBAR");
    },
  },
  getters: {},
};

export default commonStore;
