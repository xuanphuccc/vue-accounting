<template>
  <div v-if="props.filters.length > 0" class="ms-filter-view">
    <div v-for="filter in props.filters" :key="filter.column" class="ms-filter-view__item">
      <span class="ms-filter-view__text">{{ filter.displayName }}</span>
      <span class="ms-filter-view__sub-text">{{
        MISAResource[globalStore.lang]?.Filter[filter.filterBy]?.toLowerCase()
      }}</span>
      <span class="ms-filter-view__text">{{ filter.value }}</span>

      <div @click="handleOnRemoveFilter(filter.column)" class="ms-filter-view__clear-icon">
        <MISAIcon size="16" icon="times" />
      </div>
    </div>

    <div @click="removeAllFilter" class="ms-filter-view__clear">
      {{ MISAResource[globalStore.lang]?.Filter?.RemoveAll }}
    </div>
  </div>
</template>

<script setup>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "@/stores/global-store";

const emit = defineEmits(["filter-change"]);

const props = defineProps({
  filters: {
    type: Array,
    default() {
      return [];
    },
  },
});

const globalStore = useGlobalStore();

/**
 * Description: Xử lý xoá filter
 * Author: txphuc (05/08/2023)
 */
const handleOnRemoveFilter = (columnName) => {
  try {
    let localFilters = JSON.parse(JSON.stringify(props.filters)) ?? [];

    localFilters = localFilters.filter((filter) => filter.column !== columnName);

    emit("filter-change", localFilters);
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xử lý xoá tất cả filter
 * Author: txphuc (05/08/2023)
 */
const removeAllFilter = () => {
  emit("filter-change", []);
};
</script>

<style scoped>
@import url("./filter-view.css");
</style>
