import { defineStore } from "pinia";
import { v4 as uuidv4 } from "uuid";

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
    pushMessage(
      message = { type: "info", title: "Thông tin", message: "Nội dung thông báo", undo: null }
    ) {
      try {
        message.key = uuidv4();
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
