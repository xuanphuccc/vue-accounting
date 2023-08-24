<template>
  <div
    @keydown.stop="handleOnKeyDown"
    @click="$emit('cancel')"
    :class="[`ms-dialog-overlay`, '--active']"
    tabindex="-1"
  >
    <div @click.stop="" class="ms-dialog">
      <h4 class="ms-dialog__title">{{ title }}</h4>
      <div @click="$emit('cancel')" class="ms-dialog__close">
        <MISAIcon icon="times" />
      </div>

      <div class="ms-dialog__content">
        <p class="ms-dialog__text">
          {{ description }}
        </p>
      </div>

      <div class="ms-dialog__controls">
        <div class="ms-dialog__left-controls">
          <slot name="left-controls"></slot>
        </div>

        <div class="ms-dialog__right-controls">
          <slot name="right-controls">
            <MISAButton tabindex="2" v-if="cancelText" @click="$emit('cancel')" type="secondary">{{
              cancelText
            }}</MISAButton>
            <MISAButton auto-focus tabindex="1" @click="$emit('ok')" type="primary">{{
              okText
            }}</MISAButton>
          </slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import enums from "@/enum/enum";
import MISAButton from "../button/MISAButton.vue";
import MISAIcon from "../icon/MISAIcon.vue";

export default {
  name: "MISADialog",
  emits: ["cancel", "ok"],
  components: {
    MISAButton,
    MISAIcon,
  },
  props: {
    // Loại dialog (info, warning, error)
    type: {
      type: String,
      default: "info",
    },

    // Tiêu đề
    title: {
      type: String,
      default: "Title",
    },

    // Mô tả
    description: {
      type: String,
      default: "Description",
    },

    // Text của nút Cancel
    cancelText: {
      type: String,
      default: "",
    },

    // Text của nút OK
    okText: {
      type: String,
      default: "OK",
    },
  },
  methods: {
    /**
     * Description: Xử lý sự kiện bàn phím
     * Author: txphuc (01/08/2023)
     */
    handleOnKeyDown(e) {
      try {
        const keyCode = e.keyCode;

        switch (keyCode) {
          case enums.key.ESC:
            // Đóng form khi nhấn ESC
            this.$emit("cancel");
            break;

          default:
            break;
        }
      } catch (error) {
        console.warn(error);
      }
    },
  },
};
</script>

<style scoped>
@import url("./dialog.scss");
</style>
