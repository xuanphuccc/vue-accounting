import enums from "@/enum/enum";
import { v4 as uuidv4 } from "uuid";

const employeeRelationshipStore = {
  namespaced: true,

  state: () => ({
    // Trạng thái đóng/mở form thêm thành viên gia đình
    active: false,

    // Xác định hành động của form nhập create/update
    mode: enums.form.mode.CREATE,

    // Hiển thị tiêu đề của form
    title: "",

    // Dữ liệu của thành viên gia đình đang chỉnh sửa
    currentRelationship: {},

    // Danh sách thành viên gia đình
    relationships: [],
  }),

  getters: {
    /**
     * Description: Chỉ hiển thị những thành viên gia đình chưa bị xoá
     * (nếu bị xoá thì EditMode )
     * Author: txphuc (26/08/2023)
     */
    displayRelationships(state) {
      return state.relationships.filter(
        (relationship) => relationship.EditMode != enums.editMode.DELETE
      );
    },
  },

  mutations: {
    /**
     * Description: Set trạng thái đóng/mở form
     * Author: txphuc (26/08/2023)
     */
    SET_FORM_ACTIVE(state, active) {
      state.active = active;
    },

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
    SET_CURRENT_RELATIONSHIP(state, currentRelationship) {
      state.currentRelationship = currentRelationship;
    },

    /**
     * Description: Thêm thành viên gia đình
     * Author: txphuc (24/08/2023)
     */
    ADD_RELATIONSHIP(state, relationship) {
      relationship.EmployeeRelationshipID = uuidv4();
      relationship.EditMode = enums.editMode.CREATE;

      state.relationships.push(relationship);
    },

    /**
     * Description: Cập nhật viên gia đình
     * Author: txphuc (24/08/2023)
     */
    UPDATE_RELATIONSHIP(state, newRelationship) {
      state.relationships = state.relationships.map((relationship) => {
        if (relationship.EmployeeRelationshipID == newRelationship.EmployeeRelationshipID) {
          relationship = newRelationship;

          if (relationship.EditMode !== enums.editMode.CREATE) {
            // Nếu vừa được tạo thì không chuyển chế độ
            // mà chỉ sửa dữ liệu (chế độ cập nhật nhân viên)
            relationship.EditMode = enums.editMode.UPDATE;
          }

          return relationship;
        } else {
          return relationship;
        }
      });
    },

    /**
     * Description: Xoá thành viên gia đình
     * Author: txphuc (24/08/2023)
     */
    REMOVE_RELATIONSHIP(state, relationshipKey) {
      state.relationships = state.relationships.map((relationship) => {
        if (relationship.EmployeeRelationshipID == relationshipKey) {
          // Chuyển sang chế độ Delete:
          // - Không hiển thị lên bảng
          // - Không được gửi ở chế độ Create Employee
          // - Chỉ được gửi ở chế độ Update Employee
          relationship.EditMode = enums.editMode.DELETE;
          return relationship;
        } else {
          return relationship;
        }
      });
    },

    /**
     * Description: Set danh sách thành viên gia đình
     * Author: txphuc (26/08/2023)
     */
    SET_RELATIONSHIPS(state, relationships) {
      state.relationships = relationships;
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

      commit("SET_FORM_ACTIVE", true);
    },

    /**
     * Description: Mở form để thêm mới
     * Author: txphuc (24/08/2023)
     */
    openFormForUpdate({ commit }, employeeRelationship) {
      commit("SET_FORM_MODE", enums.form.mode.UPDATE);
      commit("SET_FORM_TITLE", "Cập nhật");

      commit("SET_CURRENT_RELATIONSHIP", employeeRelationship);

      commit("SET_FORM_ACTIVE", true);
    },

    /**
     * Description: Thoát form
     * Author: txphuc (24/08/2023)
     */
    closeForm({ commit }) {
      commit("SET_FORM_MODE", enums.form.mode.CREATE);
      commit("SET_FORM_TITLE", "");
      commit("SET_CURRENT_RELATIONSHIP", {});

      commit("SET_FORM_ACTIVE", false);
    },

    /**
     * Description: Set danh sách thành viên gia đình
     * Author: txphuc (26/08/2023)
     */
    setRelationships({ commit }, relationships) {
      commit("SET_RELATIONSHIPS", relationships);
    },

    /**
     * Description: Thêm thành viên gia đình
     * Author: txphuc (24/08/2023)
     */
    addRelationship({ commit }, relationship) {
      commit("ADD_RELATIONSHIP", relationship);
    },

    /**
     * Description: Cập nhật thành viên gia đình
     * Author: txphuc (24/08/2023)
     */
    updateRelationship({ commit }, relationship) {
      commit("UPDATE_RELATIONSHIP", relationship);
    },

    /**
     * Description: Xoá thành viên gia đình
     * Author: txphuc (24/08/2023)
     */
    removeRelationship({ commit }, relationshipKey) {
      commit("REMOVE_RELATIONSHIP", relationshipKey);
    },
  },
};

export default employeeRelationshipStore;
