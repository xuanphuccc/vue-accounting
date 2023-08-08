<template>
  <div
    @focusin="openDropdown"
    @focusout="handleOnFocusOut"
    @keydown="preSelectOnPressArrow"
    @click="toggleDropdown"
    ref="comboboxRef"
    tabindex="-1"
    :class="['ms-select', { '--show-search': props.search }]"
    :style="{ width: props.width ? props.width + 'px' : 'auto' }"
  >
    <input
      @mousedown.stop=""
      :tabindex="props.tabindex"
      class="ms-select__input"
      :readonly="!props.search"
      type="text"
      :id="props.id"
      :placeholder="props.placeholder"
      v-model="searchValue"
    />

    <div @mousedown.stop="" class="ms-select__toggle">
      <MISAIcon size="16" icon="angle-down" />
    </div>

    <div
      v-if="props.clearIcon"
      @focusin.stop=""
      @click.stop="clearSelectedValue"
      tabindex="-1"
      class="ms-select__clear"
    >
      <MISAIcon size="16" icon="times" />
    </div>

    <div
      @mousedown.stop=""
      @click.stop=""
      @focusin.stop=""
      tabindex="-1"
      v-show="isOpen"
      :class="['ms-select__list-container', `--position-${props.dropdownPos}`]"
    >
      <ul class="ms-select__select-list">
        <li v-if="props.placeholder" :class="['ms-select__item', { '--selected': !selectedValue }]">
          -- {{ props.placeholder }} --
          <div class="ms-select__item-icon">
            <MISAIcon icon="check" />
          </div>
        </li>
        <li
          @click="selectOption(option, index)"
          v-for="(option, index) in optionWithSearch"
          :key="option.value"
          :class="[
            'ms-select__item',
            { '--selected': option.value === selectedValue },
            { '--pre-select': option.value === preSelectValue?.value },
          ]"
          ref="menuItemRef"
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
import { computed, onMounted, onUnmounted, watch } from "vue";
import { ref } from "vue";

const emit = defineEmits(["update:modelValue", "close"]);

const props = defineProps({
  // Danh sách các lựa chọn: [{label: String, value: any}]
  options: {
    type: Array,
    default() {
      return [];
    },
  },

  // Giá trị được chọn
  modelValue: {
    type: [String, Number, Object],
    default: "",
  },

  // Placeholder khi không được chọn
  placeholder: {
    type: String,
  },

  // Search giá trị (combobox)
  search: {
    type: Boolean,
    default: false,
  },

  // Ẩn/hiện nút bỏ chọn giá trị
  clearIcon: {
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

  // Vị trí hiển thị dropdown: top | bottom
  dropdownPos: {
    type: String,
    default: "bottom",
  },

  // Độ rộng
  width: {
    type: [String, Number],
  },
});

const isOpen = ref(false);
const focusCount = ref(0);
const comboboxRef = ref(null);
const menuItemRef = ref([]);
const selectedValue = ref(null);
const preSelectValue = ref(null);
const preSelectIndex = ref(0);
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
 * Description: Reset giá trị đã chọn về rỗng
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
        option?.label?.toLowerCase()?.includes(searchValue.value?.toLowerCase()?.trim() || "")
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
    return props.options.find((option) => option.value === selectedValue.value) ?? {};
  } catch (error) {
    console.warn(error);
    return {};
  }
});

/**
 * Description: Gán giá trị cho input search khi option được chọn
 * Author: txphuc (10/07/2023)
 */
watch(
  () => selectedOption.value,
  () => {
    searchValue.value = selectedOption.value?.label;
  },
  {
    immediate: true,
  }
);

/**
 * Description: Hàm chọn giá trị của combobox
 * Author: txphuc (27/06/2023)
 */
