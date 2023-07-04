<template>
  <div class="ms-table">
    <div ref="tableContainerRef" @scroll="changeActionsPos" class="ms-table__container">
      <table class="ms-table__table">
        <thead>
          <!-- header -->
          <tr>
            <th class="--sticky-left">
              <MISACheckbox
                @click="selectRow(props.dataSource)"
                :checked="props.selectedRows.length === props.dataSource.length"
              />

              <!-- fake borders -->
              <span class="ms-table__border-bottom"></span>
            </th>
            <th
              v-for="column in columsWithPos"
              :key="column.key"
              :style="{
                width: column.width ? column.width + 'px' : '',
                textAlign: column.align ? column.align : '',
                left: column.left + 'px',
              }"
              :class="column.sticky"
              v-tooltip.bottom="column.desc || column.title"
              ref="columsRef"
            >
              {{ column.title }}

              <!-- resize column -->
              <span @mousedown="activeResize" class="ms-table__col-resize"></span>

              <!-- fake borders -->
              <span class="ms-table__border-bottom"></span>
              <span class="ms-table__border-right"></span>
            </th>
          </tr>
        </thead>
        <tbody>
          <!-- records -->
          <template v-if="!props.loading">
            <tr
              v-for="row in dataSourceWithSelectedRows"
              @dblclick="returnRow(row)"
              :key="row.key"
              :class="[{ '--active': row.checked }]"
            >
              <td class="--sticky-left">
                <MISACheckbox @click="selectRow(row)" :checked="row.checked" />

                <!-- fake borders -->
                <span class="ms-table__border-bottom"></span>
              </td>
              <template v-for="column in columsWithPos" :key="column.key">
                <td
                  :style="{ textAlign: column.align ? column.align : '', left: column.left + 'px' }"
                  :class="column.sticky"
                >
                  <slot :name="column.dataIndex" v-bind="row">
                    {{ row[column.dataIndex] }}
                  </slot>

                  <!-- fake borders -->
                  <span class="ms-table__border-bottom"></span>
                  <span class="ms-table__border-right"></span>
                </td>
              </template>

              <!-- table actions -->
              <div class="ms-table__actions" :style="{ right: tableActionsPosState + 'px' }">
                <slot name="table-actions" v-bind="row"></slot>
              </div>
            </tr>
          </template>

          <!-- skeleton loading -->
          <MISASkeletonRow v-else :columns="props.columns.length + 1" />
        </tbody>
      </table>
    </div>

    <!-- table footer -->
    <div class="ms-table__footer">
      <p class="total-row">
        <span>Tổng: </span>
        <span class="text-bold">{{ props.totalRecords }}</span>
      </p>
      <div class="ms-table__page-infor">
        <!-- page size dropdown -->
        <div class="ms-table__page-size">
          <div>Số bản ghi/trang:</div>
          <div @click="togglePageSizeDropdown" class="ms-table__page-size-btn">
            {{ props.pageSize }}
            <div class="ms-table__page-size-btn-icon" title="Dropdown">
              <MISAIcon icon="angle-down" />
            </div>
          </div>
          <ul v-if="pageSizeDropdown.isShow" class="ms-table__page-size-dropdown">
            <li
              v-for="(item, index) in pageSizeDropdown.items"
              :key="index"
              @click="handleSelectPageSize(item)"
              class="ms-table__page-size-item"
            >
              {{ item }}
              <span v-if="props.pageSize === item" class="ms-table__page-size-icon">
                <MISAIcon icon="check" />
              </span>
            </li>
          </ul>
        </div>

        <!-- records range -->
        <div class="ms-table__records-range">
          <p>
            {{ recordsRange.min }} -
            <span class="text-bold">{{ recordsRange.max }}</span>
            bản ghi
          </p>
        </div>

        <!-- page controls -->
        <div class="ms-table__page-controls">
          <span
            @click="handlePrevPage"
            :class="['ms-table__prev-btn', { '--disable': props.currentPage <= 1 }]"
            title="Trang trước"
            ><MISAIcon icon="angle-left"
          /></span>
          <span
            @click="handleNextPage"
            :class="['ms-table__next-btn', { '--disable': props.currentPage >= props.totalPage }]"
            title="Trang sau"
          >
            <MISAIcon icon="angle-right" />
          </span>
        </div>
      </div>
    </div>
    <!-- {{ console.log(columsWithPos) }} -->
    <!-- {{ console.log("children render") }} -->
  </div>
