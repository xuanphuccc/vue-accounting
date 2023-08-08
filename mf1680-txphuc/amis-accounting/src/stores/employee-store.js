import { defineStore } from "pinia";
import enums from "@/enum/enum";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "./global-store";

export const useEmployeeStore = defineStore("employee", {
  state: () => ({
    // Xác định hành động của form nhập create/update
    mode: enums.form.mode.CREATE,

    // Hiển thị tiêu đề của form
    title: "",

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
      const globalStore = useGlobalStore();

      this.mode = enums.form.mode.CREATE;

      this.title = MISAResource[globalStore.lang]?.Page?.Employee?.Form?.CreateTitle;

      this.isOpenForm = true;
    },

    /**
     * Description: Mở form và set thông tin
     * của nhân viên muốn sửa
     * Author: txphuc (28/06/2023)
     */
    openFormForUpdate(employee) {
      const globalStore = useGlobalStore();

      // Lấy data nhân viên
      this.currentEmployee = employee;

      this.mode = enums.form.mode.UPDATE;

      this.title = MISAResource[globalStore.lang]?.Page?.Employee?.Form?.UpdateTitle;

      this.isOpenForm = true;
    },

    /**
     * Description: Mở form và set thông tin
     * của nhân viên muốn nhân bản
     * Author: txphuc (10/07/2023)
     */
    openFormForDuplicate(employee) {
      const globalStore = useGlobalStore();

      // Lấy data nhân viên
      this.currentEmployee = employee;

      this.mode = enums.form.mode.DUPLICATE;

      this.title = MISAResource[globalStore.lang]?.Page?.Employee?.Form?.DuplicateTitle;

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
