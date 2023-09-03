<template>
  <DxTextBox
    @focus-out="$emit('blur')"
    @enter-key="$emit('enter-key', $event)"
    @input="onInput"
    :value="value"
    :is-valid="isValid"
    :input-attr="{ id }"
    :placeholder="placeholder"
    :width="width"
    :disabled="disabled"
    :max-length="maxLength"
    :show-clear-button="showClearButton"
    ref="textBoxRef"
  >
    <!-- input action -->
    <div v-if="$slots.default" location="after" class="input-action">
      <slot></slot>
    </div>
  </DxTextBox>
</template>

<script>
import DxTextBox from "devextreme-vue/text-box";

export default {
  name: "MISATextBox",
  emits: ["input", "enter-key", "blur"],
  components: {
    DxTextBox,
  },

  props: {
    // Giá trị
    value: {
      type: [String, Number],
    },

    // Tự động focus khi mounted
    autoFocus: {
      type: Boolean,
      default: false,
    },

    // Gợi ý
    placeholder: {
      type: String,
    },

    // Vô hiệu hoá
    disabled: {
      type: Boolean,
      default: false,
    },

    // Chiều dài
    width: {
      type: String,
    },

    // Id (dùng cho label)
    id: {
      type: String,
    },

    // Trạng thái validate
    isValid: {
      type: Boolean,
      default: true,
    },

    // Số ký tự tối đa có thể nhập
    maxLength: {
      type: [String, Number],
      default: 255,
    },

    // Hiện/ẩn nút xoá giá trị input đã nhập
    showClearButton: {
      type: Boolean,
      default: true,
    },
  },

  methods: {
    /**
     * Description: Xử lý sự kiện nhập dữ liệu
     * Author: txphuc (18/08/2023)
     */
    onInput(e) {
      this.$emit("input", e.event?.target?.value);
    },

    /**
     * Description: Expose phương thức focus input
     * Author: txphuc (18/08/2023)
     */
    focus() {
      if (this.$refs?.textBoxRef) {
        this.$refs?.textBoxRef?.instance?.focus();
      }
    },
  },

  /**
   * Description: Tự động focus khi mounted
   * Author: txphuc (18/08/2023)
   */
  mounted: function () {
    if (this.autoFocus && this.$refs?.textBoxRef) {
      this.focus();
    }
  },
};
</script>

<style>
@import url("./text-box.scss");
</style>
