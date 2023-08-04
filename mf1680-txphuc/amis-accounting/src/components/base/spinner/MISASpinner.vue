<template>
  <div
    :style="{
      width: props.size + 'px',
      height: props.size + 'px',
      borderWidth: props.width + 'px',
    }"
    :class="['ms-spinner', { '--absolute': props.absolute }]"
  ></div>
</template>

<script setup>
const props = defineProps({
  absolute: {
    type: Boolean,
    default: false,
  },

  // Kích thước của spinner
  size: {
    type: [Number, String],
    default: 20,
  },

  // Độ dày của spinner
  width: {
    type: [Number, String],
    default: 2,
  },
});
</script>

<style scoped>
@import url("./spinner.css");
</style>
