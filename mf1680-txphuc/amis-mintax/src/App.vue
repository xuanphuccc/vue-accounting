<template>
  <div id="app">
    <!-- Default layout -->
    <the-default-layout v-if="$route.meta.layout === 'default'">
      <router-view></router-view>
    </the-default-layout>

    <!-- Empty layout -->
    <the-empty-layout v-if="$route.meta.layout === 'empty'">
      <router-view></router-view>
    </the-empty-layout>

    <!-- dialog thông báo lỗi -->
    <MISADialog
      @cancel="$store.dispatch('dialogStore/closeDialog')"
      @ok="$store.dispatch('dialogStore/closeDialog')"
      v-if="dialogStore.active"
      :type="dialogStore.type"
      :title="dialogStore.title"
      :description="dialogStore.description"
      ok-text="Đóng"
    />
  </div>
</template>

<script>
import TheDefaultLayout from "./components/layout/default-layout/TheDefaultLayout.vue";
import TheEmptyLayout from "./components/layout/empty-layout/TheEmptyLayout.vue";
import MISADialog from "@/components/base/dialog/MISADialog.vue";
import { mapState } from "vuex";

export default {
  name: "App",
  components: {
    TheDefaultLayout,
    TheEmptyLayout,
    MISADialog,
  },

  data: function () {
    return {};
  },

  computed: {
    ...mapState("dialogStore", {
      dialogStore: (state) => state,
    }),
  },

  /**
   * Description: Thay đổi tiêu đề trình duyệt theo ngôn ngữ
   * Author: txphuc (23/07/2023)
   */
  mounted: function () {
    document.title = this.$t("fullProductName");
  },
};
</script>

<style lang="scss"></style>
