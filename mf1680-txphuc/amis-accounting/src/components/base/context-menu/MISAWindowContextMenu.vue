<template>
  <div ref="contextMenuRef" class="ms-window-context-menu">
    <MISAContextMenu>
      <MISAContextItem icon="ms-icon--history-24">Lịch sử</MISAContextItem>
      <MISAContextItem icon="ms-icon--download">Tải xuống</MISAContextItem>
      <MISAContextItem icon="ms-icon--bookmark">Dấu trang</MISAContextItem>
      <MISAContextItem icon="ms-icon--search-doc-24">Tab gần đây</MISAContextItem>

      <MISADivider />

      <MISAContextItem icon="ms-icon--share-24">Chia sẻ</MISAContextItem>
      <MISAContextItem icon="ms-icon--setting-24">Cài đặt</MISAContextItem>
    </MISAContextMenu>
  </div>
</template>

<script setup>
import MISAContextMenu from "./MISAContextMenu.vue";
import MISAContextItem from "./MISAContextItem.vue";
import MISADivider from "@/components/base/divider/MISADivider.vue";
import { onMounted, ref, watch } from "vue";

const props = defineProps({
  // Vị trí của context menu
  pos: {
    type: Object,
    default() {
      return {
        x: 0,
        y: 0,
      };
    },
    required: true,
  },
});

const contextMenuRef = ref(null);

/**
 * Description: Hàm xác định vị trí của context menu
 * Author: txphuc (30/06/2023)
 */
const handleContextMenu = () => {
  try {
    if (contextMenuRef.value && props.pos) {
      contextMenuRef.value.style.top = props.pos.y + "px";
      contextMenuRef.value.style.left = props.pos.x + "px";
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Theo dõi và thay đổi vị trí của contex menu
 * Author: txphuc (30/06/2023)
 */
onMounted(handleContextMenu);
watch(() => props.pos, handleContextMenu, { deep: true });
</script>

<style scoped>
.ms-window-context-menu {
  position: fixed;
  top: 10px;
  left: 10px;
  z-index: 10;
}
</style>
