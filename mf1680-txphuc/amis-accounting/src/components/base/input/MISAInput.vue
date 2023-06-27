<template>
  <input
    :value="props.modelValue"
    @input="$emit('onUpdate:modelValue', $event.target.value)"
    :type="props.type"
    :class="['ms-input', ...classNames]"
    :id="props.id"
    :placeholder="props.placeholder"
    :style="{ width: typeof props.width === 'number' ? props.width + 'px' : props.width }"
    ref="inputRef"
  />
</template>

<script setup>
import { computed, onMounted, ref } from "vue";

defineEmits(["onUpdate:modelValue"]);

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

  // Chiều rộng input
  width: {
    type: [Number, String],
    default: "",
  },

  // Trạng thái focus khi component được mounted
  focus: {
    type: Boolean,
    default: false,
  },

  // Thêm class
  class: [String, Array],
});

const inputRef = ref(null);

/**
 * Description: Chuyển đổi class dạng string sang arr
 * Author: txphuc (26/06/2023)
 */
const classNames = computed(() => {
  try {
    let classArr = [];

    if (props.class) {
      if (typeof props.class === "string") {
        classArr.push(props.class);
      } else if (Array.isArray(props.class)) {
        classArr = props.class;
      }
    }

    return classArr;
  } catch (error) {
    console.warn(error);
    return [];
  }
});

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
