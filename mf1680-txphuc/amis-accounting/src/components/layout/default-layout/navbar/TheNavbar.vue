<template>
  <header :class="['navbar', { '--compact': globalStore.sidebar.isCompact }]">
    <div class="navbar__left">
      <div class="navbar__menu-icon" title="Menu"></div>
      <div class="navbar__logo-container">
        <div class="navbar__logo" title="AMIS Kế toán"></div>
        <div class="navbar__logo-text">Kế toán</div>
      </div>
    </div>
    <div class="navbar__right">
      <div class="navbar__title-wrap">
        <div
          @click="globalStore.toggleSidebar"
          class="navbar__sidebar-toggle ms-icon--menu-24"
        ></div>
        <div class="navbar__title">
          <p>Công ty Cổ phần MISA</p>
          <div class="navbar__title-toggle ms-icon--angle-down-24"></div>
        </div>
      </div>
      <div class="navbar__controls">
        <button title="Thông báo" class="navbar__button ms-icon--bell-24"></button>

        <div class="navbar__avatar-wrap">
          <img
            class="navbar__avatar"
            src="../../../../assets/img/avatar-default.png"
            title="Tài khoản"
            alt=""
          />
          <div class="navbar__avatar-name">
            <span>Trần Xuân Phúc</span>
            <span class="navbar__avatar-toggle ms-icon--angle-down-24"></span>
          </div>
        </div>
      </div>
    </div>
  </header>
</template>

<script setup>
import { useGlobalStore } from "@/stores/global-store";

const globalStore = useGlobalStore();
</script>

<style scoped>
@import url("./navbar.css");
</style>