</template>

<script setup>
import { computed, ref, onMounted, watch } from "vue";
import MISASkeletonRow from "../skeleton-loader/MISASkeletonRow.vue";
import MISACheckbox from "../checkbox/MISACheckbox.vue";
import MISAIcon from "@/components/base/icon/MISAIcon.vue";

const emit = defineEmits([
  "double-click",
  "select-row",
  "next-page",
  "prev-page",
  "select-page-size",
]);

const props = defineProps({
  // Định nghĩa các cột - các trường
  // một trường bao gồm: key, title, dataIndex, width, align, desc, sticky
  columns: {
    type: Array,
    default() {
      return [];
    },
    required: true,
  },

  // Định nghĩa dữ liệu - các bản ghi
  // một bản ghi bao gồm: key, tên trường (dataIndex)
  dataSource: {
    type: Array,
    default() {
      return [];
    },
    required: true,
  },

  // Các bản ghi đã được chọn
  selectedRows: {
    type: Array,
    default() {
      return [];
    },
  },

  // Trang hiện tại
  currentPage: {
    type: Number,
    default: 1,
  },

  // Tổng số trang
  totalPage: {
    type: Number,
    default: 0,
  },

  // Tổng số bản ghi
  totalRecords: {
    type: Number,
    default: 0,
  },

  // Số phần tử trên trang
  pageSize: {
    type: Number,
    default: 0,
  },

  // Trạng thái loading dữ liệu
  loading: {
    type: Boolean,
    default: false,
  },
});

// ----- State -----
const tableActionsPosState = ref(0);
const pageSizeDropdown = ref({
  isShow: false,
  items: [10, 25, 50, 100],
});

const tableContainerRef = ref(null);
const columsRef = ref(null);
const columsWithPos = ref(props.columns);

/**
 * Description: Xử lý tính toán vị trí của các cột
 * khi ghim cột đó sau khi dữ liệu được render vào DOM xong
 * Author: txphuc (02/07/2023)
 */

watch(
  () => props.dataSource,
  () => {
    const testPos = () => {
      try {
        if (columsRef.value && tableContainerRef.value) {
          const tableScrollWidth = tableContainerRef.value.scrollWidth;

          // Tính toán vị trí của các cột
          const columnsPos = columsRef.value.map((columnEl) => {
            const width = columnEl.offsetWidth;
            const left = columnEl.offsetLeft;
            const right = tableScrollWidth + 34 - (left + width);

            return {
              width,
              left,
              right,
            };
          });

          // Gộp vị trí vào mảng các cột từ prop ban đầu
          const result = props.columns.map((column, index) => {
            if (column.sticky) {
              return {
                ...column,
                sticky: `--sticky-${column.sticky}`,
                ...columnsPos[index],
              };
            } else
              return {
                ...column,
                width: "",
                left: "",
                right: "",
                sticky: "",
              };
          });

          columsWithPos.value = result;
        }
      } catch (error) {
        console.warn(error);
      }
    };

    setTimeout(() => {
      testPos();
    }, 50);
  },
  {
    // Chạy khi DOM được cập nhật xong
    flush: "post",
  }
);

/**
 * Description: Xử lý thêm trường "checked" với bản ghi
 * đã được chọn
 * Author: txphuc (24/06/2023)
 */
const dataSourceWithSelectedRows = computed(() => {
  try {
    return props.dataSource?.map((row) => {
      row["checked"] = props.selectedRows?.find((selectedItem) => selectedItem.key == row.key)
        ? true
        : false;
      return row;
    });
  } catch (error) {
    console.warn(error);
    return [];
  }
});

/**
 * Description: Xử lý chọn một/nhiều hàng sau đó trả về
 * một mảng các phần tử được chọn
 * Author: txphuc (24/06/2023)
 */
