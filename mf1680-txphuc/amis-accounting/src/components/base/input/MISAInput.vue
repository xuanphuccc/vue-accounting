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
import { onMounted, ref } from "vue";

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

  // Trạng thái focus khi component được mounted
  focus: {
    type: Boolean,
    default: false,
  },
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
 * Description: Xử lý auto focus vào input khi component được mounted
 * Author: txphuc (26/06/2023)
 */
onMounted(() => {
  if (props.focus) {
    inputRef.value.focus();
  }
});
</script>

<style scoped>
@import url("./input.css");
</style>
