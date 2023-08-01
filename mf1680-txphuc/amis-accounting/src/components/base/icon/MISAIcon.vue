<template>
  <div
    ref="iconRef"
    :class="[
      `ms-icon--${props.size}`,
      `ms-icon--${props.icon}-${props.size}`,
      { 'ms-icon--no-color': props.noColor },
    ]"
  ></div>
</template>

<script setup>
import { ref } from "vue";

const props = defineProps({
  // Kích thước của icon bao gồm: 24, 20, 16
  size: {
    type: [Number, String],
    default: 24,
  },

  // Loại icon
  icon: {
    type: [String],
    default: "bag",
  },

  // Dành cho icon không cần set màu sắc
  noColor: {
    type: Boolean,
    default: false,
  },
});

const iconRef = ref(null);

/**
 * Description: Sự kiện click vào icon
 * Author: txphuc (31/07/2023)
 */
const click = () => {
  if (iconRef.value) {
    iconRef.value.click();
  }
};

/**
 * Description: Sự kiện focus vào icon
 * Author: txphuc (31/07/2023)
 */
const focus = () => {
  if (iconRef.value) {
    iconRef.value.focus();
  }
};

// Làm cho phương thức click có thể truy cập được từ component cha
defineExpose({ click, focus });
</script>

<style scoped>
@import url("./icon-base.css");
@import url("./icons.css");
</style>
