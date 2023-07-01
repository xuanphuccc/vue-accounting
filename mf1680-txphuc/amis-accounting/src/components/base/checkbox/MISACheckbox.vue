<template>
  <label @dblclick.stop="" class="ms-checkbox" :for="props.value">
    <input
      @click="handleChecked"
      :id="props.value"
      :value="props.value"
      :checked="isChecked || checked"
      type="checkbox"
      class="ms-checkbox__input"
    />
    <div class="ms-checkbox__check-mark"></div>

    <div v-if="props.label" class="ms-checkbox__label">{{ props.label }}</div>
  </label>
</template>

<script setup>
import { computed, ref } from "vue";

const emit = defineEmits(["update:modelValue"]);

const props = defineProps({
  // Giá trị đã được chọn của checkbox
  modelValue: {
    type: [String, Number, Boolean, Array],
    default: "",
  },

  // Giá trị của checkbox
  value: {
    type: [String, Number, Boolean],
    default: "",
  },

  // Hiển thị label cho checkbox
  label: {
    type: String,
    default: "",
  },

  // Trạng thái checked
  checked: {
    type: Boolean,
    default: false,
  },
});

const prev = ref(props.modelValue);

/**
 * Description: Hàm xử lý checked khi modelValue nhận vào
 * một mảng hoặc một giá trị bất kỳ
 * Author: txphuc (27/06/2023)
 */
const handleChecked = (e) => {
  try {
    if (Array.isArray(props.modelValue)) {
      // Nếu là mảng:
      // Push phần tử vào mảng nếu chưa có trong mảng
      // ngược lại xoá phần tử đó khỏi mảng

      let prevArr = [...props.modelValue];

      if (prevArr.includes(e.target.value)) {
        prevArr = prevArr.filter((value) => value !== e.target.value);
      } else {
        prevArr.push(e.target.value);
      }

      emit("update:modelValue", prevArr);
    } else {
      // Nếu không phải mảng:
      // Là giá trị của checkbox nếu được checked
      // ngược lại lấy giá trị ban đầu

      if (e.target.checked) {
        emit("update:modelValue", e.target.value);
      } else {
        emit("update:modelValue", prev.value);
      }
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Kiểm tra checkbox có được checked hay không
 * Author: txphuc (27/06/2023)
 */
const isChecked = computed(() => {
  try {
    if (props.modelValue && props.value) {
      if (Array.isArray(props.modelValue)) {
        return props.modelValue.includes(props.value);
      } else {
        return props.modelValue === props.value;
      }
    }
    return false;
  } catch (error) {
    console.warn(error);
    return false;
  }
});
</script>

<style scoped>
@import url("./checkbox.css");
</style>
