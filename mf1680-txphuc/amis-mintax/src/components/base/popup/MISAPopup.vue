<template>
  <div @keydown.stop="handleOnKeyDown" tabindex="-1" class="ms-popup-overlay">
    <div @click.stop="" class="ms-popup" :style="{ width: width + 'px' }">
      <div class="ms-popup__header">
        <h4 class="ms-popup__title">{{ title }}</h4>
        <div class="ms-popup__header-controls">
          <slot name="header-controls"></slot>
        </div>
      </div>
      <div
        v-tooltip="$t('tooltip.close') + ' (ESC)'"
        @click="$emit('close')"
        class="ms-popup__close"
      >
        <MISAIcon icon="times" />
      </div>

      <div class="ms-popup__content">
        <p v-if="description" class="ms-popup__desc">
          {{ description }}
        </p>
        <slot></slot>
      </div>

      <div class="ms-popup__controls">
        <div class="ms-popup__controls-left">
          <slot name="controls-left"></slot>
        </div>
        <div class="ms-popup__controls-right">
          <slot name="controls-right"> </slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import enums from "@/enum/enum";
import MISAIcon from "../icon/MISAIcon.vue";

export default {
  name: "MISAPopup",
  emits: ["close", "submit", "submit-and-continue"],
  components: {
    MISAIcon,
  },
  props: {
    // Tiêu đề popup
    title: {
      type: String,
      default: "Tiêu đề",
    },

    // Mô tả
    description: String,

    // Xác định chiều rộng của popup
    width: {
      type: Number,
      default: 800,
    },
  },
  methods: {
    /**
     * Description: Xử lý sự kiện bản phím
     * Author: txphuc (01/08/2023)
     */
    handleOnKeyDown(e) {
      const keyCode = e.keyCode;
      const shiftKey = e.shiftKey;
      const ctrlKey = e.ctrlKey;

      switch (keyCode) {
        case enums.key.S:
          if (shiftKey && ctrlKey) {
            this.$emit("submit-and-continue");
          } else if (ctrlKey) {
            e.preventDefault();
            this.$emit("submit");
          }
          break;
        case enums.key.ESC:
          this.$emit("close");
          break;
        default:
          break;
      }
    },
  },
};
</script>

<style scoped>
@import url("./popup.scss");
</style>
