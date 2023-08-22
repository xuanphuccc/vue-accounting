<template>
  <DxTextBox
    :value="value"
    @input="onInput"
    @enter-key="$emit('enter-key', $event)"
    :placeholder="placeholder"
    :width="width"
    :disabled="disabled"
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
  emits: ["input", "enter-key"],
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
      console.log(this.$refs?.textBoxRef);
      this.$refs?.textBoxRef?.instance?.focus();
    }
  },
};
</script>

<style>
@import url("./text-box.scss");
</style>
