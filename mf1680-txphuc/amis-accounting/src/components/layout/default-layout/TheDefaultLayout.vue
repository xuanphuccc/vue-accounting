<template>
  <div @contextmenu.prevent="openContextMenu" @mousedown.left="closeContextMenu" class="main">
    <!-- navbar -->
    <TheNavbar></TheNavbar>

    <div class="content-wrapper">
      <!-- sidebar -->
      <TheSidebar></TheSidebar>

      <!-- main content -->
      <div class="main-content">
        <slot></slot>
      </div>
    </div>

    <!-- toast message -->
    <MISAToastContainer></MISAToastContainer>

    <!-- context menu -->
    <MISAWindowContextMenu :pos="contextMenuState.pos" v-if="contextMenuState.isShow" />
  </div>
</template>

<script setup>
import TheNavbar from "./navbar/TheNavbar.vue";
import TheSidebar from "./sidebar/TheSidebar.vue";
import MISAToastContainer from "@/components/base/toast-message/MISAToastContainer.vue";
import MISAWindowContextMenu from "@/components/base/context-menu/MISAWindowContextMenu.vue";
import { ref } from "vue";

const contextMenuState = ref({
  isShow: false,
  pos: {
    x: 10,
    y: 10,
  },
});

/**
 * Description: Hàm xử lý mở context menu
 * Author: txphuc (30/06/2023)
 */
const openContextMenu = (e) => {
  contextMenuState.value = {
    isShow: true,
    pos: {
      x: e.clientX,
      y: e.clientY,
    },
  };
};
/**
 * Description: Hàm xử lý đóng context menu
 * Author: txphuc (30/06/2023)
 */
const closeContextMenu = () => {
  contextMenuState.value.isShow = false;
};
</script>

<style scoped></style>
