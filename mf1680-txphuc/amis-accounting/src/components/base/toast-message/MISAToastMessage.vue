<template>
  <div :class="['ms-toast', `--${props.type}`]">
    <span :class="['ms-toast__icon', `ms-icon--${props.type}-24`]"></span>
    <div class="ms-toast__content">
      <span class="ms-toast__title">{{ props.title }}</span
      >{{ " " }}
      <span class="ms-toast__text">{{ props.message }}</span>
    </div>
    <span v-if="props.undo" @click="$emit('undo')" class="ms-toast__action">Hoàn tác</span>
    <span @click="$emit('close')" class="ms-toast__close ms-icon--times-20" title="Đóng"></span>
  </div>
</template>

<script setup>
defineEmits(["close", "undo"]);

const props = defineProps({
  type: {
    type: String,
    default: "info",
  },
  title: {
    type: String,
    default: "Tiêu đề",
  },
  message: {
    type: String,
    default: "Thông báo",
  },
  undo: {
    type: Boolean,
    default: false,
  },
});
</script>

<style scoped>
@import url("./toastmessage.css");
</style>
