<template>
  <div class="ms-table">
    <div ref="tableContainerRef" class="ms-table__container">
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

            <template v-for="column in columsWithPos" :key="column.key">
              <th
                v-if="!column.hide"
                @click="handleSelectSortColumn(column.originName)"
                :style="{
                  width: column.width ? column.width + 'px' : '',
                  maxWidth: column.width ? column.width + 'px' : '',
                  left: column.sticky && column.left + 'px',
                }"
                :class="[`--align-${column.align || ''}`, `--sticky-${column.sticky}`]"
                v-tippy="{ content: column.desc || column.title, placement: 'bottom' }"
              >
                <div class="ms-table__sort-wrap">
                  <div class="ms-table__table-text-wrap">
                    {{ column.title }}
                  </div>
                  <div
                    v-show="props.sort?.sortColumn === column?.originName"
                    :class="['ms-table__sort-icon', `--${props.sort?.sortOrder}`]"
                  >
                    <MISAIcon size="16" icon="arrow-down" />
                  </div>
                </div>

                <!-- resize column -->
                <span
                  @mousedown="activeResize($event, column)"
                  @click.stop=""
                  class="ms-table__col-resize"
                ></span>

                <!-- fake borders -->
                <span class="ms-table__border-bottom"></span>
                <span class="ms-table__border-right"></span>

                <!-- filter -->
                <div
                  :class="[
                    'ms-table__filter',
                    { '--active': filterMenu.isShow && filterMenu.column === column.originName },
                    { '--filtering': props.filters.find((ft) => ft.column === column.originName) },
                  ]"
                >
                  <div
                    @click.stop="handleOpenFilterMenu($event, column)"
                    class="ms-table__filter-icon"
                  >
                    <MISAIcon size="20" icon="filter" />
                  </div>
                </div>
              </th>
            </template>

            <th :style="{ width: '108px' }" class="--sticky-right --align-center">
              {{ MISAResource[globalStore.lang]?.Table?.Functions }}
              <!-- fake borders -->
              <span class="ms-table__border-left"></span>
              <span class="ms-table__border-bottom"></span>
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
              :class="[{ '--active': row.checked || row.key === props.activeRow?.key }]"
            >
              <td class="--sticky-left">
                <MISACheckbox @click="selectRow(row)" :checked="row.checked" />

                <!-- fake borders -->
                <span class="ms-table__border-bottom"></span>
              </td>

              <template v-for="column in columsWithPos" :key="column.key">
                <td
                  v-if="!column.hide"
                  :style="{
                    width: column.width ? column.width + 'px' : '',
                    maxWidth: column.width ? column.width + 'px' : '',
                    left: column.sticky && column.left + 'px',
                  }"
                  :class="[`--align-${column.align || ''}`, `--sticky-${column.sticky}`]"
                  v-tippy="{ content: row[column.dataIndex] || '', placement: 'bottom' }"
                >
                  <slot :name="column.dataIndex" v-bind="row">
                    <div class="ms-table__table-text-wrap">
                      {{ row[column.dataIndex] }}
                    </div>
                  </slot>

                  <!-- fake borders -->
                  <span class="ms-table__border-bottom"></span>
                  <span class="ms-table__border-right"></span>
                </td>
              </template>

              <!-- table action -->
              <td :style="{ width: '108px' }" class="--sticky-right">
                <div class="ms-table__action">
                  <div @click="returnRow(row)" class="ms-table__action-text">
                    {{ MISAResource[globalStore.lang]?.Button?.Update }}
                  </div>
                  <div
                    @dblclick.stop=""
                    @click.stop="setActionContextPos($event, row)"
                    class="ms-table__action-toggle"
                  >
                    <MISAIcon icon="triangle-down" />
                  </div>
                </div>
                <!-- fake borders -->
                <span class="ms-table__border-left"></span>
                <span class="ms-table__border-bottom"></span>
              </td>
            </tr>
          </template>

          <!-- skeleton loading -->
          <MISASkeletonRow v-else :rows="10" :columns="props.columns.length + 1" />
        </tbody>
      </table>

      <!-- table context menu -->
      <div
        v-if="actionContextMenu.isShow"
        :style="{ top: actionContextMenu.top + 'px' }"
        class="ms-table__action-context"
      >
        <slot name="context-menu"></slot>
      </div>

      <!-- table filter -->
      <Teleport to="#app">
        <div
          v-if="filterMenu.isShow"
          :style="{ top: filterMenu.top + 'px', left: filterMenu.left + 'px' }"
          class="ms-table__filter-dropdown"
        >
          <MISATableFilter
            @submit="handleOnSubmitFilter"
            @clear="handleOnRemoveFilter"
            @close="filterMenu.isShow = false"
            :column="filterMenu.column"
            :displayName="filterMenu.displayName"
            :value="filterMenu.value"
            :type="filterMenu.type"
            :filter-by="filterMenu.filterBy"
          ></MISATableFilter>
        </div>
      </Teleport>
    </div>

    <!-- table footer -->
    <slot name="footer"></slot>
  </div>
