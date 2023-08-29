<template>
  <div :class="['ms-badge', `--${color}-color`]">{{ text }}</div>
</template>

<script>
export default {
  name: "MISABadge",
  props: {
    // Chữ hiển thị
    text: {
      type: String,
      default: "Badge",
    },

    // Màu sắc
    color: {
      type: String,
      default: "primary",
    },
  },
};
</script>

<style lang="scss">
.ms-badge {
  display: inline-block;
  padding: 8px 12px;
  border-radius: 4px;

  &.--primary-color {
    background: var(--blue-50);
    color: var(--blue-500);
  }

  &.--success-color {
    background: #e5fce9;
    color: #00af2f;
  }

  &.--disabled-color {
    background: var(--gray-100);
    color: var(--primary-text-color);
  }

  &.--danger-color {
    background: #f9c7c7;
    color: #e61d1d;
  }
}
</style>
