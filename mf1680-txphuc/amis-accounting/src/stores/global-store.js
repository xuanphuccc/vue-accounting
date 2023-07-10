import { defineStore } from "pinia";
import enums from "@/helper/enum";

export const useGlobalStore = defineStore("app-global", {
  state: () => ({
    lang: enums.language.VN,
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
