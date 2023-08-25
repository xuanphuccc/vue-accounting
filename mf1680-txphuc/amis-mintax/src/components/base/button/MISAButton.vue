<template>
  <button
    @click.stop="handleOnClick"
    @focus="isShowOutline = true"
    @focusout="isShowOutline = false"
    @mousedown="isShowOutline = false"
    :class="[
      `ms-btn`,
      `ms-btn__color--${color}`,
      `ms-btn__type--${type}`,
      { 'ms-btn--icon': $slots.icon && !$slots.default },
      { 'ms-btn--with-icon': $slots.icon && $slots.default },
      { 'ms-btn--has-dropdown': $slots.dropdown && isOpenDropdown },
      { '--outline': isShowOutline },
      { '--rounded': isShowOutline },
    ]"
    :disabled="disabled"
    ref="buttonRef"
  >
    <!-- Trạng thái loading -->
    <MISASpinner v-if="loading" absolute />

    <div class="ms-btn__content" :style="{ opacity: loading ? 0 : 1 }">
      <!-- Chỉ chứa icon -->
      <div v-if="$slots.icon" class="ms-btn__icon">
        <slot name="icon"></slot>

        <!-- Dấu chấm thông báo -->
        <span v-if="badge" class="ms-btn__badge"></span>
      </div>

      <!-- Chứa text-->
      <div class="ms-btn__text">
        <slot></slot>
      </div>
    </div>

    <!-- Menu dropdown (nếu có) -->
    <div
      v-if="$slots.dropdown"
      @click.stop=""
      :class="['ms-btn__dropdown', `--pos-${dropdownPos}`, { '--active': isOpenDropdown }]"
    >
      <slot name="dropdown"></slot>
    </div>
  </button>
</template>

<script>
import MISASpinner from "../spinner/MISASpinner.vue";

export default {
  name: "MISAButton",
  emits: ["click"],
  components: {
    MISASpinner,
  },
  props: {
    // Loại button (default, rounded, link)
    type: {
      type: String,
      default: "default",
    },

    // Màu button (primary, secondary, danger)
    color: {
      type: String,
      default: "primary",
    },

    // Vô hiệu hoá button
    disabled: {
      type: Boolean,
      default: false,
    },

    // Vị trí dropdown (bottom-right | bottom-left)
    dropdownPos: {
      type: String,
      default: "bottom-right",
    },

    // Trạng thái loading
    loading: {
      type: Boolean,
      default: false,
    },

    // Dấu chám thông báo
    badge: {
      type: Boolean,
      default: false,
    },

    // Tự động focus vào button khi được mounted
    autoFocus: {
      type: Boolean,
      default: false,
    },
  },
  data: function () {
    return {
      isOpenDropdown: false,
      isShowOutline: false,
    };
  },
  methods: {
    /**
     * Description: Xử lý sự kiện click button
     * Author: txphuc (25/06/2023)
     */
    handleOnClick: function (event) {
      this.$emit("click", event);

      this.isOpenDropdown = !this.isOpenDropdown;
      this.isShowOutline = false;
    },

    /**
     * Description: Tắt dropdown của button
     * Author: txphuc (25/06/2023)
     */
    closeDropdown: function () {
      this.isOpenDropdown = false;
    },
  },

  /**
   * Description: Thêm sự kiện click outside để tắt dropdown
   * Author: txphuc (25/06/2023)
   */
  mounted: function () {
    if (this.autoFocus && this.$refs.buttonRef) {
      this.$refs.buttonRef.focus();
    }

    document.addEventListener("click", this.closeDropdown);
  },

  /**
   * Description: Loại bỏ event khi component được unmounted
   * Author: txphuc (25/06/2023)
   */
  destroyed: function () {
    document.removeEventListener("click", this.closeDropdown);
  },
};
</script>

<style scoped>
@import url("./button.scss");
</style>
