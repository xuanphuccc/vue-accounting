<template>
  <div class="ms-user-menu">
    <div class="ms-user-menu__avatar-wrapper">
      <img src="../../../assets/img/avatar-default.png" alt="" class="ms-user-menu__avatar" />
    </div>
    <div class="ms-user-menu__info-wrapper">
      <h4 class="ms-user-menu__display-name">Trần Xuân Phúc</h4>
      <p class="ms-user-menu__user-desc">dev.xuanphuc@gmail.com</p>
    </div>

    <div class="ms-user-menu__company">
      Công ty cổ phần MISA
      <MISAIcon size="16" icon="angle-right" />
    </div>

    <ul class="ms-user-menu__menu">
      <li class="ms-user-menu__menu-item"><MISAIcon icon="key" />Đổi mật khẩu</li>
      <li class="ms-user-menu__menu-item"><MISAIcon icon="user-circle" />Thiết lập tài khoản</li>
      <li class="ms-user-menu__menu-item"><MISAIcon icon="shield" />Thiết lập bảo mật</li>
      <li class="ms-user-menu__menu-item"><MISAIcon icon="newspaper" />Giấy phép & Thanh toán</li>
      <li class="ms-user-menu__menu-item"><MISAIcon icon="gift" />Giới thiệu - Tích điểm</li>
      <li class="ms-user-menu__menu-item"><MISAIcon icon="VN" />Ngôn ngữ: Tiếng Việt</li>
    </ul>

    <div class="ms-user-menu__sign-out">
      <MISAIcon icon="sign-out" />
      Đăng xuất
    </div>
  </div>
</template>

<script setup>
import MISAIcon from "../icon/MISAIcon.vue";
</script>

<style scoped>
.ms-user-menu {
  position: absolute;
  top: calc(100% + 8px);
  right: 16px;
  width: 300px;
  padding: 24px 0 16px;
  background: var(--white);
  box-shadow: var(--box-shadow-medium);
  border-radius: 4px;
  z-index: 4;
  user-select: none;
}

/* info */
.ms-user-menu__avatar-wrapper {
  display: flex;
  justify-content: center;
}

.ms-user-menu__avatar {
  width: 64px;
  height: 64px;
  object-fit: cover;
}

.ms-user-menu__info-wrapper {
  margin-top: 12px;
  margin-bottom: 16px;
}

.ms-user-menu__display-name {
  font-size: 20px;
  font-weight: 700;
  line-height: 20px;
  text-align: center;
}

.ms-user-menu__user-desc {
  font-size: 13px;
  line-height: 16px;
  margin-top: 4px;
  text-align: center;
  color: var(--secondary-text-color);
}

/* company */
.ms-user-menu__company {
  display: flex;
  height: 40px;
  align-items: center;
  justify-content: space-between;
  margin: 0 24px;
  padding: 0 12px;
  border: 1px solid var(--border-color);
  border-radius: 4px;
  cursor: pointer;
}

/* menu */
.ms-user-menu__menu {
  list-style: none;
  padding: 16px 0;
}

.ms-user-menu__menu-item {
  display: flex;
  align-items: center;
  height: 40px;
  column-gap: 8px;
  padding: 0 24px;
  cursor: pointer;
  transition: background 0.2s ease;
}

.ms-user-menu__menu-item:hover {
  background: var(--gray-100);
}

/* sign out */
.ms-user-menu__sign-out {
  display: flex;
  justify-content: center;
  column-gap: 8px;
  align-items: center;
  line-height: 40px;
  cursor: pointer;
  transition: background 0.2s ease;
}

.ms-user-menu__sign-out:hover {
  background: var(--gray-100);
}
</style>
