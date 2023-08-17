<template>
  <div class="ms-table__footer">
    <p class="total-row">
      <span>Tổng số: </span>
      <span class="text-bold">{{ this.totalRecords }}</span>
      {{ " " }}<span>bản ghi</span>
    </p>

    <div class="ms-table__page-infor">
      <!-- page size dropdown -->
      <div class="ms-table__page-size">
        <div class="ms-table__page-size-text">Số bản ghi/trang</div>

        <!-- <MISASelect
          :model-value="this.pageSize"
          @update:model-value="handleSelectPageSize"
          :options="[
            { label: 10, value: 10 },
            { label: 25, value: 25 },
            { label: 50, value: 50 },
            { label: 100, value: 100 },
          ]"
          width="84"
          dropdown-pos="top"
        /> -->
      </div>

      <!-- records range -->
      <div class="ms-table__records-range">
        <p>
          {{ recordsRange.min }} -
          <span class="text-bold">{{ recordsRange.max }}</span>
          bản ghi
        </p>
      </div>

      <!-- page controls -->
      <div class="ms-table__page-controls">
        <span
          @click="handlePrevPage"
          :class="['ms-table__prev-btn', { '--disable': this.currentPage <= 1 }]"
          ><MISAIcon icon="angle-left"
        /></span>
        <span
          @click="handleNextPage"
          :class="['ms-table__next-btn', { '--disable': this.currentPage >= this.totalPage }]"
        >
          <MISAIcon icon="angle-right" />
        </span>
      </div>
    </div>
  </div>
</template>

<script>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";

export default {
  name: "MISATableFooter",
  emits: ["next-page", "prev-page", "select-page-size"],
  components: {
    MISAIcon,
  },
  props: {
    // Trang hiện tại
    currentPage: {
      type: Number,
      default: 1,
    },

    // Tổng số trang
    totalPage: {
      type: Number,
      default: 0,
    },

    // Tổng số bản ghi
    totalRecords: {
      type: Number,
      default: 0,
    },

    // Số phần tử trên trang
    pageSize: {
      type: Number,
      default: 0,
    },
  },
  computed: {
    /**
     * Description: Tính toán khoảng của các phần tử
     * đang hiển thị trên trang hiện tại (phân trang)
     * Author: txphuc (30/06/2023)
     */
    recordsRange: function () {
      if (this.currentPage && this.pageSize) {
        let maxRange = this.currentPage * this.pageSize;
        let minRange = maxRange - this.pageSize + 1;

        if (this.currentPage === this.totalPage) {
          maxRange = this.totalRecords;
        }

        return {
          min: minRange,
          max: maxRange,
        };
      } else {
        return {
          min: 0,
          max: 0,
        };
      }
    },
  },
  methods: {
    /**
     * Description: Xử lý sự kiện chuyển trang tiếp theo
     * Author: txphuc (30/06/2023)
     */
    handleNextPage() {
      if (this.currentPage && this.totalPage && this.currentPage < this.totalPage) {
        const nextPage = this.currentPage + 1;
        this.$emit("next-page", nextPage);
      }
    },

    /**
     * Description: Xử lý sự kiện chuyển trang trước đó
     * Author: txphuc (30/06/2023)
     */
    handlePrevPage() {
      if (this.currentPage && this.currentPage > 1) {
        const prevPage = this.currentPage - 1;
        this.$emit("prev-page", prevPage);
      }
    },

    /**
     * Description: Xử lý chọn page size
     * Author: txphuc (30/06/2023)
     */
    handleSelectPageSize(pageSize) {
      if (this.pageSize !== pageSize) {
        this.$emit("select-page-size", pageSize);
      }
    },
  },
};
</script>

<style scoped>
@import url("./table-footer.scss");
</style>
