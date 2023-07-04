<template>
  <div @click="$emit('cancel')" :class="[`ms-dialog-overlay`, '--active']">
    <div @click.stop="" class="ms-dialog">
      <h4 class="ms-dialog__title">{{ props.title }}</h4>
      <div @click="$emit('cancel')" class="ms-dialog__close" title="Đóng">
        <MISAIcon icon="times" />
      </div>

      <div class="ms-dialog__content">
        <div :class="[`ms-dialog__icon`, `ms-icon--${props.type}-24`]"></div>
        <p class="ms-dialog__text">
          {{ props.description }}
        </p>
      </div>

      <div class="ms-dialog__controls">
        <MISAButton v-if="props.cancelText" @click="$emit('cancel')" type="secondary">{{
          props.cancelText
        }}</MISAButton>
        <MISAButton @click="$emit('ok')" type="primary">{{ props.okText }}</MISAButton>
      </div>
    </div>
  </div>
</template>

<script setup>
import MISAButton from "../button/MISAButton.vue";
import MISAIcon from "../icon/MISAIcon.vue";

defineEmits(["cancel", "ok"]);

const props = defineProps({
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
    default: "",
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
