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

        <!-- loading -->
        <div v-if="commonStore.loading" class="page-loading">
          <MISALoading />
        </div>
      </div>
    </div>

    <!-- toast message -->
    <MISAToastContainer></MISAToastContainer>
  </div>
</template>

<script>
import TheNavbar from "./navbar/TheNavbar.vue";
import TheSidebar from "./sidebar/TheSidebar.vue";
import MISAToastContainer from "@/components/base/toast/MISAToastContainer.vue";
import MISALoading from "@/components/base/spinner/MISALoading.vue";
import { mapState } from "vuex";

export default {
  name: "TheDefaultLayout",
  components: {
    TheNavbar,
    TheSidebar,
    MISAToastContainer,
    MISALoading,
  },

  computed: {
    ...mapState("commonStore", {
      commonStore: (state) => state,
    }),
  },
};
</script>

<style lang="scss">
@import url("./main-content.scss");
</style>
