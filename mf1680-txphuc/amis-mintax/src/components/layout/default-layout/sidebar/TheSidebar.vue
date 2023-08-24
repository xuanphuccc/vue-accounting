<template>
  <nav :class="['sidebar', { '--compact': this.$store.state.commonStore.isCompactSidebar }]">
    <ul class="sidebar__menu">
      <li
        v-for="item in sidebarItems"
        :key="item.key"
        @mouseenter="showTippy"
        @mouseleave="hideTippy"
        class="sidebar__menu-item"
      >
        <router-link :to="item.url" class="sidebar__link">
          <MISAIcon :icon="item.icon" />
          <span class="sidebar__link-text">{{ item.title }}</span>
        </router-link>
      </li>
    </ul>

    <div ref="tippyRef" class="sidebar__tippy">{{ $t("sidebar.report") }}</div>

    <div @click="toggleSidebar" class="sidebar__toggle">
      <div class="sidebar__toggle-icon">
        <MISAIcon icon="angle-left" />
      </div>
      <div class="sidebar__toggle-text">{{ $t("sidebar.collapse") }}</div>
    </div>
  </nav>
</template>

<script>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";

export default {
  name: "TheSidebar",
  components: {
    MISAIcon,
  },
  data: function () {
    return {
      sidebarItems: [
        {
          key: 1,
          url: "/notfound",
          title: this.$t("sidebar.registerTaxId"),
          icon: "tax",
        },
        {
          key: 2,
          url: "/notfound",
          title: this.$t("sidebar.registerDependents"),
          icon: "family",
        },
        {
          key: 3,
          url: "/notfound",
          title: this.$t("sidebar.taxReportingByPeriod"),
          icon: "file",
        },
        {
          key: 4,
          url: "/notfound",
          title: this.$t("sidebar.taxDeductionReceipts"),
          icon: "tax-deduction",
        },
        {
          key: 5,
          url: "/notfound",
          title: this.$t("sidebar.taxFinalization"),
          icon: "box",
        },
        {
          key: 6,
          url: "/notfound",
          title: this.$t("sidebar.procedure"),
          icon: "procedure",
        },
        {
          key: 7,
          url: "/",
          title: this.$t("sidebar.report"),
          icon: "tax-report",
        },
        {
          key: 8,
          url: "/employee",
          title: this.$t("sidebar.taxpayer"),
          icon: "person-file",
        },
        {
          key: 9,
          url: "/notfound",
          title: this.$t("sidebar.taxServiceRegistration"),
          icon: "tax-service",
        },
        {
          key: 10,
          url: "/notfound",
          title: this.$t("sidebar.configuration"),
          icon: "mintax-setting",
        },
        {
          key: 11,
          url: "/notfound",
          title: this.$t("sidebar.trashBin"),
          icon: "trash",
        },
      ],
    };
  },
  methods: {
    /**
     * Description: Thu gọn/mở rộng sidebar
     * Author: txphuc (15/08/2023)
     */
    toggleSidebar: function () {
      this.$store.commit("commonStore/toggleSidebar");
    },

    /**
     * Description: Hàm hiện tippy khi hover vào các sidebar item
     * khi ở chế độ thu nhỏ
     * Author: txphuc (26/06/2023)
     */
    showTippy: function (e) {
      try {
        if (this.$refs.tippyRef && this.$store.state.commonStore.isCompactSidebar) {
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
</script>

<style lang="scss" scoped>
@import url("./sidebar.scss");
</style>
