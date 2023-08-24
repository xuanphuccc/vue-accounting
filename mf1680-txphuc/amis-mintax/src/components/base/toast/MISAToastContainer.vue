<template>
  <div class="ms-toast-container">
    <MISAToast />
  </div>
</template>

<script>
import MISAToast from "./MISAToast.vue";

export default {
  name: "MISAToastContainer",
  components: {
    MISAToast,
  },
};
</script>

<style>
.ms-toast-container {
  position: fixed;
  top: 4px;
  left: 50%;
  transform: translateX(-50%);
}
</style>
