<template>
  <div :class="['ms-form__group', { '--error': props.errorMsg }, ...customClasses]">
    <label :for="props.for" class="ms-label"
      >{{ props.label }}
      <span v-if="requiredMark" class="ms-label--requried">*</span>
    </label>

    <slot></slot>

    <p v-if="props.errorMsg" class="ms-input-text">{{ props.errorMsg }}</p>
  </div>
</template>

<script setup>
import { computed } from "vue";

const props = defineProps({
  // Nội dung label
  label: {
    type: String,
    default: "Label",
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

  // Thêm các class
  class: [Array, String],
});

/**
 * Description: Xử lý chuyển đổi class dạng string thành array
 * Author: txphuc (26/06/2023)
 */
const customClasses = computed(() => {
  try {
    let classArr = [];

    if (props.class) {
      if (typeof props.class === "string") {
        classArr.push(props.class);
      } else if (Array.isArray(props.class)) {
        classArr = props.class;
      }
    }

    return classArr;
  } catch (error) {
    console.warn(error);
    return [];
  }
});
</script>

<style scoped>
@import url("./input.css");
</style>