</template>

<script setup>
import { computed, onMounted, onUnmounted, ref, watch } from "vue";

import MISATableFilter from "./MISATableFilter.vue";
import MISASkeletonRow from "../skeleton-loader/MISASkeletonRow.vue";
import MISACheckbox from "../checkbox/MISACheckbox.vue";
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAResource from "@/resource/resource";
import { useGlobalStore } from "@/stores/global-store";
import enums from "@/helper/enum";

const emit = defineEmits([
  "double-click",
  "select-row",
  "active-row",
  "next-page",
  "prev-page",
  "select-page-size",
  "sort-column-change",
  "filter-change",
]);

const props = defineProps({
  /**
   * Định nghĩa các cột - các trường
   * Một đối tượng bao gồm:
   * - key: Mã cột
   * - title: Tiêu đề cột
   * - dataIndex: Tên trường để lấy dữ liệu trong dataSource (đã format)
   * - originName: Tên trường gốc tương ứng với trường API
   * - type: Kiểu của trường dữ liệu (mặc định: text)
   * - width: Độ rộng cột (mặc định: 140)
   * - align: Căn lề dữ liệu trong cột (mặc định: left)
   * - desc: Mô tả cột (hiển thị tippy)
   * - sticky: Ghim cột (left) (mặc định: không ghim)
   */
  columns: {
    type: Array,
    default() {
      return [];
    },
    required: true,
  },

  /**
   * Định nghĩa dữ liệu - các bản ghi
   * Một bản ghi bao gồm:
   * - key
   * - tên các trường tương ứng tên dataIndex
   */
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

  // Hàng đang được active (chờ xoá, nhân bản)
  activeRow: {
    type: Object,
  },

  // Thông tin của cột đang được sắp xếp
  // - sortColumn (tên cột được sắp xếp)
  // - sortOrder (kiểu sắp xếp: DESC | ASC | NONE)
  sort: {
    type: Object,
  },

  /**
   * Danh sách filter
   * - column: Tên cột tương ứng với originName của columns
   * - displayName: Tên hiển thị của cột
   * - value: Giá trị lọc
   * - type: Kiểu giá trị
   * - filterBy: Kiểu lọc (EQUAL | NOTEQUAL | CONTAIN | NOTCONTAIN)
   */
  filters: {
    type: Array,
    default() {
      return [];
    },
  },

  // Trạng thái loading dữ liệu
  loading: {
    type: Boolean,
    default: false,
  },
});

// ----- State -----
// Tham chiếu bảng (dùng để tính toán vị trí của context menu)
const tableContainerRef = ref(null);

// Cột với vị trí ghim cột
const columsWithPos = ref(props.columns);

// Trạng thái của context menu
const actionContextMenu = ref({
  isShow: false,
  top: 0,
});

// Trạng thái của menu filter
const filterMenu = ref({
  isShow: false,
  top: 0,
  left: 0,
  column: null, // Tên cột tương ứng trường API
  displayName: null, // Tên hiển thị của cột
  value: null, // Giá trị lọc
  type: null, // Kiểu giá trị
  filterBy: enums.filter.CONTAIN, // Loại lọc
});

