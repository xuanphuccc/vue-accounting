<template>
  <div
    @focus="openMenu"
    @keydown="handleOnKeyDown"
    :tabindex="props.tabindex"
    class="ms-date-picker"
  >
    <div tabindex="-1" ref="focusFlag"></div>
    <VueDatePicker
      :model-value="props.modelValue"
      @update:model-value="setDate"
      :format="formatInput"
      :max-date="props.maxDate"
      :text-input-options="textInputOptions"
      auto-apply
      arrow-navigation
      keep-action-row
      :enable-time-picker="false"
      hide-input-icon
      :position="props.position"
      space-confirm
      offset="4"
      placeholder="dd/MM/yyyy"
      input-class-name="ms-date-picker__input"
      :menu-class-name="`ms-date-picker__menu ${props.position === 'right' && '--right'}`"
      calendar-class-name="ms-date-picker__calendar"
      calendar-cell-class-name="ms-date-picker__calendar-cell"
      ref="datePickerRef"
    >
      <!-- menu header -->
      <template #month-year="{ month, year, years, updateMonthYear, handleMonthYearChange }">
        <div class="ms-date-picker__header">
          <div class="ms-date-picker__header-date">
            {{ MISAResource[globalStore.lang]?.Month["M" + (month + 1)] }},

            <select
              ref="yearSelectRef"
              class="ms-date-picker__year-select"
              :value="year"
              @change="updateMonthYear(month, Number($event.target.value))"
            >
              <option v-for="y in years" :key="y.value" :value="y.value">{{ y.text }}</option>
            </select>
          </div>
          <div class="ms-date-picker__header-controls">
            <MISAIcon
              tabindex="0"
              ref="prevBtnRef"
              @click="handleMonthYearChange(false)"
              icon="angle-left"
            />
            <MISAIcon
              tabindex="0"
              ref="nextBtnRef"
              @click="handleMonthYearChange(true)"
              icon="angle-right"
            />
          </div>
        </div>
      </template>

      <!-- calendar header -->
      <template #calendar-header="{ day }">
        <div class="ms-date-picker__calendar-header-item">
          {{ MISAResource[globalStore.lang]?.Day[day] }}
        </div>
      </template>

      <template #action-row>
        <div @click="getToday" class="ms-date-picker__action">
          {{ MISAResource[globalStore.lang]?.Day["Today"] }}
        </div>
      </template>
    </VueDatePicker>
    <MISAIcon icon="date" />
  </div>
</template>

<script setup>
import VueDatePicker from "@vuepic/vue-datepicker";
import MISAIcon from "../icon/MISAIcon.vue";
import formatDate from "../../../helper/format-date";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "@/stores/global-store";
import { ref } from "vue";
import enums from "@/helper/enum";

const emit = defineEmits(["update:modelValue"]);
const datePickerRef = ref(null);
const nextBtnRef = ref(null);
const prevBtnRef = ref(null);
const yearSelectRef = ref(null);
const focusFlag = ref(null);

const globalStore = useGlobalStore();

const props = defineProps({
  // Giá trị
  modelValue: Date,

  // Tabindex
  tabindex: [String, Number],

  // Vị trí của menu: left | right | center
  position: {
    type: String,
    default: "center",
  },

  // Ngày tối đa có thể chọn
  maxDate: {
    type: Date,
    default: new Date(),
  },
});

const textInputOptions = ref({
  enterSubmit: true,
  tabSubmit: true,
  openMenu: true,
});

/**
 * Description: Update giá trị được chọn
 * Author: txphuc (17/07/2023)
 */
const setDate = (value) => {
  emit("update:modelValue", value);

  focusFlag.value.focus();
};

/**
 * Description: Update giá trị là ngày hôm nay
 * Author: txphuc (17/07/2023)
 */
const getToday = () => {
  try {
    const today = new Date();

    emit("update:modelValue", today);

    // Đóng menu chọn ngày
    if (datePickerRef.value) {
      closeMenu();
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Format date hiển thị lên input
 * Author: txphuc (17/07/2023)
 */
const formatInput = (date) => {
  try {
    if (typeof date === "object") {
      return formatDate(date.toJSON(), "DD/MM/YYYY");
    } else {
      return null;
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Mở menu chọn ngày
 * Author: txphuc (27/07/2023)
 */
const openMenu = () => {
  datePickerRef.value.openMenu();
};

/**
 * Description: Đóng menu chọn ngày
 * Author: txphuc (27/07/2023)
 */
const closeMenu = () => {
  datePickerRef.value.closeMenu();
};

/**
 * Description: Xử lý sự kiện bàn phím
 * Author: txphuc (31/07/2023)
 */
const handleOnKeyDown = (e) => {
  try {
    const keyCode = e.keyCode;
    const ctrlKey = e.ctrlKey;

    switch (keyCode) {
      case enums.key.TAB:
        // Đóng menu khi nhấn Tab
        closeMenu();
        break;
      case enums.key.ARROW_LEFT:
        // Chuyển sang tháng trước khi nhấn Ctrl + mũi tên trái
        if (ctrlKey && prevBtnRef.value) {
          prevBtnRef.value.click();
          prevBtnRef.value.focus();
        }
        break;
      case enums.key.ARROW_RIGHT:
        // Chuyển sang tháng sau khi nhấn Ctrl + mũi tên phải
        if (ctrlKey && nextBtnRef.value) {
          nextBtnRef.value.click();
          nextBtnRef.value.focus();
        }
        break;
      case enums.key.Y:
        // Focus vào ô chọn năm khi nhấn Ctrl + Y
        if (ctrlKey && yearSelectRef.value) {
          yearSelectRef.value.focus();
        }
        break;

      default:
        break;
    }
  } catch (error) {
    console.warn(error);
  }
};
</script>

<style>
@import url("@vuepic/vue-datepicker/dist/main.css");
@import url("./date-picker.css");
</style>
