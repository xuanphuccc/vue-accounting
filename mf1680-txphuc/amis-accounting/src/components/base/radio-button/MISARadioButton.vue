<template>
  <label class="ms-radio-btn" :for="props.value">
    <input
      @change="$emit('update:modelValue', $event.target.value)"
      :value="props.value"
      :checked="props.modelValue === props.value"
      :id="props.value"
      type="radio"
      class="ms-radio-btn__input"
    />
    <div class="ms-radio-btn__check-mark"></div>

    <div class="ms-radio-btn__label">{{ props.label }}</div>
  </label>
</template>

<script setup>
defineEmits(["update:modelValue"]);

const props = defineProps({
  // Giá trị đã được chọn
  modelValue: {
    type: [String, Number, Boolean],
    default: "",
  },

  // Giá trị của radio button
  value: {
    type: [String, Number, Boolean],
    default: "",
  },

  // Hiển thị label mô tả
  label: {
    type: String,
    default: "Label",
  },
});
</script>

<style scoped>
@import url("./radio-button.css");
</style>
