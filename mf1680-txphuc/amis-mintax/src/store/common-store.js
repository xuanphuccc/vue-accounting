const commonStore = {
  state: () => ({
    isCompactSidebar: false,
  }),
  mutations: {
    /**
     * Description: Thu gọn/mở rộng sidebar
     * Author: txphuc (15/08/2023)
     */
    toggleSidebar(state) {
      state.isCompactSidebar = !state.isCompactSidebar;
    },
  },
  actions: {},
  getters: {},
};

export default commonStore;
