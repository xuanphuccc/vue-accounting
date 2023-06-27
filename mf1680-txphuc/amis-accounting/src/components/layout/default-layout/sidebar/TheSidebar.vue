<template>
  <nav :class="['sidebar', { '--compact': props.isCompact }]">
    <ul @mouseleave="hideTippy" class="sidebar__menu">
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--dashboard-24"></span>
          <span class="sidebar__link-text">Tổng quan</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--money-24"></span>
          <span class="sidebar__link-text">Tiền mặt</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--bank-24"></span>
          <span class="sidebar__link-text">Tiền gửi</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--bag-24"></span>
          <span class="sidebar__link-text">Mua hàng</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--cart-24"></span>
          <span class="sidebar__link-text">Bán hàng</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--bill-24"></span>
          <span class="sidebar__link-text">Quản lý hoá đơn</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--warehouse-24"></span>
          <span class="sidebar__link-text">Kho</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--tools-24"></span>
          <span class="sidebar__link-text">Công cụ dụng cụ</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--car-24"></span>
          <span class="sidebar__link-text">Tài sản cố định</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--government-24"></span>
          <span class="sidebar__link-text">Thuế</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--price-24"></span>
          <span class="sidebar__link-text">Giá thành</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--money-book-24"></span>
          <span class="sidebar__link-text">Tổng hợp</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--money-circle-dash-24"></span>
          <span class="sidebar__link-text">Ngân sách</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--report-24"></span>
          <span class="sidebar__link-text">Báo cáo</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a @mouseenter="showTippy" href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--finance-24"></span>
          <span class="sidebar__link-text" title="Phân tích tài chính">Phân tích TC</span>
        </a>
      </li>
    </ul>

    <div ref="tippyRef" class="sidebar__tippy">Tổng quan</div>

    <div @click="$emit('toggle')" class="sidebar__toggle">
      <div class="sidebar__toggle-icon ms-icon--angle-left-24"></div>
      <div class="sidebar__toggle-text">Thu gọn</div>
    </div>
  </nav>
</template>

<script setup>
import { ref } from "vue";

defineEmits(["toggle"]);

const props = defineProps({
  // Trạng thái của Sidebar (mặc định/thu nhỏ)
  // isCompact = true (thu nhỏ)
  isCompact: {
    type: Boolean,
    default: false,
  },
});

const tippyRef = ref(null);

/**
 * Description: Hàm hiện tippy khi hover vào các sidebar item
 * khi ở chế độ thu nhỏ
 * Author: txphuc (26/06/2023)
 */
const showTippy = (e) => {
  try {
    if (tippyRef.value && props.isCompact) {
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
