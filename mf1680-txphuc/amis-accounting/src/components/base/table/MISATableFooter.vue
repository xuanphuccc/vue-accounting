<template>
  <div class="ms-table__footer">
    <p class="total-row">
      <span>{{ MISAResource[globalStore.lang]?.Paging?.TotalRecords }}: </span>
      <span class="text-bold">{{ props.totalRecords }}</span>
    </p>

    <div class="ms-table__page-infor">
      <!-- page size dropdown -->
      <div class="ms-table__page-size">
        <div class="ms-table__page-size-text">
          {{ MISAResource[globalStore.lang]?.Paging?.ItemsPerPage }}
        </div>
        <!-- <div @click.stop="togglePageSizeDropdown" class="ms-table__page-size-btn">
          {{ props.pageSize }}
          <div class="ms-table__page-size-btn-icon" title="Dropdown">
            <MISAIcon icon="angle-down" />
          </div>
        </div>
        <ul @click.stop="" v-if="pageSizeDropdown.isShow" class="ms-table__page-size-dropdown">
          <li
            v-for="(item, index) in pageSizeDropdown.items"
            :key="index"
            @click="handleSelectPageSize(item)"
            class="ms-table__page-size-item"
          >
            {{ item }}
            <span v-if="props.pageSize === item" class="ms-table__page-size-icon">
              <MISAIcon icon="check" />
            </span>
          </li>
        </ul> -->
        <MISASelect
          :model-value="props.pageSize"
          @update:model-value="handleSelectPageSize"
          :options="[
            { label: 10, value: 10 },
            { label: 25, value: 25 },
            { label: 50, value: 50 },
            { label: 100, value: 100 },
          ]"
          width="84"
          dropdown-pos="top"
        />
      </div>

      <!-- records range -->
      <div class="ms-table__records-range">
        <p>
          {{ recordsRange.min }} -
          <span class="text-bold">{{ recordsRange.max }}</span>
          {{ MISAResource[globalStore.lang]?.Paging?.Records }}
        </p>
      </div>

      <!-- page controls -->
      <div class="ms-table__page-controls">
        <span
          @click="handlePrevPage"
          :class="['ms-table__prev-btn', { '--disable': props.currentPage <= 1 }]"
          v-tippy="MISAResource[globalStore.lang]?.Paging?.PrevPage"
          ><MISAIcon icon="angle-left"
        /></span>
        <span
          @click="handleNextPage"
          :class="['ms-table__next-btn', { '--disable': props.currentPage >= props.totalPage }]"
          v-tippy="MISAResource[globalStore.lang]?.Paging?.NextPage"
        >
          <MISAIcon icon="angle-right" />
        </span>
      </div>
    </div>
  </div>
</template>

<script setup>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAResource from "@/resource/resource";
import MISASelect from "../select/MISASelect.vue";
import { useGlobalStore } from "@/stores/global-store";
import { computed } from "vue";

const emit = defineEmits(["next-page", "prev-page", "select-page-size"]);

const props = defineProps({
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
});

const globalStore = useGlobalStore();

/**
 * Description: Tính toán khoảng của các phần tử
 * đang hiển thị trên trang hiện tại (phân trang)
 * Author: txphuc (30/06/2023)
 */
const recordsRange = computed(() => {
  if (props.currentPage && props.pageSize) {
    let maxRange = props.currentPage * props.pageSize;
    let minRange = maxRange - props.pageSize + 1;

    if (props.currentPage === props.totalPage) {
      maxRange = props.totalRecords;
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
});

/**
 * Description: Xử lý sự kiện chuyển trang tiếp theo
 * Author: txphuc (30/06/2023)
 */
const handleNextPage = () => {
  if (props.currentPage && props.totalPage && props.currentPage < props.totalPage) {
    const nextPage = props.currentPage + 1;
    emit("next-page", nextPage);
  }
};

/**
 * Description: Xử lý sự kiện chuyển trang trước đó
 * Author: txphuc (30/06/2023)
 */
const handlePrevPage = () => {
  if (props.currentPage && props.currentPage > 1) {
    const prevPage = props.currentPage - 1;
    emit("prev-page", prevPage);
  }
};

/**
 * Description: Xử lý chọn page size
 * Author: txphuc (30/06/2023)
 */
const handleSelectPageSize = (pageSize) => {
  if (props.pageSize !== pageSize) {
    emit("select-page-size", pageSize);
  }
};
</script>

<style scoped>
@import url("./table.css");
</style>