const globalStore = useGlobalStore();

/**
 * Description: Truyền prop columns cho columsWithPos
 * mỗi khi columns thay đổi (thay đổi ngôn ngữ)
 * Author: txphuc (11/07/2023)
 */
watch(
  () => props.columns,
  () => {
    columsWithPos.value = props.columns;

    // Tính toán lại vị trí cột ghim
    calculateColumnsPos();
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

    // Cập nhật các cột ra ngoài
    emit("select-row", localSelectedRows);

    // Bỏ các cột đang active
    emit("active-row", null);
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Bỏ chọn toàn bộ bản ghi trong bảng.
 * Author: txphuc (11/07/2023).
 */
const uncheckedAllRows = () => {
  emit("select-row", []);
};

/**
 * Description: Active một hàng (chờ xoá/nhân bản)
 * Author: txphuc (09/07/2023)
 */
const setActiveRow = (row) => {
  emit("active-row", row);
  uncheckedAllRows();
};

/**
 * Description: Trả về data của hàng khi double click vào hàng đó
 * Author: txphuc (30/06/2023)
 */
const returnRow = (row) => {
  emit("double-click", row);
};

/**
 * Description: Xử lý chọn cột sắp xếp dữ liệu
 * Author: txphuc (04/08/2023)
 */
const handleSelectSortColumn = (sortColumn) => {
  try {
    if (props.sort?.sortColumn === sortColumn && props.sort?.sortOrder === enums.sort.DESC) {
      // Chuyển từ sắp xếp GIẢM DẦN sang TĂNG DẦN
      emit("sort-column-change", { sortColumn, sortOrder: enums.sort.ASC });
    } else if (props.sort?.sortColumn === sortColumn && props.sort?.sortOrder === enums.sort.ASC) {
      // Chuyển từ sắp xếp TĂNG DẦN sang KHÔNG SẮP XẾP
      emit("sort-column-change", { sortColumn: null, sortOrder: null });
    } else {
      // Chuyển từ KHÔNG SẮP XẾP sang sắp xếp TĂNG DẦN
      emit("sort-column-change", { sortColumn, sortOrder: enums.sort.DESC });
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xử lý thêm filter
 * Author: txphuc (05/08/2023)
 */
const handleOnSubmitFilter = (filter) => {
  try {
    let localFilters = JSON.parse(JSON.stringify(props.filters)) ?? [];

    const existFilter = localFilters.find((ft) => ft.column === filter.column);
    if (existFilter) {
      // Nếu filter đã tồn tại thì cập nhật giá trị và kiểu lọc
      existFilter.filterBy = filter.filterBy;
      existFilter.value = filter.value;
    } else {
      // Nếu filter chưa tồn tại thì thêm vào
      localFilters = [...localFilters, filter];
    }

    emit("filter-change", localFilters);
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xử lý xoá filter
 * Author: txphuc (05/08/2023)
 */
const handleOnRemoveFilter = (columnName) => {
  try {
    let localFilters = JSON.parse(JSON.stringify(props.filters)) ?? [];

    localFilters = localFilters.filter((filter) => filter.column !== columnName);

    emit("filter-change", localFilters);
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Tìm giá trị của filter đang được mở
 */

/**
 * Description: Xử lý tính toán vị trí của các cột khi ghim cột
 * Author: txphuc (02/07/2023)
 */
const calculateColumnsPos = () => {
  try {
    const defaultWidth = 140;
    const firstColumnWidth = 50;

    columsWithPos.value.forEach((column, index) => {
      // Nếu không được chỉ định chiều dài thì sẽ được set mặc định
      if (!column.width) {
        column.width = defaultWidth;
      }

      // Vị trí của cột hiện tại so với vị trí đầu bảng
      // bằng tổng chiều dài của các cột đứng trước nó
      // (không tính cột bị ẩn)
      const leftPos = columsWithPos.value.reduce((left, column, currentIndex) => {
        if (currentIndex < index && !column.hide) {
          return left + (column.width || defaultWidth);
        } else {
          return left;
        }
      }, 0);

      column.left = leftPos + firstColumnWidth;
    });
  } catch (error) {
    console.warn(error);
  }
};
calculateColumnsPos();

/**
 * Description: Xử lý sự kiện thay đổi kích thước cột
 * bằng cách nhấn giữ và kéo trang phải/trái
 * Author: txphuc (24/06/2023)
 */
const activeResize = (e, column) => {
  try {
    const thElement = e.target.parentElement;
    const thElementRect = thElement.getBoundingClientRect();

    // Resize cột
    const resizeColumn = (e) => {
      const mouseX = e.clientX;

      column.width = mouseX - thElementRect.left + 4;

      // Tính toán lại vị trí cột ghim
      calculateColumnsPos();
    };

    window.addEventListener("mousemove", resizeColumn);

    // Huỷ sự kiện resize cột
    window.onmouseup = () => {
      window.removeEventListener("mousemove", resizeColumn);
    };
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Xử lý hiện context menu
 * phía trên hoặc dưới dropdown theo diện tích hiển thị
 * Author: txphuc (06/07/2023)
 */
const setActionContextPos = (e, row) => {
  try {
    if (e.target && tableContainerRef.value) {
      const actionElement = e.target;
      const actionPos = actionElement.getBoundingClientRect();
      const tablePos = tableContainerRef.value.getBoundingClientRect();
      const contextMenuHeight = 124;
      const headRowHeight = 48;
      const space = 24;

      let top = 0;
      if (actionPos.y - contextMenuHeight > tablePos.y + headRowHeight) {
        // Hiện lên trên của dropdown
        top = actionPos.y - contextMenuHeight;
      } else {
        // Hiện bên dưới dropdown
        top = actionPos.y + space;
      }

      // ẩn/hiện menu
      actionContextMenu.value = {
        isShow:
          actionContextMenu.value.isShow === true && actionContextMenu.value.top === top
            ? false
            : true,
        top: top,
      };

      // set active cho hàng hiện tại
      setActiveRow(row);
    }
  } catch (error) {
    console.log(error);
  }
};

/**
 * Description: Xử lý tính toán vị trí và set giá trị cho filter menu
 * Author: txphuc (04/08/2023)
 */
const handleOpenFilterMenu = (e, column) => {
  try {
    if (e.target) {
      const filterBtn = e.target;
      const filterBtnRect = filterBtn.getBoundingClientRect();
      const filterMenuWidth = 302;
      const space = 14;

      const filterMenuPosX = filterBtnRect.left - filterMenuWidth / 2 + filterBtnRect.width / 2;
      const filterMenuPosY = filterBtnRect.top + filterBtnRect.height + space;

      // Set vị trí
      filterMenu.value = {
        isShow: filterMenu.value.isShow && filterMenu.value.left === filterMenuPosX ? false : true,
        top: filterMenuPosY,
        left: filterMenuPosX,
        column: column.originName,
        displayName: column.title,
        type: column.type,
      };

      // Tìm giá trị filter của cột hiện tại (nếu có)
      const existFilter = props.filters.find((ft) => ft.column === column.originName);
      if (existFilter) {
        filterMenu.value.filterBy = existFilter.filterBy;
        filterMenu.value.value = existFilter.value;
      }
    }
  } catch (error) {
    console.warn(error);
  }
};

/**
 * Description: Tắt context menu
 * Author: txphuc (09/07/2023)
 */
const hideContextMenu = () => {
  actionContextMenu.value.isShow = false;
};

/**
 * Description: Tắt context menu khi bấm ra
 * vị trí bất kỳ ngoài context menu
 * Author: txphuc (09/07/2023)
 */
onMounted(() => {
  document.addEventListener("click", hideContextMenu);
});

/**
 * Description: Huỷ sự kiện bấm ra ngoài context menu
 * Author: txphuc (09/07/2023)
 */
onUnmounted(() => {
  document.removeEventListener("click", hideContextMenu);
});
</script>

<style scoped>
@import url("./table.css");
</style>
