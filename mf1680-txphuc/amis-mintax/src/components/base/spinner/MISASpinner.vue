<template>
  <div
    :style="{
      width: this.size + 'px',
      height: this.size + 'px',
      borderWidth: this.width + 'px',
    }"
    :class="['ms-spinner', { '--absolute': this.absolute }]"
  ></div>
</template>

<script>
export default {
  name: "MISASpinner",
  props: {
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
  },
};
</script>

<style scoped>
@import url("./spinner.scss");
</style>
