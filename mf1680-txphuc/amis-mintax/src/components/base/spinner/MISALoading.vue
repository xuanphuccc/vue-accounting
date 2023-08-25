<template>
  <div class="ms-loading">
    <MISASpinner :size="48" :width="4" />
  </div>
</template>

<script>
import MISASpinner from "./MISASpinner.vue";

export default {
  name: "MISALoading",
  components: {
    MISASpinner,
  },
};
</script>

<style></style>
