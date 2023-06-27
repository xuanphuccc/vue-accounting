<template>
  <div tabindex="-1" class="ms-combobox">
    <input
      readonly
      class="ms-combobox__input"
      type="text"
      id="combobox2"
      placeholder="Chọn công ty"
    />

    <div class="ms-combobox__toggle" title="Combobox">
      <span class="ms-combobox__toggle-icon ms-icon--angle-down-16"></span>
    </div>

    <div class="ms-combobox__clear">
      <span class="ms-combobox__clear-icon ms-icon--times-16"></span>
    </div>

    <div class="ms-combobox__list-container">
      <ul class="ms-combobox__select-list">
        <li
          v-for="option in props.options"
          :key="option.value"
          :class="['ms-combobox__item', { '--selected': props.value?.value === option.value }]"
        >
          {{ option.value }}
          <span class="ms-combobox__item-icon ms-icon--check-24"></span>
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  // Danh sách các lựa chọn
  options: {
    type: Array,
    default() {
      return [
        { label: "Type 1", value: "type1" },
        { label: "Type 2", value: "type2" },
        { label: "Type 3", value: "type3" },
      ];
    },
  },

  // Giá trị được chọn
  value: {
    type: Object,
    default() {
      return { label: "Type 2", value: "type2" };
    },
  },
});
</script>

<style scoped>
@import url("./dropdown-list.css");
</style>
