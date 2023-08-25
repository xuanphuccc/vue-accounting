import { v4 as uuidv4 } from "uuid";

const toastStore = {
  namespaced: true,

  state: () => ({
    toastArr: [],
  }),
  mutations: {
    /**
     * Description: Đẩy tin nhắn mới
     * Author: txphuc (24/08/2023)
     */
    PUSH_MESSAGE(state, message) {
      state.toastArr.push(message);
    },

    /**
     * Description: Xoá tin nhắn
     * Author: txphuc (24/08/2023)
     */
    REMOVE_MESSAGE(state, messageKey) {
      state.toastArr = state.toastArr.filter((toast) => toast.key != messageKey);
    },
  },
  actions: {
    /**
     * Description: Đẩy lên một toast message thành công
     * Author: txphuc (24/08/2023)
     */
    pushSuccessMessage({ commit }, message = { message: "Nội dung thông báo" }) {
      message.key = uuidv4();
      message.type = "success";
      message.title = message.message;

      commit("PUSH_MESSAGE", message);

      setTimeout(() => {
        commit("REMOVE_MESSAGE", message.key);
      }, 3000);
    },

    /**
     * Description: Xoá một toast message khỏi danh sách
     * Author: txphuc (24/08/2023)
     */
    removeMessage({ commit }, messageKey) {
      commit("REMOVE_MESSAGE", messageKey);
    },
  },
  getters: {},
};

export default toastStore;
