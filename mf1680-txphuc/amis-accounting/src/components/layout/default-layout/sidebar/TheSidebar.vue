<template>
  <nav :class="['sidebar', { '--compact': this.isCompact }]">
    <ul class="sidebar__menu">
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--dashboard-24"></span>
          <span class="sidebar__link-text">Tổng quan</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--money-24"></span>
          <span class="sidebar__link-text">Tiền mặt</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--bank-24"></span>
          <span class="sidebar__link-text">Tiền gửi</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--bag-24"></span>
          <span class="sidebar__link-text">Mua hàng</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--cart-24"></span>
          <span class="sidebar__link-text">Bán hàng</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--bill-24"></span>
          <span class="sidebar__link-text">Quản lý hoá đơn</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--warehouse-24"></span>
          <span class="sidebar__link-text">Kho</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--tools-24"></span>
          <span class="sidebar__link-text">Công cụ dụng cụ</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--car-24"></span>
          <span class="sidebar__link-text">Tài sản cố định</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--government-24"></span>
          <span class="sidebar__link-text">Thuế</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--price-24"></span>
          <span class="sidebar__link-text">Giá thành</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--money-book-24"></span>
          <span class="sidebar__link-text">Tổng hợp</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--money-circle-dash-24"></span>
          <span class="sidebar__link-text">Ngân sách</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--report-24"></span>
          <span class="sidebar__link-text">Báo cáo</span>
        </a>
      </li>
      <li class="sidebar__menu-item">
        <a href="#" class="sidebar__link">
          <span class="sidebar__link-icon ms-icon--finance-24"></span>
          <span class="sidebar__link-text" title="Phân tích tài chính">Phân tích TC</span>
        </a>
      </li>
    </ul>

    <div class="sidebar__tippy">Tổng quan</div>
  </nav>
</template>

<script>
export default {
  props: {
    isCompact: {
      type: Boolean,
      default: false
    }
  }
};
</script>

<style scoped>
@import url("./sidebar.css");
</style>
