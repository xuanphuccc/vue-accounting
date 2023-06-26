<template>
  <button
    @click.stop="handleOnClick"
    :class="[
      `ms-btn`,
      `ms-btn--${props.type}`,
      { 'ms-btn--icon': props.icon && !$slots.default },
      { 'ms-btn--with-icon': props.icon && $slots.default },
    ]"
    :disabled="props.disabled"
  >
    <span v-if="props.icon" :class="[`ms-btn__icon`, props.icon]"></span>
    <slot></slot>

    <div
      v-if="$slots.dropdown"
      @click.stop=""
      :class="['ms-btn__dropdown', `--pos-${props.dropdownPos}`, { '--active': isOpenDropdown }]"
    >
      <slot name="dropdown"></slot>
    </div>
  </button>
</template>

<script setup>
import { ref, onMounted, onUnmounted } from "vue";

const isOpenDropdown = ref(false);

const emit = defineEmits(["click"]);

const props = defineProps({
  // Tên class của icon
  icon: String,

  // Loại button (primary, secondary, danger, link)
  type: {
    type: String,
    default: "primary",
  },

  // Vô hiệu hoá button
  disabled: {
    type: Boolean,
    default: false,
  },

  // Vị trí dropdown
  dropdownPos: {
    type: String,
    default: "bottom-right",
  },
});

/**
 * Description: Xử lý sự kiện click button
 * Author: txphuc (25/06/2023)
 */
const handleOnClick = (event) => {
  emit("click", event);

  isOpenDropdown.value = !isOpenDropdown.value;
};

/**
 * Description: Tắt dropdown của button
 * Author: txphuc (25/06/2023)
 */
const closeDropdown = () => {
  isOpenDropdown.value = false;
};

onMounted(() => {
  document.addEventListener("click", closeDropdown);
});

/**
 * Description: Loại bỏ event khi component được unmounted
 * Author: txphuc (25/06/2023)
 */
onUnmounted(() => {
  document.removeEventListener("click", closeDropdown);
});
</script>

<style scoped>
@import url("./button.css");
</style>
