import { defineStore } from "pinia";

export const useGlobalStore = defineStore("app-global", {
  state: () => ({
    sidebar: {
      isCompact: false,
    },
  }),
  getters: {},
  actions: {
    /**
     * Description: Hàm xử lý đóng mở sidebar
     * Author: txphuc (28/06/2023)
     */
    toggleSidebar() {
      this.sidebar.isCompact = !this.sidebar.isCompact;
    },
  },
});
