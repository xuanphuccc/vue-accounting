import { defineStore } from "pinia";
import { v4 as uuidv4 } from "uuid";
import MISAResource from "@/helper/resource";
import { useGlobalStore } from "./global-store";

export const useToastStore = defineStore("toast-message", {
  state: () => ({
    toastArr: [],
  }),
  getters: {},
  actions: {
    /**
     * Description: Đẩy lên một toast message mới
     * Author: txphuc (29/06/2023)
     */
    pushSuccessMessage(message = { message: "Nội dung thông báo", undo: null }) {
      try {
        const globalStore = useGlobalStore();

        message.key = uuidv4();
        message.type = "success";
        message.title = MISAResource[globalStore.lang]?.Toast?.Success;

        this.toastArr.push(message);

        setTimeout(() => {
          this.removeMessage(message.key);
        }, 5000);
      } catch (error) {
        console.warn(error);
      }
    },

    /**
     * Description: Xoá một toast message khỏi danh sách
     * Author: txphuc (29/06/2023)
     */
    removeMessage(messageKey) {
      this.toastArr = this.toastArr.filter((toast) => toast.key != messageKey);
    },
  },
});
