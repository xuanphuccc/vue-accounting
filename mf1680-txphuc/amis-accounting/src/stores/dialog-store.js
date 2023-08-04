import { defineStore } from "pinia";
import enums from "@/helper/enum";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "./global-store";

export const useDialogStore = defineStore("error-dialog", {
  state: () => ({
    active: false,
    type: enums.dialog.type.WARNING,
    title: "",
    description: "",
  }),
  getters: {},
  actions: {
    /**
     * Description: Hiện cảnh báo
     * Author: txphuc: (03/08/2023)
     */
    showWarning(description) {
      const globalStore = useGlobalStore();

      this.active = true;
      this.type = enums.dialog.type.WARNING;
      this.title = MISAResource[globalStore.lang]?.Dialog?.WarningTitle;
      this.description = description;
    },

    /**
     * Description: Hiện thông báo lỗi
     * Author: txphuc: (03/08/2023)
     */
    showError(description) {
      const globalStore = useGlobalStore();

      this.active = true;
      this.type = enums.dialog.type.ERROR;
      this.title = MISAResource[globalStore.lang]?.Dialog?.ErrorTitle;
      this.description = description;
    },

    /**
     * Description: Đóng dialog
     * Author: txphuc: (03/08/2023)
     */
    closeDialog() {
      this.active = false;
      this.type = enums.dialog.type.WARNING;
      this.title = "";
      this.description = "";
    },
  },
});
