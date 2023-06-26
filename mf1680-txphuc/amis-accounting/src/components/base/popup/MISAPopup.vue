<template>
  <div @click="$emit('close')" :class="[`ms-popup-overlay`, { '--active': props.active }]">
    <div @click.stop="" class="ms-popup" :style="{ width: props.width + 'px' }">
      <h4 class="ms-popup__title">{{ props.title }}</h4>
      <button
        @click="$emit('close')"
        class="ms-popup__close ms-icon--times-24"
        title="Đóng"
      ></button>

      <div class="ms-popup__content">
        <p v-if="props.description" class="ms-popup__desc">
          {{ props.description }}
        </p>
        <slot></slot>
      </div>

      <div class="ms-popup__controls">
        <div class="ms-popup__controls-left">
          <slot name="controls-left"></slot>
        </div>
        <div class="ms-popup__controls-right">
          <slot name="controls-right"> </slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
defineEmits(["close"]);

const props = defineProps({
  // Trạng thái ẩn/hiện popup
  active: {
    type: Boolean,
    default: false,
  },

  // Tiêu đề popup
  title: {
    type: String,
    default: "Tiêu đề",
  },

  // Mô tả
  description: String,

  // Xác định chiều rộng của popup
  width: {
    type: Number,
    default: 400,
  },
});
</script>

<style scoped>
@import url("./popup.css");
</style>
