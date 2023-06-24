<template>
  <div class="main">
    <!-- navbar -->
    <TheNavbar @toggleSidebar="this.toggleSidebar" :isCompact="this.isCompactSidebar"></TheNavbar>

    <div class="content-wrapper">
      <!-- sidebar -->
      <TheSidebar :isCompact="this.isCompactSidebar"></TheSidebar>

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

<script>
import TheNavbar from "./navbar/TheNavbar.vue";
import TheSidebar from "./sidebar/TheSidebar.vue";

export default {
  data() {
    return {
      isCompactSidebar: false,
    };
  },
  methods: {
    toggleSidebar() {
      this.isCompactSidebar = !this.isCompactSidebar;
    },
  },
  components: {
    TheNavbar,
    TheSidebar,
  },
};
</script>

<style scoped></style>
