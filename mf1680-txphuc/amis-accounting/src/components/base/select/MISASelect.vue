<template>
  <div
    @focusin="onOpenDropdown"
    @keydown.stop="preSelectOnPressArrow"
    ref="comboboxRef"
    tabindex="-1"
    :class="['ms-select', { '--show-search': props.search }]"
  >
    <input
      :tabindex="props.tabindex"
      class="ms-select__input"
      :readonly="!props.search"
      type="text"
      :id="props.id"
      :placeholder="props.placeholder"
      v-model="searchValue"
    />

    <div class="ms-select__toggle" title="Combobox">
      <MISAIcon size="16" icon="angle-down" />
    </div>

    <div @click="clearSelectedValue" class="ms-select__clear">
      <MISAIcon size="16" icon="times" />
    </div>

    <div class="ms-select__list-container">
      <ul class="ms-select__select-list">
        <li :class="['ms-select__item', { '--selected': !selectedValue }]">
          -- {{ props.placeholder }} --
          <div class="ms-select__item-icon">
            <MISAIcon icon="check" />
          </div>
        </li>
        <li
          @click="selectOption(option)"
          v-for="option in optionWithSearch"
          :key="option.value"
          :class="[
            'ms-select__item',
            { '--selected': option.value === selectedValue },
            { '--pre-select': option.value === preSelectValue?.value },
          ]"
        >
          {{ option.label }}
          <div class="ms-select__item-icon">
            <MISAIcon icon="check" />
          </div>
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup>
import enums from "@/helper/enum";
import MISAIcon from "../icon/MISAIcon.vue";
import { computed, watch } from "vue";
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

  // Search
  search: {
    type: Boolean,
    default: false,
  },

  // Thuộc tính id cho label focus
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
const selectedValue = ref(null);
const preSelectValue = ref(null);
const searchValue = ref("");

/**
 * Description: Chuyển giá trị của prop modelValue cho state
 * mỗi khi modelValue được thay đổi
 * Author: txphuc (04/07/2023)
 */
watch(
  () => [props.modelValue, props.options],
  () => {
    selectedValue.value = props.modelValue;
  },
  { immediate: true }
);

/**
 * Description: Reset giá trị đã trọn về rỗng
 * khi input search được xoá rỗng (ở chế độ search)
 * Author: txphuc (04/07/2023)
 */
watch(
  () => searchValue.value,
  () => {
    if (props.search && searchValue.value === "") {
      selectedValue.value = null;
      emit("update:modelValue", null);
    }
  }
);

/**
 * Description: Xử lý search option khi ở chế độ search (combobox)
 * Author: txphuc (04/07/2023)
 */
const optionWithSearch = computed(() => {
  try {
    if (props.search) {
      return props.options.filter((option) =>
        option?.label?.toLowerCase()?.includes(searchValue.value.toLowerCase())
      );
    } else {
      return props.options;
    }
  } catch (error) {
    console.warn(error);
    return props.options;
  }
});

/**
 * Description: Tìm đối tượng được chọn (label, value)
 * từ value của prop
 * Author: txphuc (27/06/2023)
 */
const selectedOption = computed(() => {
  try {
    return optionWithSearch.value.find((option) => option.value === selectedValue.value) ?? {};
  } catch (error) {
    console.warn(error);
    return {};
  }
});

/**
 * Description: Hàm chọn giá trị của combobox
 * Author: txphuc (27/06/2023)
 */
const selectOption = (option) => {
  selectedValue.value = option.value;
  emit("update:modelValue", option.value);
  searchValue.value = option.label;

  // Đóng dropdown
  if (comboboxRef.value) {
    comboboxRef.value.blur();
  }
};

/**
 * Description: Xử lý di chuyển qua giá trị
 * khi bấm nút mũi tên
 * Author: txphuc (04/07/2023)
 */
const preSelectOnPressArrow = (e) => {
  try {
    const keyCode = e.keyCode;
    const lastIndex = optionWithSearch.value.length - 1;
    const currentIndex = optionWithSearch.value.findIndex(
      (option) => option.value === preSelectValue.value?.value
    );

    if (keyCode === enums.KEY.ARROW_UP) {
      // Di chuyển lên, nếu đến đầu thì quay về cuối
      if (currentIndex > 0) {
        preSelectValue.value = optionWithSearch.value[currentIndex - 1];
      } else {
        preSelectValue.value = optionWithSearch.value[lastIndex];
      }
    } else if (keyCode === enums.KEY.ARROW_DOWN) {
      // Di chuyển xuống, nếu đến cuối thì quay lại đầu
      if (currentIndex < lastIndex) {
        preSelectValue.value = optionWithSearch.value[currentIndex + 1];
      } else {
        preSelectValue.value = optionWithSearch.value[0];
      }
    } else if (keyCode === enums.KEY.ENTER) {
      // Chọn giá trị khi nhấn phím ENTER
      selectOption(preSelectValue.value);
      e.target.blur();
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Reset giá trị đã chọn về rỗng
 * Author: txphuc (04/07/2023)
 */
const clearSelectedValue = (e) => {
  try {
    // Cập nhật binding hai chiều
    emit("update:modelValue", null);
    selectedValue.value = null;

    // Đóng dropdown
    e.target?.parentElement?.parentElement?.blur();

    // Xoá search value
    searchValue.value = "";
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Set lại giá trị cho preSelectValue mỗi khi
 * dropdown được focus (khi mở dropdown)
 * Author: txphuc (04/07/2023)
 */
const onOpenDropdown = () => {
  preSelectValue.value = selectedOption.value;
};
</script>

<style scoped>
@import url("./select.css");
</style>
