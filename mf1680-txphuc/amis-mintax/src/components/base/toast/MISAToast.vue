<template>
  <div :class="['ms-toast', `--${type}`]">
    <div class="ms-toast__header">
      <MISAIcon icon="check" />
    </div>
    <div class="ms-toast__content">{{ title }}</div>
    <div @click="$emit('click')" class="ms-toast__close">
      <MISAIcon :size="20" icon="times" />
    </div>
  </div>
</template>

<script>
import MISAIcon from "../icon/MISAIcon.vue";

export default {
  name: "MISAToast",
  emits: ["click"],
  props: {
    // Tiêu đề
    title: {
      type: String,
      default: "Message",
    },

    // Loại toast: info | success | warning | error
    type: {
      type: String,
      default: "info",
    },
  },
  components: {
    MISAIcon,
  },
};
</script>

<style lang="scss" scoped>
@import url("./toast.scss");
</style>
