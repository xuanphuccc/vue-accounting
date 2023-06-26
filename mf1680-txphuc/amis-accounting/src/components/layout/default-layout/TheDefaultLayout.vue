<template>
  <div class="main">
    <!-- navbar -->
    <TheNavbar @toggleSidebar="toggleSidebar" :isCompact="isCompactSidebar"></TheNavbar>

    <div class="content-wrapper">
      <!-- sidebar -->
      <TheSidebar :isCompact="isCompactSidebar"></TheSidebar>

      <!-- main content -->
      <div class="main-content">
        <slot></slot>
      </div>
    </div>

    <!-- toast message -->
    <div id="toast-list" class="toast-container">
      <!-- <div class="ms-toast success">
          <span
              class="ms-toast__icon ms-icon--circle-check-solid"
          ></span>
          <div class="ms-toast__content">
              <span class="ms-toast__title">Thành công!</span>
              <span class="ms-toast__text">Công việc đã bị xoá</span>
          </div>
          <span class="ms-toast__action">Hoàn tác</span>
          <span
              class="ms-toast__close ms-icon--times"
              title="Đóng"
          ></span>
      </div> -->
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import TheNavbar from "./navbar/TheNavbar.vue";
import TheSidebar from "./sidebar/TheSidebar.vue";

const isCompactSidebar = ref(false);

/**
 * Description: Xử lý đóng/mở Sidebar
 * Author: txphuc (24/06/2023)
 */
const toggleSidebar = () => {
  isCompactSidebar.value = !isCompactSidebar.value;
};
</script>

<style scoped></style>
