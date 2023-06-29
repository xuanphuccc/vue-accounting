<template>
  <!-- Default layout -->
  <the-default-layout v-if="$route.meta.layout === 'default'">
    <router-view></router-view>
  </the-default-layout>

  <!-- Empty layout -->
  <the-empty-layout v-if="$route.meta.layout === 'empty'">
    <router-view></router-view>
  </the-empty-layout>
</template>

<script setup>
import TheDefaultLayout from "./components/layout/default-layout/TheDefaultLayout.vue";
import TheEmptyLayout from "./components/layout/empty-layout/TheEmptyLayout.vue";
</script>
