<template>
  <input
    :value="props.modelValue"
    @input="$emit('update:modelValue', $event.target.value)"
    type="text"
    :class="['ms-input', props.class]"
    :id="props.id"
    :placeholder="props.placeholder"
    :style="{ width: typeof props.width === 'number' ? props.width + 'px' : props.width }"
  />
</template>

<script setup>
defineEmits(["update:value"]);
const props = defineProps({
  id: String,
  placeholder: String,
  modelValue: [String, Number],
  width: {
    type: [Number, String],
    default: "",
  },
  class: String,
});
</script>

<style scoped>
@import url("./input.css");
</style>
