<template>
  <DxDateBox
    :value="value"
    @value-changed="onValueChanged"
    type="date"
    display-format="dd/MM/yyyy"
    :use-mask-behavior="true"
    :show-clear-button="true"
    :max="max"
    placeholder="__/__/____"
    drop-down-button-template="imageIcon"
  >
    <template #imageIcon="{}">
      <div class="input-dropdown-icon">
        <MISAIcon :size="20" icon="calendar" />
      </div>
    </template>
  </DxDateBox>
</template>

<script>
import DxDateBox from "devextreme-vue/date-box";
import MISAIcon from "../icon/MISAIcon.vue";

export default {
  name: "MISADatePicker",
  emits: ["input"],
  components: {
    DxDateBox,
    MISAIcon,
  },
  props: {
    // Giá trị của date picker
    value: {
      type: Date,
    },

    // Ngày tối đa có thể chọn
    max: {
      type: Date,
    },
  },
  methods: {
    /**
     * Description: Xử lý sự kiện chọn giá trị
     * Author: txphuc (18/08/2023)
     */
    onValueChanged(e) {
      this.$emit("input", e.value);
    },
  },
};
</script>

<style lang="scss">
@import url("./datepicker.scss");
</style>
