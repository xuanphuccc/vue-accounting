<template>
  <button
    :class="[
      `ms-btn`,
      `ms-btn--${this.type}`,
      { 'ms-btn--icon': this.icon && $slots.default === undefined },
      { 'ms-btn--with-icon': this.icon && $slots.default !== undefined },
    ]"
    :disabled="this.disabled"
  >
    <span v-if="this.icon" :class="[`ms-btn__icon`, this.icon]"></span>
    <slot></slot>
  </button>
</template>

<script>
export default {
  props: {
    icon: String,
    type: String,
    color: String,
    disabled: Boolean,
  },
};
</script>

<style scoped>
@import url("./button.css");
</style>
