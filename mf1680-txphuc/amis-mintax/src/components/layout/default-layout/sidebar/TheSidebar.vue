<template>
  <nav :class="['sidebar', { '--compact': false }]">
    <ul @mouseleave="hideTippy" class="sidebar__menu">
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="tax" />
          <span class="sidebar__link-text"> Đăng ký mã số thuế </span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="family" />
          <span class="sidebar__link-text"> Đăng ký người phụ thuộc </span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="file" />
          <span class="sidebar__link-text"> Khai thuế theo kỳ </span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="tax-deduction" />
          <span class="sidebar__link-text"> Chứng từ khấu trừ thuế </span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="box" />
          <span class="sidebar__link-text"> Quyết toán thuế </span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="procedure" />
          <span class="sidebar__link-text"> Thủ tục </span>
        </router-link>
      </li>

      <li class="sidebar__menu-item">
        <router-link :to="{ name: 'home' }" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="tax-report" />
          <span class="sidebar__link-text"> Báo cáo </span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link :to="{ name: 'employee' }" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="person-file" />
          <span class="sidebar__link-text"> Người nộp thuế </span>
        </router-link>
      </li>

      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="tax-service" />
          <span class="sidebar__link-text"> Đăng ký dịch vụ thuế </span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="mintax-setting" />
          <span class="sidebar__link-text"> Thiết lập </span>
        </router-link>
      </li>
      <li class="sidebar__menu-item">
        <router-link to="/notfound" @mouseenter="showTippy" class="sidebar__link">
          <MISAIcon icon="trash" />
          <span class="sidebar__link-text"> Thùng rác </span>
        </router-link>
      </li>
    </ul>

    <div ref="tippyRef" class="sidebar__tippy">Tổng quan</div>

    <div class="sidebar__toggle">
      <div class="sidebar__toggle-icon">
        <MISAIcon icon="angle-left" />
      </div>
      <div class="sidebar__toggle-text">Thu gọn</div>
    </div>
  </nav>
</template>

<script>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
// import { useGlobalStore } from "@/stores/global-store";
// import MISAResource from "@/resource/resource";

export default {
  name: "TheSidebar",
  components: {
    MISAIcon,
  },
  data: function () {
    return {
      tippyRef: null,
    };
  },
  methods: {
    /**
     * Description: Hàm hiện tippy khi hover vào các sidebar item
     * khi ở chế độ thu nhỏ
     * Author: txphuc (26/06/2023)
     */
    showTippy: function (e) {
      try {
        if (this.$refs.tippyRef) {
          this.$refs.tippyRef.style.display = "block";
          const linkElement = e.target;
          const linkRect = linkElement.getBoundingClientRect();
          const tippyRect = this.$refs.tippyRef.getBoundingClientRect();

          // set tippy position
          this.$refs.tippyRef.style.top =
            linkRect.top + linkRect.height / 2 - 56 - tippyRect.height / 2 + "px";

          // set tippy content
          this.$refs.tippyRef.textContent = linkElement.textContent;
        }
      } catch (error) {
        console.warn(error);
      }
    },

    /**
     * Description: Hàm ẩn tippy khi di chuột ra ngoài sidebar
     * Author: txphuc (26/06/2023)
     */
    hideTippy: function () {
      try {
        if (this.$refs.tippyRef) {
          this.$refs.tippyRef.style.display = "none";
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
};

// const globalStore = useGlobalStore();
</script>

<style lang="scss" scoped>
@import url("./sidebar.scss");
</style>
