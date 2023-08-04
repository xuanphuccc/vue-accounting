<template>
  <div
    :class="[
      'ms-form__group',
      { '--error': props.errorMsg },
      { '--space-bottom': props.spaceBottom },
    ]"
  >
    <label
      v-tippy="{ content: props.tooltip || '' }"
      :for="props.for"
      :class="['ms-label', { '--flex': props.labelDesc }]"
    >
      <span class="ms-label__left">
        {{ props.label }} <span v-if="requiredMark" class="ms-label--requried">*</span>
      </span>
      <span class="ms-label__right">{{ props.labelDesc }}</span>
    </label>

    <slot></slot>

    <p class="ms-input-text">{{ props.errorMsg }}</p>
  </div>
</template>

<script setup>
const props = defineProps({
  // Nội dung label
  label: {
    type: String,
    default: "Label",
  },

  // Mô tả cho label
  labelDesc: {
    type: String,
  },

  // Hiện đánh dấu bắt buộc
  requiredMark: {
    type: Boolean,
    default: false,
  },

  // Thuộc tính của label liên kết với input
  for: String,

  // Thông báo lỗi
  errorMsg: String,

  // Thêm khoảng cách bên dưới
  spaceBottom: {
    type: Boolean,
    default: false,
  },

  // Hiện tooltip cho label
  tooltip: {
    type: String,
  },
});
</script>

<style scoped>
@import url("./input.css");
</style>
