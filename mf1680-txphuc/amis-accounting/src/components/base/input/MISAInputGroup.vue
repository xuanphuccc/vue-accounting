<template>
  <label :for="props.for" class="ms-input-group">
    <slot></slot>
  </label>
</template>

<script setup>
const props = defineProps({
  // Thuộc tính của label liên kết với input
  for: String,
});
</script>

<style scoped>
@import url("./input.css");
</style>
