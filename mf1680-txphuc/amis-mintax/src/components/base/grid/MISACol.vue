<template>
  <div :class="classNames">
    <slot></slot>
  </div>
</template>

<script>
export default {
  name: "MISACol",
  props: {
    // Độ rộng của một cột: từ 1 - 12
    span: [Number, String],
  },

  computed: {
    /**
     * Description: Xử lý chuyển đổi prop thành tên class
     * Author: txphuc (25/06/2023)
     */
    classNames() {
      const classArr = ["ms-col"];

      if (this.span) {
        classArr.push(`ms-col--${this.span}`);
      } else {
        classArr.push("ms-col--auto");
      }

      return classArr;
    },
  },
};
</script>

<style scoped>
@import url("./grid.scss");
</style>
