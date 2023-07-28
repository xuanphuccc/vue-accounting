<template>
  <input
    :value="props.modelValue"
    @input="onInputChange"
    @blur="$emit('blur')"
    :type="props.type"
    :class="['ms-input']"
    :id="props.id"
    :placeholder="props.placeholder"
    ref="inputRef"
  />
</template>

<script setup>
import { ref } from "vue";

const emit = defineEmits(["update:modelValue", "blur", "input"]);

const props = defineProps({
  // Giá trị của ô input
  modelValue: [String, Number],

  // Chỉ định id
  id: {
    type: String,
    default: null,
  },

  // Loại input
  type: {
    type: String,
    default: "text",
  },

  // Gợi ý
  placeholder: String,
});

const inputRef = ref(null);

/**
 * Description: Xử lý lắng nghe sự thay đổi của input
 * Author: txphuc (26/06/2023)
 */
const onInputChange = (e) => {
  emit("update:modelValue", e.target.value);
  emit("input");
};

/**
 * Description: Xử lý auto focus khi gọi từ component cha
 * Author: txphuc (12/07/2023)
 */
const autoFocus = () => {
  if (inputRef.value) {
    inputRef.value.focus();
  }
};

// Expose ra ngoài component cha
defineExpose({ autoFocus });
</script>

<style scoped>
@import url("./input.css");
</style>
