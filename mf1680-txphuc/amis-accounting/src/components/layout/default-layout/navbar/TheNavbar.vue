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
        <div @click="globalStore.toggleSidebar" class="navbar__sidebar-toggle">
          <MISAIcon icon="menu" />
        </div>

        <div class="navbar__title">
          <p>Công ty Cổ phần MISA</p>

          <div class="navbar__title-toggle">
            <MISAIcon icon="angle-down" />
          </div>
        </div>
      </div>
      <div class="navbar__controls">
        <div title="Thông báo" class="navbar__button">
          <MISAIcon icon="bell" />
        </div>

        <div class="navbar__avatar-wrap">
          <img
            class="navbar__avatar"
            src="../../../../assets/img/avatar-default.png"
            title="Tài khoản"
            alt=""
          />
          <div class="navbar__avatar-name">
            <span>Trần Xuân Phúc</span>
            <div class="navbar__avatar-toggle">
              <MISAIcon icon="angle-down" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </header>
</template>

<script setup>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import { useGlobalStore } from "@/stores/global-store";

const globalStore = useGlobalStore();
</script>

<style scoped>
@import url("./navbar.css");
</style>
