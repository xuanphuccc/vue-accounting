<template>
  <div
    ref="iconRef"
    :class="[
      `ms-icon--${this.size}`,
      `ms-icon--${this.icon}-${this.size}`,
      { 'ms-icon--no-color': this.noColor },
    ]"
  ></div>
</template>

<script>
export default {
  name: "MISAIcon",
  props: {
    // Kích thước của icon bao gồm: 24, 20, 16
    size: {
      type: [Number, String],
      default: 24,
    },

    // Loại icon
    icon: {
      type: [String],
      default: "bag",
    },

    // Dành cho icon không cần set màu sắc
    noColor: {
      type: Boolean,
      default: false,
    },
  },
  data: function () {
    return {
      iconRef: null,
    };
  },
  methods: {
    /**
     * Description: Sự kiện click vào icon
     * Author: txphuc (31/07/2023)
     */
    click: function () {
      if (this.$refs.iconRef) {
        this.$refs.iconRef.click();
      }
    },

    /**
     * Description: Sự kiện focus vào icon
     * Author: txphuc (31/07/2023)
     */
    focus: function () {
      if (this.$refs.iconRef) {
        this.$refs.iconRef.focus();
      }
    },
  },
};
</script>

<style lang="scss" scoped>
@import url("./icon-base.scss");
@import url("./icons.scss");
</style>
