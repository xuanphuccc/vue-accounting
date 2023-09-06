<template>
  <DxDropDownBox
    @focus-out="$emit('blur')"
    @value-changed="onDropDownValueChanged"
    :value="value"
    :data-source="dataSource"
    :value-expr="valueExpr"
    display-expr="label"
    :is-valid="isValid"
    :placeholder="placeholder"
    :show-clear-button="true"
    :drop-down-options="{ minWidth: 350, wrapperAttr: { class: 'ms-tree-view-popup-wrapper' } }"
    drop-down-button-template="imageIcon"
  >
    <template #content="{}">
      <div class="ms-tree-view">
        <div class="ms-tree-view__content">
          <DxTreeView
            @item-selection-changed="onValueChanged"
            :data-source="treeDatasource"
            key-expr="id"
            parent-id-expr="parentId"
            display-expr="label"
            selected-expr="selected"
            :select-by-click="true"
            :search-enabled="true"
            :searchEditorOptions="{ placeholder: searchPlaceholder }"
            :focus-state-enabled="true"
            :height="250"
            data-structure="plain"
            selection-mode="single"
            item-template="item-template"
          >
            <template #item-template="item">
              <div :class="['ms-tree-view__item']">
                {{ item.data?.label ?? "-" }}
              </div>
            </template>
          </DxTreeView>
        </div>

        <div class="ms-tree-view__footer">
          <DxCheckBox :text="$t('employee.text.hideDepartmentSelect')" />
        </div>
      </div>
    </template>

    <template #imageIcon="{}">
      <div :class="['select-dropdown-icon']">
        <MISAIcon ref="icon" size="16" icon="angle-down" />
      </div>
    </template>
  </DxDropDownBox>
</template>

<script>
import DxDropDownBox from "devextreme-vue/drop-down-box";
import DxTreeView from "devextreme-vue/tree-view";
import MISAIcon from "../icon/MISAIcon.vue";
import DxCheckBox from "devextreme-vue/check-box";

export default {
  name: "MISATreeView",
  emits: ["input", "blur"],
  components: {
    DxDropDownBox,
    DxTreeView,
    MISAIcon,
    DxCheckBox,
  },
  props: {
    // Nguồn dữ liệu
    dataSource: {
      type: Array,
      default() {
        return [];
      },
    },

    // Giá trị được chọn
    value: {
      type: null,
    },

    // Chỉ định trường lấy làm giá trị
    valueExpr: {
      type: String,
      default: "id",
    },

    // Trạng thái validate
    isValid: {
      type: Boolean,
      default: true,
    },

    // Gợi ý
    placeholder: {
      type: String,
    },

    // Gợi ý của ô tìm kiếm
    searchPlaceholder: {
      type: String,
      default: "Tìm kiếm",
    },
  },

  data: function () {
    return {};
  },

  computed: {
    /**
     * Description: Đánh dấu giá trị được chọn cho TreeView
     * Author: txphuc (30/08/2023)
     */
    treeDatasource() {
      let localDatasource = JSON.parse(JSON.stringify(this.dataSource));

      localDatasource = localDatasource.map((item) => {
        if (item[this.valueExpr] == this.value) {
          item.selected = true;
        }

        return item;
      });

      return localDatasource;
    },
  },

  methods: {
    /**
     * Description: Xử lý sự kiện thay đổi giá trị của DropDown
     * Author: txphuc (30/08/2023)
     */
    onDropDownValueChanged(e) {
      // Clear giá trị được chọn
      if (!e.value) {
        this.$emit("input", null);
      }
    },

    /**
     * Description: xử lý sự kiện chọn giá trị
     * Author: txphuc (30/08/2023)
     */
    onValueChanged(e) {
      this.$emit("input", e.itemData[this.valueExpr]);
    },
  },
};
</script>

<style>
@import url("./tree-view.scss");
</style>
