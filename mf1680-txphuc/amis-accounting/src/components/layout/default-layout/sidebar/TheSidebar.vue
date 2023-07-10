<template>
  <nav :class="['sidebar', { '--compact': globalStore.sidebar.isCompact }]">
    <ul @mouseleave="hideTippy" class="sidebar__menu">
      <li class="sidebar__menu-item">
        <router-link :to="{ name: 'home' }" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="dashboard" />
          <span class="sidebar__link-text">Tổng quan</span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link :to="{ name: 'employee' }" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="user" />
          <span class="sidebar__link-text">Nhân viên</span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="money" />
          <span class="sidebar__link-text">Tiền mặt</span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="bag" />
          <span class="sidebar__link-text">Mua hàng</span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="cart" />
          <span class="sidebar__link-text">Bán hàng</span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="bill" />
          <span class="sidebar__link-text">Quản lý hoá đơn</span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="warehouse" />
          <span class="sidebar__link-text">Kho</span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="government" />
          <span class="sidebar__link-text">Thuế</span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="report" />
          <span class="sidebar__link-text">Báo cáo</span>
        </router-link>
      </li>
    </ul>

    <div ref="tippyRef" class="sidebar__tippy">Tổng quan</div>

    <div @click="globalStore.toggleSidebar" class="sidebar__toggle">
      <div class="sidebar__toggle-icon">
        <MISAIcon icon="angle-left" />
      </div>
      <div class="sidebar__toggle-text">Thu gọn</div>
    </div>
  </nav>
</template>

<script setup>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import { ref } from "vue";
import { useGlobalStore } from "@/stores/global-store";

const tippyRef = ref(null);

const globalStore = useGlobalStore();

/**
 * Description: Hàm hiện tippy khi hover vào các sidebar item
 * khi ở chế độ thu nhỏ
 * Author: txphuc (26/06/2023)
 */
const showTippy = (e) => {
  try {
    if (tippyRef.value && globalStore.sidebar.isCompact) {
      tippyRef.value.style.display = "block";
      const linkElement = e.target;
      const linkRect = linkElement.getBoundingClientRect();
      const tippyRect = tippyRef.value.getBoundingClientRect();

      // set tippy position
      tippyRef.value.style.top =
        linkRect.top + linkRect.height / 2 - 56 - tippyRect.height / 2 + "px";

      // set tippy content
      tippyRef.value.textContent = linkElement.textContent;
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Hàm ẩn tippy khi di chuột ra ngoài sidebar
 * Author: txphuc (26/06/2023)
 */
const hideTippy = () => {
  try {
    if (tippyRef.value) {
      tippyRef.value.style.display = "none";
    }
  } catch (error) {
    console.log(error);
  }
};
</script>

<style scoped>
@import url("./sidebar.css");
</style>
