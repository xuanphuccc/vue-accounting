<template>
  <DxDateBox
    @focus-out="$emit('blur')"
    @value-changed="onValueChanged"
    :value="value"
    type="date"
    :is-valid="isValid"
    :display-format="displayFormat"
    :use-mask-behavior="true"
    :show-clear-button="true"
    :min="min"
    :max="max"
    :placeholder="placeholder"
    :input-attr="{ id }"
    pickerType="calendar"
    :calendarOptions="{
      firstDayOfWeek: 1,
      zoomLevel,
      maxZoomLevel,
      elementAttr: { class: 'ms-calendar' },
    }"
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
  emits: ["input", "blur"],
  components: {
    DxDateBox,
    MISAIcon,
  },
  props: {
    // Giá trị của date picker
    value: {
      type: [Date, Number, String],
    },

    // Ngày tối thiểu có thể chọn
    min: {
      type: [Date, Number, String],
    },

    // Ngày tối đa có thể chọn
    max: {
      type: [Date, Number, String],
    },

    // Gợi ý
    placeholder: {
      type: String,
      default: "__/__/____",
    },

    // Định dạng hiển thị
    displayFormat: {
      type: String,
      default: "dd/MM/yyyy",
    },

    // Trạng thái validate
    isValid: {
      type: Boolean,
      default: true,
    },

    // Chọn ngày (= month) / chọn tháng (= year) / chọn năm
    zoomLevel: {
      type: String,
      default: "month",
    },

    //
    maxZoomLevel: {
      type: String,
      default: "month",
    },

    // Id (sử dụng cho label)
    id: {
      type: String,
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
