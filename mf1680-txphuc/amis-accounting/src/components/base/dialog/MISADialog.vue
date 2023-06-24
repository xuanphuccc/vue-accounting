<template>
  <div @click="$emit('close')" :class="[`ms-dialog-overlay`, { '--active': this.active }]">
    <div @click.stop="" class="ms-dialog --warning">
      <h4 class="ms-dialog__title">{{ this.title }}</h4>
      <button
        @click="$emit('close')"
        class="ms-dialog__close ms-icon--times-24"
        title="Đóng"
      ></button>

      <div class="ms-dialog__content">
        <div :class="[`ms-dialog__icon`, `ms-icon--${this.type}-24`]"></div>
        <p class="ms-dialog__text">
          {{ this.description }}
        </p>
      </div>

      <div class="ms-dialog__controls">
        <MISAButton @click="$emit('cancel')" type="secondary">{{ this.cancelText }}</MISAButton>
        <MISAButton @click="$emit('ok')" type="primary">{{ this.okText }}</MISAButton>
      </div>
    </div>
  </div>
</template>

<script>
import MISAButton from "../button/MISAButton.vue";

export default {
  emits: ["close", "cancel", "ok"],
  props: {
    active: {
      type: Boolean,
      default: false,
    },
    type: {
      type: String,
      default: "info",
    },
    title: {
      type: String,
      default: "Tiêu đề",
    },
    description: {
      type: String,
      default: "Mô tả",
    },
    cancelText: {
      type: String,
      default: "Huỷ",
    },
    okText: {
      type: String,
      default: "Đồng ý",
    },
  },
  components: {
    MISAButton,
  },
};
</script>

<style scoped>
@import url("./dialog.css");
</style>
