<template>
  <!-- Default layout -->
  <the-default-layout v-if="$route.meta.layout === 'default'">
    <router-view></router-view>
  </the-default-layout>

  <!-- Empty layout -->
  <the-empty-layout v-if="$route.meta.layout === 'empty'">
    <router-view></router-view>
  </the-empty-layout>

  <!-- dialog thông báo lỗi -->
  <Teleport to="#app">
    <MISADialog
      v-if="dialogStore.active"
      :type="dialogStore.type"
      :title="dialogStore.title"
      :description="dialogStore.description"
      @cancel="dialogStore.closeDialog"
      @ok="dialogStore.closeDialog"
      :ok-text="MISAResource[globalStore.lang]?.Button?.OK"
    />
  </Teleport>
</template>

<script setup>
import TheDefaultLayout from "./components/layout/default-layout/TheDefaultLayout.vue";
import TheEmptyLayout from "./components/layout/empty-layout/TheEmptyLayout.vue";
import MISADialog from "@/components/base/dialog/MISADialog.vue";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "./stores/global-store";
import { useDialogStore } from "./stores/dialog-store";
import { onMounted } from "vue";

const globalStore = useGlobalStore();
const dialogStore = useDialogStore();

/**
 * Description: Thay đổi tiêu đề trình duyệt theo ngôn ngữ
 * Author: txphuc (23/07/2023)
 */
onMounted(() => {
  document.title = MISAResource[globalStore.lang]?.FullProductName;
});
</script>
