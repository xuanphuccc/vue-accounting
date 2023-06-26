<template>
  <div @click="$emit('close')" :class="[`ms-dialog-overlay`, { '--active': props.active }]">
    <div @click.stop="" class="ms-dialog">
      <h4 class="ms-dialog__title">{{ props.title }}</h4>
      <button
        @click="$emit('close')"
        class="ms-dialog__close ms-icon--times-24"
        title="Đóng"
      ></button>

      <div class="ms-dialog__content">
        <div :class="[`ms-dialog__icon`, `ms-icon--${props.type}-24`]"></div>
        <p class="ms-dialog__text">
          {{ props.description }}
        </p>
      </div>

      <div class="ms-dialog__controls">
        <MISAButton @click="$emit('cancel')" type="secondary">{{ props.cancelText }}</MISAButton>
        <MISAButton @click="$emit('ok')" type="primary">{{ props.okText }}</MISAButton>
      </div>
    </div>
  </div>
</template>

<script setup>
import MISAButton from "../button/MISAButton.vue";

defineEmits(["close", "cancel", "ok"]);

const props = defineProps({
  // Trạng thái đóng/mở của dialog
  active: {
    type: Boolean,
    default: false,
  },

  // Loại dialog (info, warning, error)
  type: {
    type: String,
    default: "info",
  },

  // Tiêu đề
  title: {
    type: String,
    default: "Tiêu đề",
  },

  // Mô tả
  description: {
    type: String,
    default: "Mô tả",
  },

  // Text của nút Cancel
  cancelText: {
    type: String,
    default: "Huỷ",
  },

  // Text của nút OK
  okText: {
    type: String,
    default: "Đồng ý",
  },
});
</script>

<style scoped>
@import url("./dialog.css");
</style>
