import enums from "@/enum/enum";
import router from "@/router";

const employeeStore = {
  namespaced: true,

  state: () => ({
    // Xác định hành động của form nhập create/update
    mode: enums.form.mode.CREATE,

    // Hiển thị tiêu đề của form
    title: "",

    // Dữ liệu của nhân viên đang được chỉnh sửa
    currentEmployee: {},
  }),
  mutations: {
    /**
     * Description: Set chế độ form
     * Author: txphuc (24/08/2023)
     */
    SET_FORM_MODE(state, mode) {
      state.mode = mode;
    },

    /**
     * Description: Set tiêu đề form
     * Author: txphuc (24/08/2023)
     */
    SET_FORM_TITLE(state, title) {
      state.title = title;
    },

    /**
     * Description: Set dữ liệu cho form sửa
     * Author: txphuc (24/08/2023)
     */
    SET_FORM_DATA(state, currentEmployee) {
      state.currentEmployee = currentEmployee;
    },
  },
  actions: {
    /**
     * Description: Mở form để thêm mới
     * Author: txphuc (24/08/2023)
     */
    openFormForCreate({ commit }) {
      commit("SET_FORM_MODE", enums.form.mode.CREATE);
      commit("SET_FORM_TITLE", "Thêm mới");

      router.push({ name: "employee-detail" });
    },

    /**
     * Description: Mở form để thêm mới
     * Author: txphuc (24/08/2023)
     */
    openFormForUpdate({ commit }, employee) {
      commit("SET_FORM_MODE", enums.form.mode.UPDATE);
      commit("SET_FORM_TITLE", "Cập nhật");
      commit("SET_FORM_DATA", employee);

      router.push({ name: "employee-detail" });
    },

    /**
     * Description: Thoát form
     * Author: txphuc (24/08/2023)
     */
    closeForm({ commit, dispatch }) {
      commit("SET_FORM_MODE", enums.form.mode.CREATE);
      commit("SET_FORM_TITLE", "");
      commit("SET_FORM_DATA", {});

      // Làm trống bảng danh sách thành viên gia đình khi thoát form
      dispatch("employeeRelationshipStore/setRelationships", [], { root: true });

      router.push({ name: "employee" });
    },
  },
  getters: {},
};

export default employeeStore;
