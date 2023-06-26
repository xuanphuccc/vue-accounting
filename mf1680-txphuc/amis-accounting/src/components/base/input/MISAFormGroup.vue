<template>
  <div :class="['ms-form__group', { '--error': props.error }]">
    <label :for="props.for" class="ms-label">Tên nhân viên</label>

    <slot></slot>

    <p v-if="props.errorMsg" class="ms-input-text">{{ props.errorMsg }}</p>
  </div>
</template>

<script setup>
const props = defineProps({
  // Thuộc tính của label liên kết với input
  for: String,

  // Trạng thái của input (error)
  error: Boolean,

  // Thông báo lỗi
  errorMsg: String,
});
</script>

<style scoped>
@import url("./input.css");
</style>
