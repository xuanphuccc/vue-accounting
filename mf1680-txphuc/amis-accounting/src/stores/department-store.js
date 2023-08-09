import { defineStore } from "pinia";
import enums from "@/enum/enum";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "./global-store";

export const useDepartmentStore = defineStore("department", {
  state: () => ({
    // Xác định hành động của form nhập create/update
    mode: enums.form.mode.CREATE,

    // Hiển thị tiêu đề của form
    title: "",

    // Trạng thái của form nhập liệu
    isOpenForm: false,

    // Dữ liệu của đơn vị đang được chỉnh sửa
    currentDepartment: {},
  }),
  getters: {
    /**
     * Description: Lấy ra dữ liệu của đơn vị
     * đang được chọn để sửa
     * Author: txphuc (28/06/2023)
     */
    getCurrentDepartment: (state) => {
      return state.currentDepartment;
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

      this.title = MISAResource[globalStore.lang]?.Page?.Department?.Form?.CreateTitle;

      this.isOpenForm = true;
    },

    /**
     * Description: Mở form và set thông tin
     * của đơn vị muốn sửa
     * Author: txphuc (28/06/2023)
     */
    openFormForUpdate(department) {
      const globalStore = useGlobalStore();

      // Lấy data đơn vị
      this.currentDepartment = department;

      this.mode = enums.form.mode.UPDATE;

      this.title = MISAResource[globalStore.lang]?.Page?.Department?.Form?.UpdateTitle;

      this.isOpenForm = true;
    },

    /**
     * Description: Mở form và set thông tin
     * của đơn vị muốn nhân bản
     * Author: txphuc (10/07/2023)
     */
    openFormForDuplicate(department) {
      const globalStore = useGlobalStore();

      // Lấy data đơn vị
      this.currentDepartment = department;

      this.mode = enums.form.mode.DUPLICATE;

      this.title = MISAResource[globalStore.lang]?.Page?.Department?.Form?.DuplicateTitle;

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
