<template>
  <div @click.stop="" class="ms-user-menu">
    <div class="ms-user-menu__avatar-wrapper">
      <img src="../../../assets/img/avatar-default.png" alt="" class="ms-user-menu__avatar" />
    </div>
    <div class="ms-user-menu__info-wrapper">
      <h4 class="ms-user-menu__display-name">{{ $t("userMenu.userFullName") }}</h4>
      <p class="ms-user-menu__user-desc">dev.xuanphuc@gmail.com</p>
    </div>

    <div class="ms-user-menu__company">
      {{ $t("company") }}
      <div class="ms-user-menu__company-icon">
        <MISAIcon size="16" icon="angle-right" />
      </div>
    </div>

    <ul class="ms-user-menu__menu">
      <li class="ms-user-menu__menu-item">
        <div class="ms-user-menu__item-icon">
          <MISAIcon icon="key" />
        </div>
        {{ $t("userMenu.changePassword") }}
      </li>
      <li class="ms-user-menu__menu-item">
        <div class="ms-user-menu__item-icon">
          <MISAIcon icon="user-circle" />
        </div>
        {{ $t("userMenu.accountSettings") }}
      </li>
      <li class="ms-user-menu__menu-item">
        <div class="ms-user-menu__item-icon">
          <MISAIcon icon="shield" />
        </div>
        {{ $t("userMenu.securitySettings") }}
      </li>
      <li class="ms-user-menu__menu-item">
        <div class="ms-user-menu__item-icon">
          <MISAIcon icon="gift" />
        </div>
        {{ $t("userMenu.referralsEarnPoints") }}
      </li>
      <li @click="toggleLanguageDropdown" class="ms-user-menu__menu-item">
        <MISAIcon icon="vi-VN" />
        {{ $t("userMenu.language") }}: Việt Nam
        <div class="language-dropdown__menu-icon">
          <MISAIcon size="16" icon="angle-down" />
        </div>
        <div class="language-dropdown">
          <ul v-if="isOpenLanguageDropdown" class="language-dropdown__menu">
            <li
              v-for="language in [
                { value: 'vi', title: 'Việt Nam' },
                { value: 'en', title: 'English' },
              ]"
              :key="language.value"
              @click="changeLanguage(language.value)"
              :class="[
                'language-dropdown__menu-item',
                { '--active': language.value == $i18n.locale },
              ]"
            >
              {{ language.title }}
              <div class="language-dropdown__item-icon">
                <MISAIcon icon="check" />
              </div>
            </li>
          </ul>
        </div>
      </li>
    </ul>

    <div class="ms-user-menu__sign-out">
      <div class="ms-user-menu__sign-out-icon">
        <MISAIcon icon="sign-out" />
      </div>
      {{ $t("userMenu.signOut") }}
    </div>
  </div>
</template>

<script>
import MISAIcon from "../icon/MISAIcon.vue";

export default {
  name: "MISAUserMenu",
  components: {
    MISAIcon,
  },
  data: function () {
    return {
      isOpenLanguageDropdown: false,
    };
  },

  computed: {
    /**
     * Description: Chuyển đổi đối tượng resource sang mảng
     * để chọn ngôn ngữ
     * Author: txphuc (12/07/2023)
     */
    languages() {
      return [];
    },
  },

  methods: {
    /**
     * Description: Hàm đóng/mở language dropdown
     * Author: txphuc (02/09/2023)
     */
    toggleLanguageDropdown() {
      this.isOpenLanguageDropdown = !this.isOpenLanguageDropdown;
    },

    /**
     * Description: Xử lý thay đổi ngôn ngữ
     * Author: txphuc (02/09/2023)
     */
    changeLanguage(language) {
      localStorage.setItem("lang", language);
      window.location.reload();
    },
  },
};
</script>

<style scoped>
@import url("./user-menu.scss");
</style>
