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
      @cancel="onCloseDialog"
      @ok="$store.dispatch('dialogStore/closeDialog')"
      v-if="dialogStore.active"
      :type="dialogStore.type"
      :title="dialogStore.title"
      :description="dialogStore.description"
    >
      <template #right-controls>
        <MISAButton
          v-for="button in dialogStore.buttons"
          :key="button.key"
          :color="button.color"
          :autoFocus="button.focus"
          @click="handleOnClickDialogButton(button.action)"
          >{{ button.text }}</MISAButton
        >
      </template>
    </MISADialog>
  </div>
</template>

<script>
import TheDefaultLayout from "./components/layout/default-layout/TheDefaultLayout.vue";
import TheEmptyLayout from "./components/layout/empty-layout/TheEmptyLayout.vue";
import MISADialog from "@/components/base/dialog/MISADialog.vue";
import MISAButton from "./components/base/button/MISAButton.vue";
import { mapState } from "vuex";
import { locale } from "devextreme/localization";

export default {
  name: "App",
  components: {
    TheDefaultLayout,
    TheEmptyLayout,
    MISADialog,
    MISAButton,
  },

  data: function () {
    return {};
  },

  computed: {
    ...mapState("dialogStore", {
      dialogStore: (state) => state,
    }),
  },

  methods: {
    /**
     * Description: Xử lý sự kiện click các button của dialog
     * Author: txphuc (25/08/2023)
     */
    handleOnClickDialogButton(action) {
      if (typeof action === "string") {
        this.$store.dispatch(`dialogStore/${action}`);
      } else if (typeof action === "function") {
        action();
      }
    },

    /**
     * Description: Xử lý sự kiện đóng dialog
     * Author: txphuc (31/08/2023)
     */
    onCloseDialog() {
      if (typeof this.dialogStore.cancelHandler == "function") {
        this.dialogStore.cancelHandler();
      } else {
        this.$store.dispatch("dialogStore/closeDialog");
      }
    },
  },

  /**
   * Description: Thay đổi tiêu đề trình duyệt theo ngôn ngữ
   * Author: txphuc (23/07/2023)
   */
  mounted: function () {
    document.title = this.$t("fullProductName");
    locale("vi");
  },
};
</script>

<style lang="scss"></style>
