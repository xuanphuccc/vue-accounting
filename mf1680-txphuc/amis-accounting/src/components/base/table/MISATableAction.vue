<template>
  <div
    @dblclick.stop=""
    @click.stop="handleActionClick"
    class="ms-table__action-btn"
    v-tooltip="props.title"
  >
    <div :class="['ms-table__action-icon', props.icon]"></div>

    <div :class="['ms-table__action-dropdown', { '--active': isOpenDropdownState }]">
      <slot name="action-dropdown"></slot>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted, onUnmounted } from "vue";

const emit = defineEmits(["click"]);

const props = defineProps({
  // Icon của nút
  icon: {
    type: String,
    default: "ms-icon--ellipsis-24",
  },
  title: {
    type: String,
    default: "",
  },
});

const isOpenDropdownState = ref(false);

/**
 * Description: Hàm xử lý sự kiện click button
 * Author: txphuc (25/06/2023)
 */
const handleActionClick = () => {
  toggleDropdown();

  emit("click");
};

/**
 * Description: Hàm đóng/mở dropdown
 * Author: txphuc (25/06/2023)
 */
const toggleDropdown = () => {
  isOpenDropdownState.value = !isOpenDropdownState.value;
};

/**
 * Description: Hàm đóng dropdown
 * Author: txphuc (25/06/2023)
 */
const closeDropdown = () => {
  isOpenDropdownState.value = false;
};

/**
 * Description: Xử lý đóng dropdown khi click ra ngoài
 * Author: txphuc (25/06/2023)
 */
onMounted(() => {
  document.addEventListener("click", closeDropdown);
});

/**
 * Description: Huỷ bỏ sự kiện click của document
 * Author: txphuc (25/06/2023)
 */
onUnmounted(() => {
  document.removeEventListener("click", closeDropdown);
});
</script>

<style scoped>
@import url("./table.css");
</style>
