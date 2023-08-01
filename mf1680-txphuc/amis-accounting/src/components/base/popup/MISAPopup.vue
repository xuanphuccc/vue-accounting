<template>
  <div @keydown.stop="handleOnKeyDown" tabindex="-1" class="ms-popup-overlay">
    <div @click.stop="" class="ms-popup" :style="{ width: props.width + 'px' }">
      <div class="ms-popup__header">
        <h4 class="ms-popup__title">{{ props.title }}</h4>
        <div class="ms-popup__header-controls">
          <slot name="header-controls"></slot>
        </div>
      </div>
      <div
        @click="$emit('close')"
        class="ms-popup__close"
        v-tippy="{ content: MISAResource[globalStore.lang]?.Popup?.Close }"
      >
        <MISAIcon icon="times" />
      </div>

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
import enums from "@/helper/enum";
import MISAIcon from "../icon/MISAIcon.vue";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "@/stores/global-store";

const emit = defineEmits(["close", "submit", "submitAndContinue"]);

const props = defineProps({
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

const globalStore = useGlobalStore();

/**
 * Description: Xử lý sự kiện bản phím
 * Author: txphuc (01/08/2023)
 */
const handleOnKeyDown = (e) => {
  const keyCode = e.keyCode;
  const shiftKey = e.shiftKey;
  const ctrlKey = e.ctrlKey;

  switch (keyCode) {
    case enums.key.S:
      if (shiftKey && ctrlKey) {
        emit("submitAndContinue");
      } else if (ctrlKey) {
        e.preventDefault();
        emit("submit");
      }
      break;
    case enums.key.ESC:
      emit("close");
      break;
    default:
      break;
  }
};
</script>

<style scoped>
@import url("./popup.css");
</style>
