<template>
  <div class="main">
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
    <!-- <MISAToastContainer></MISAToastContainer> -->
  </div>
</template>

<script>
import TheNavbar from "./navbar/TheNavbar.vue";
import TheSidebar from "./sidebar/TheSidebar.vue";
// import MISAToastContainer from "@/components/base/toast-message/MISAToastContainer.vue";

export default {
  name: "TheDefaultLayout",
  components: {
    TheNavbar,
    TheSidebar,
  },
};
</script>

<style lang="scss">
@import url("./main-content.scss");
</style>
