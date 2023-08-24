<template>
  <div class="ms-toast-container">
    <MISAToast
      v-for="toast in toastArr"
      :key="toast.key"
      @click="$store.dispatch('toastStore/removeMessage', toast.key)"
      :title="toast.title"
      :type="toast.type"
    />
  </div>
</template>

<script>
import MISAToast from "./MISAToast.vue";
import { mapState } from "vuex";

export default {
  name: "MISAToastContainer",
  components: {
    MISAToast,
  },
  computed: {
    ...mapState("toastStore", {
      toastArr: (state) => state.toastArr,
    }),
  },
};
</script>

<style>
@import url("./toast.scss");
</style>
