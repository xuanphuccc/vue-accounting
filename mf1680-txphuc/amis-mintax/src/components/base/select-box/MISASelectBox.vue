<template>
  <DxSelectBox
    :value="value"
    @value-changed="onValueChanged"
    :data-source="dataSource"
    :display-expr="displayExpr"
    :value-expr="valueExpr"
    :search-enabled="searchEnabled"
    drop-down-button-template="imageIcon"
    item-template="item"
    :placeholder="placeholder"
  >
    <template #imageIcon="{}">
      <div :class="['select-dropdown-icon', { '--search-mode': searchEnabled }]">
        <MISAIcon size="16" icon="angle-down" />
      </div>
    </template>

    <template #item="{ data }">
      <div class="ms-select__item">
        <div class="ms-select__item-wrap">
          <div class="ms-select__item-text">{{ data.label }}</div>
          <div class="ms-select__check-icon">
            <MISAIcon icon="check" />
          </div>
        </div>
      </div>
    </template>
  </DxSelectBox>
</template>

<script>
import DxSelectBox from "devextreme-vue/select-box";
import MISAIcon from "../icon/MISAIcon.vue";

export default {
  name: "MISASelectBox",
  emits: ["input"],
  components: {
    DxSelectBox,
    MISAIcon,
  },
  props: {
    // - label: giá trị hiển thị
    // - value: giá trị khi được chọn
    dataSource: {
      type: Array,
      default() {
        return [];
      },
    },

    // Chỉ định trường hiển thị
    displayExpr: {
      type: String,
    },

    // Chỉ định trường giá trị
    valueExpr: {
      type: String,
    },

    // Bật/tắt chế độ tìm kiếm
    searchEnabled: {
      type: Boolean,
      default: false,
    },

    // Giá trị được chọn
    value: {
      type: [String, Number],
    },

    // Gợi ý
    placeholder: {
      type: String,
      default: "Select...",
    },
  },

  methods: {
    /**
     * Description: Xử lý sự kiện thay đổi giá trị được chọn
     * Author: txphuc (18/08/2023)
     */
    onValueChanged(e) {
      this.$emit("input", e.value);
    },
  },
};
</script>

<style lang="scss">
@import url("./select-box.scss");
</style>
