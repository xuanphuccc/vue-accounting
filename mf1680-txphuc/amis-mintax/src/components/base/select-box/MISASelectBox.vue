<template>
  <DxSelectBox
    @focus-out="$emit('blur')"
    @value-changed="onValueChanged"
    :data-source="dataSource"
    :value="value"
    :is-valid="isValid"
    :display-expr="displayExpr"
    :value-expr="valueExpr"
    :search-enabled="searchEnabled"
    drop-down-button-template="imageIcon"
    item-template="item"
    :input-attr="{ id }"
    :drop-down-options="{ hideOnParentScroll: true }"
    :placeholder="placeholder"
    ref="selectBoxRef"
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
  emits: ["input", "blur"],
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
      type: [String, Number, Boolean],
    },

    // Gợi ý
    placeholder: {
      type: String,
      default: "Select...",
    },

    // Trạng thái validate
    isValid: {
      type: Boolean,
      default: true,
    },

    // Tự động focus khi compoennt được mounted
    autoFocus: {
      type: Boolean,
      default: false,
    },

    // Id (sử dụng cho label)
    id: {
      type: String,
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

    /**
     * Description: Expose phương thức focus input
     * Author: txphuc (18/08/2023)
     */
    focus() {
      if (this.$refs?.selectBoxRef) {
        this.$refs?.selectBoxRef?.instance?.focus();
      }
    },
  },

  /**
   * Description: Tự động focus
   * Author: txphuc (27/08/2023)
   */
  mounted: function () {
    if (this.autoFocus && this.$refs?.selectBoxRef) {
      this.$refs?.selectBoxRef?.instance?.focus();
    }
  },
};
</script>

<style lang="scss">
@import url("./select-box.scss");
</style>
