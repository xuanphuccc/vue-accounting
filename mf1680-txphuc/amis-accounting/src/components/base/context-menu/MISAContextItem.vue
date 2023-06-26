<template>
  <li @click="$emit('click', $event)" class="ms-context-menu__item">
    <div v-if="props.icon" class="ms-context-menu__icon">
      <div :class="['ms-icon--24', props.icon]"></div>
    </div>
    <div class="ms-context-menu__text">
      <slot></slot>
    </div>
  </li>
</template>

<script setup>
defineEmits(["click"]);

const props = defineProps({
  // Icon minh hoạ
  icon: String,
});
</script>

<style scoped>
@import url("./context-menu.css");
</style>
