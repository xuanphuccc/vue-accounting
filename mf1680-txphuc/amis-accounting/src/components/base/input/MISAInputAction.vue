<template>
  <div class="ms-input-group__action">
    <span :class="['ms-input-group__action-icon', props.icon]"></span>
  </div>
</template>

<script setup>
const props = defineProps({
  // Icon của action button
  icon: {
    type: String,
    default: "",
  },
});
</script>

<style scoped>
@import url("./input.css");
</style>