const selectOption = (option, index) => {
  selectedValue.value = option.value;
  emit("update:modelValue", option.value);

  // Set vị trí cuộn cho phẩn tử được chọn
  // (kiểm tra undefined vì index là tham số tuỳ chọn)
  if (index !== undefined) {
    preSelectIndex.value = index;
  }

  // Đóng dropdown khi chọn xong giá trị
  closeDropdown();
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

    if (keyCode === enums.key.ARROW_UP) {
      // Di chuyển lên, nếu đến đầu thì quay về cuối
      if (currentIndex > 0) {
        preSelectValue.value = optionWithSearch.value[currentIndex - 1];
        preSelectIndex.value = currentIndex - 1;
      } else {
        preSelectValue.value = optionWithSearch.value[lastIndex];
        preSelectIndex.value = lastIndex;
      }
    } else if (keyCode === enums.key.ARROW_DOWN) {
      // Di chuyển xuống, nếu đến cuối thì quay lại đầu
      if (currentIndex < lastIndex) {
        preSelectValue.value = optionWithSearch.value[currentIndex + 1];
        preSelectIndex.value = currentIndex + 1;
      } else {
        preSelectValue.value = optionWithSearch.value[0];
        preSelectIndex.value = 0;
      }
    } else if (keyCode === enums.key.ENTER) {
      // Chọn giá trị khi nhấn phím ENTER
      selectOption(preSelectValue.value);
    } else if (keyCode === enums.key.TAB) {
      closeDropdown();
    }

    // Cuộn item lên khung nhìn nếu item bị ẩn
    handleScrollToView(preSelectIndex.value);
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Reset giá trị đã chọn về rỗng (chế độ dropdown list)
 * Author: txphuc (04/07/2023)
 */
const clearSelectedValue = () => {
  try {
    // Cập nhật binding hai chiều
    emit("update:modelValue", null);
    selectedValue.value = null;

    // Phát sự kiện close để gọi validate
    emit("close");

    // Xoá search value
    searchValue.value = "";

    // Cuộn về phần tử đầu tiên
    preSelectIndex.value = 0;
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xử lý scroll item ẩn lên khung nhìn
 * Author: txphuc (20/07/2023)
 */
const handleScrollToView = (index) => {
  try {
    setTimeout(() => {
      if (menuItemRef.value.length > 0) {
        menuItemRef.value[index]?.scrollIntoView({
          behavior: "smooth",
          block: "nearest",
          inline: "nearest",
        });
      }
    }, 100);
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Sự kiện mở Dropdown
 * Author: txphuc (04/07/2023)
 */
const openDropdown = () => {
  isOpen.value = true;

  //Set lại giá trị cho preSelectValue khi mở dropdown
  preSelectValue.value = selectedOption.value;

  const selectedIndex = optionWithSearch.value.findIndex(
    (option) => option.value === selectedValue.value
  );

  preSelectIndex.value = selectedIndex === -1 ? 0 : selectedIndex;

  // Cuộn đến phần tử được chọn khi mở dropdown
  handleScrollToView(preSelectIndex.value);
};

/**
 * Description: Sự kiện đóng dropdown
 * Author: txphuc (20/07/2023)
 */
const closeDropdown = () => {
  if (isOpen.value) {
    emit("close");

    isOpen.value = false;
  }
};

/**
 * Description: Xử lý dropdown khi focusout
 * Author: txphuc (08/08/2023)
 */
const handleOnFocusOut = () => {
  focusCount.value = 0;
};

/**
 * Description: Xử lý đóng/mở dropdown khi click chuột
 * Author: txphuc (08/08/2023)
 */
const toggleDropdown = () => {
  focusCount.value++;

  // Click đóng/mở chỉ có tác dụng sau khi dropdown được sự kiện focus mở dropdown lần đầu
  if (focusCount.value > 1) {
    if (isOpen.value) {
      closeDropdown();
    } else {
      openDropdown();
    }
  }
};

/**
 * Description: Sự kiện click outside
 * Author: txphuc (20/07/2023)
 */
onMounted(() => {
  window.addEventListener("mousedown", closeDropdown);
});

/**
 * Description: Huỷ sự kiện click outside
 * Author: txphuc (20/07/2023)
 */
onUnmounted(() => {
  window.removeEventListener("mousedown", closeDropdown);
});

/**
 * Description: Xử lý auto focus khi gọi từ component cha
 * Author: txphuc (12/07/2023)
 */
const focus = () => {
  if (comboboxRef.value) {
    comboboxRef.value.focus();
  }
};

// Expose ra ngoài component cha
defineExpose({ focus });
</script>

<style scoped>
@import url("./select.css");
</style>
