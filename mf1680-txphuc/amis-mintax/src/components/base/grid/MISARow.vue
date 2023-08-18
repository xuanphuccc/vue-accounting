<template>
  <div :class="['ms-row', ...classNames]">
    <slot></slot>
  </div>
</template>

<script>
export default {
  name: "MISACol",
  props: {
    // Chỉ định khoảng cách giữa các cột (8, 16, 24)
    gutter: {
      type: Object,
      default() {
        return {
          x: 0,
          y: 0,
        };
      },
    },
  },

  computed: {
    /**
     * Description: Chuyển đổi prop thành tên class
     * Author: txphuc (25/06/2023)
     */
    classNames() {
      try {
        const classArr = [];

        if (this.gutter?.x) {
          classArr.push(`--gutter-x-${this.gutter.x}`);
        }
        if (this.gutter?.y) {
          classArr.push(`--gutter-y-${this.gutter.y}`);
        }

        return classArr;
      } catch (error) {
        console.warn(error);
        return [];
      }
    },
  },
};
</script>

<style scoped>
@import url("./grid.scss");
</style>
