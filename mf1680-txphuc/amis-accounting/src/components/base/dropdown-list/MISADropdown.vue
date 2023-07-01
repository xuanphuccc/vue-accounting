<template>
  <div ref="comboboxRef" tabindex="-1" class="ms-combobox">
    <input
      :tabindex="props.tabindex"
      readonly
      class="ms-combobox__input"
      type="text"
      :id="props.id"
      :placeholder="props.placeholder"
      :value="selectedOption?.label"
    />

    <div class="ms-combobox__toggle" title="Combobox">
      <span class="ms-combobox__toggle-icon ms-icon--angle-down-16"></span>
    </div>

    <div @click="$emit('update:modelValue', null)" class="ms-combobox__clear">
      <span class="ms-combobox__clear-icon ms-icon--times-16"></span>
    </div>

    <div class="ms-combobox__list-container">
      <ul class="ms-combobox__select-list">
        <li :class="['ms-combobox__item', { '--selected': !props.modelValue }]">
          -- {{ props.placeholder }} --
          <span class="ms-combobox__item-icon ms-icon--check-24"></span>
        </li>
        <li
          @click="selectOption(option)"
          v-for="option in props.options"
          :key="option.value"
          :class="['ms-combobox__item', { '--selected': option.value == props.modelValue }]"
        >
          {{ option.label }}
          <span class="ms-combobox__item-icon ms-icon--check-24"></span>
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup>
import { computed } from "vue";
import { ref } from "vue";

const emit = defineEmits(["update:modelValue"]);

const props = defineProps({
  // Danh sách các lựa chọn
  options: {
    type: Array,
    default() {
      return [];
    },
  },

  // Giá trị được chọn
  modelValue: {
    type: String,
    default: "",
  },

  // Placeholder khi không được chọn
  placeholder: {
    type: String,
    default: "Chọn giá trị",
  },

  // Thuộc tính id cho label
  id: {
    type: String,
  },

  // Tabindex
  tabindex: {
    type: String,
    default: "-1",
  },
});

const comboboxRef = ref(null);

/**
 * Description: Hàm chọn giá trị của combobox
 * Author: txphuc (27/06/2023)
 */
const selectOption = (option) => {
  emit("update:modelValue", option.value);

  if (comboboxRef.value) {
    comboboxRef.value.blur();
  }
};

/**
 * Description: Tìm đối tượng được chọn (label, value)
 * từ value của prop
 * Author: txphuc (27/06/2023)
 */
const selectedOption = computed(() => {
  try {
    return props.options.find((option) => option.value === props.modelValue) ?? {};
  } catch (error) {
    console.warn(error);
    return {};
  }
});
</script>

<style scoped>
@import url("./dropdown-list.css");
</style>
