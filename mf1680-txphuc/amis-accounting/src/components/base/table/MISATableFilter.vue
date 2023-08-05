<template>
  <div @keydown.enter="submitFilter" @click.stop="" class="ms-table-filter">
    <div class="ms-table-filter__header">
      {{ MISAResource[globalStore.lang]?.Filter?.FilterConditionTitle }}
    </div>
    <div class="ms-table-filter__content">
      <MISASelect
        v-model="activeFilter.filterBy"
        :options="[
          { label: MISAResource[globalStore.lang]?.Filter?.equal, value: enums.filter.EQUAL },
          { label: MISAResource[globalStore.lang]?.Filter?.notequal, value: enums.filter.NOTEQUAL },
          { label: MISAResource[globalStore.lang]?.Filter?.contain, value: enums.filter.CONTAIN },
          {
            label: MISAResource[globalStore.lang]?.Filter?.notcontain,
            value: enums.filter.NOTCONTAIN,
          },
        ]"
      />
      <MISAInput
        v-model="activeFilter.value"
        auto-focus
        :placeholder="MISAResource[globalStore.lang]?.PlaceHolder?.EnterValue"
      />
    </div>
    <div class="ms-table-filter__footer">
      <MISAButton @click="clearFilter" type="secondary">{{
        MISAResource[globalStore.lang]?.Filter?.Cancel
      }}</MISAButton>
      <MISAButton @click="submitFilter" type="primary">{{
        MISAResource[globalStore.lang]?.Filter?.Apply
      }}</MISAButton>
    </div>
  </div>
</template>

<script setup>
import enums from "@/helper/enum";
import MISAButton from "../button/MISAButton.vue";
import MISAInput from "../input/MISAInput.vue";
import MISASelect from "../select/MISASelect.vue";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "@/stores/global-store";
import { ref, onMounted, onUnmounted, watch } from "vue";

const emit = defineEmits(["close", "submit", "clear"]);

const props = defineProps({
  // Tên cột tương ứng trường API
  column: {
    type: String,
  },

  // Tên hiển thị của cột
  displayName: {
    typpe: String,
  },

  // Giá trị lọc
  value: {
    type: null,
    default: null,
  },

  // Loại giá trị
  type: {
    type: null,
    default: null,
  },

  // Loại filter
  filterBy: {
    type: String,
    default: enums.filter.CONTAIN,
  },
});

// Filter đang được nhập nhưng chưa lưu
const activeFilter = ref({
  column: null,
  displayName: null,
  value: null,
  type: null,
  filterBy: null,
});

const globalStore = useGlobalStore();

/**
 * Description: Chuyển giá trị từ props sang state
 * Author: txphuc (05/08/2023)
 */
watch(
  () => props,
  () => {
    activeFilter.value = {
      column: props.column,
      displayName: props.displayName,
      value: props.value,
      type: props.type,
      filterBy: props.filterBy,
    };
  },
  { immediate: true, deep: true }
);

/**
 * Description: Submit giá trị filter
 * Author: txphuc (05/08/2023)
 */
const submitFilter = () => {
  if (activeFilter.value.column && activeFilter.value.filterBy && activeFilter.value.value) {
    emit("submit", activeFilter.value);

    closeMenu();
  }
};

/**
 * Description: Xoá giá trị filter
 * Author: txphuc (05/08/2023)
 */
const clearFilter = () => {
  if (activeFilter.value.column) {
    emit("clear", activeFilter.value.column);

    closeMenu();
  }
};

/**
 * Description: Phát sự kiện đóng menu
 * Author: txphuc (04/08/2023)
 */
const closeMenu = () => {
  emit("close");
};

/**
 * Description: Thêm sự kiện click outside
 * Author: txphuc (04/08/2023)
 */
onMounted(() => {
  document.addEventListener("click", closeMenu);
});

/**
 * Description: Huỷ sự kiện click outside
 * Author: txphuc (04/08/2023)
 */
onUnmounted(() => {
  document.removeEventListener("click", closeMenu);
});
</script>

<style scoped>
@import url("./table.css");
</style>
