<template>
  <div :class="[`ms-icon--${props.size}`, `ms-icon--${props.icon}-${props.size}`]"></div>
</template>

<script setup>
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
});
</script>

<style scoped>
@import url("./icon-base.css");
@import url("./icons.css");
</style>
