<template>
  <ul :class="['ms-context-menu', { '--small': props.small }]">
    <slot></slot>
  </ul>
</template>

<script setup>
const props = defineProps({
  small: {
    type: Boolean,
    default: false,
  },
});
</script>

<style scoped>
@import url("./context-menu.css");
</style>