const selectRow = (value) => {
  try {
    let localSelectedRows = [...props.selectedRows];

    // Chọn tất cả các hàng hàng
    if (Array.isArray(value)) {
      if (localSelectedRows.length === props.dataSource?.length) {
        localSelectedRows = [];
      } else {
        localSelectedRows = value;
      }

      // Chọn một hàng
    } else {
      if (localSelectedRows.find((selectedRow) => selectedRow.key == value.key)) {
        localSelectedRows = localSelectedRows.filter(
          (selectedRow) => selectedRow.key !== value.key
        );
      } else {
        localSelectedRows.push(value);
      }
    }

    emit("select-row", localSelectedRows);
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xử lý chọn một/nhiều hàng sau đó trả về
 * một mảng các phần tử được chọn
 * Author: txphuc (30/06/2023)
 */
const returnRow = (row) => {
  emit("double-click", row);
};

/**
 * Description: Tính toán khoảng của các phần tử
 * đang hiển thị trên trang hiện tại (phân trang)
 * Author: txphuc (30/06/2023)
 */
const recordsRange = computed(() => {
  try {
    if (props.currentPage && props.pageSize) {
      let maxRange = props.currentPage * props.pageSize;
      let minRange = maxRange - props.pageSize + 1;

      if (props.currentPage === props.totalPage) {
        maxRange = props.totalRecords;
      }

      return {
        min: minRange,
        max: maxRange,
      };
    } else {
      return {
        min: 0,
        max: 0,
      };
    }
  } catch (error) {
    console.warn(error);
    return {
      min: 0,
      max: 0,
    };
  }
});

/**
 * Description: Xử lý sự kiện chuyển trang tiếp theo
 * Author: txphuc (30/06/2023)
 */
const handleNextPage = () => {
  try {
    if (props.currentPage && props.totalPage && props.currentPage < props.totalPage) {
      const nextPage = props.currentPage + 1;
      emit("next-page", nextPage);
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xử lý sự kiện chuyển trang trước đó
 * Author: txphuc (30/06/2023)
 */
const handlePrevPage = () => {
  try {
    if (props.currentPage && props.currentPage > 1) {
      const prevPage = props.currentPage - 1;
      emit("prev-page", prevPage);
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xử lý ẩn/hiện danh sách page size
 * Author: txphuc (30/06/2023)
 */
const togglePageSizeDropdown = () => {
  pageSizeDropdown.value.isShow = !pageSizeDropdown.value.isShow;
};

/**
 * Description: Xử lý chọn page size
 * Author: txphuc (30/06/2023)
 */
const handleSelectPageSize = (pageSize) => {
  if (props.pageSize !== pageSize) {
    emit("select-page-size", pageSize);
    pageSizeDropdown.value.isShow = false;
  }
};

/**
 * Description: Xử lý sự kiện thay đổi kích thước cột
 * bằng cách nhấn giữ và kéo trang phải/trái
 * Author: txphuc (24/06/2023)
 */
const activeResize = (e) => {
  try {
    const thElement = e.target.parentElement;
    const thElementRect = thElement.getBoundingClientRect();

    // resizing column
    const resizeColumn = (e) => {
      const mouseX = e.clientX;

      thElement.style.width = mouseX - thElementRect.left + 4 + "px";
      // thElement.style.maxWidth = mouseX - thElementRect.left + 4 + "px";
    };

    window.addEventListener("mousemove", resizeColumn);

    // event clean up
    window.onmouseup = () => {
      window.removeEventListener("mousemove", resizeColumn);
    };
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Lấy chiều dài đã cuộn để di chuyển vị trí
 * của các nút actions vào khung nhìn
 * Author: txphuc (25/06/2023)
 */
const changeActionsPos = () => {
  try {
    const scrollWidth = tableContainerRef.value.scrollWidth;
    const scrollLeft = tableContainerRef.value.scrollLeft;
    const clientWidth = tableContainerRef.value.clientWidth;

    tableActionsPosState.value = scrollWidth - clientWidth - scrollLeft + 16;
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xác định vị trí cho nút action ngay khi mounted
 * Author: txphuc (25/06/2023)
 */
onMounted(() => {
  changeActionsPos();
});
</script>

<style scoped>
@import url("./table.css");
</style>
