import { defineStore } from "pinia";
import enums from "@/helper/enum";

export const useEmployeeStore = defineStore("employee", {
  state: () => ({
    // Xác định hành động của form nhập create/update
    mode: enums.form.mode.CREATE,

    // Trạng thái của form nhập liệu
    isOpenForm: false,

    // Dữ liệu của nhân viên đang được chỉnh sửa
    currentEmployee: {},
  }),
  getters: {
    /**
     * Description: Lấy ra dữ liệu của nhân viên
     * đang được chọn để sửa
     * Author: txphuc (28/06/2023)
     */
    getCurrentEmployee: (state) => {
      return state.currentEmployee;
    },
  },
  actions: {
    /**
     * Description: Mở form ở chế độ tạo mới
     * Author: txphuc (28/06/2023)
     */
    openFormForCreate() {
      this.mode = enums.form.mode.CREATE;
      this.isOpenForm = true;
    },

    /**
     * Description: Mở form và set thông tin
     * của nhân viên muốn sửa
     * Author: txphuc (28/06/2023)
     */
    openFormForUpdate(employee) {
      this.currentEmployee = employee;
      this.mode = enums.form.mode.UPDATE;
      this.isOpenForm = true;
    },

    /**
     * Description: Đóng form và reset dữ liệu về ban đầu
     * Author: txphuc (28/06/2023)
     */
    closeForm() {
      this.$reset();
    },
  },
});
