<template>
  <div class="ms-table">
    <div ref="tableContainerRef" @scroll="changeActionsPos" class="ms-table__container">
      <table class="ms-table__table">
        <thead>
          <tr>
            <th>
              <input
                @click="selectRow(props.dataSource)"
                :checked="props.selectedRows.length === props.dataSource.length"
                type="checkbox"
                name=""
              />
            </th>
            <th
              v-for="column in props.columns"
              :key="column.key"
              :style="{
                width: column.width ? column.width + 'px' : '',
                textAlign: column.align ? column.align : '',
              }"
            >
              {{ column.title }}

              <!-- resize column -->
              <span @mousedown="activeResize" class="ms-table__col-resize"></span>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="row in dataSourceWithSelectedRows"
            :key="row.key"
            :class="[{ '--active': row.checked }]"
          >
            <td>
              <input @click="selectRow(row)" :checked="row.checked" type="checkbox" name="" id="" />
            </td>
            <template v-for="column in props.columns" :key="column.key">
              <td :style="{ textAlign: column.align ? column.align : '' }">
                <slot :name="column.dataIndex" v-bind="row">
                  {{ row[column.dataIndex] }}
                </slot>
              </td>
            </template>

            <!-- table actions -->
            <div class="ms-table__actions" :style="{ right: tableActionsPosState + 'px' }">
              <slot name="table-actions" v-bind="row"></slot>
            </div>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="ms-table__footer">
      <p class="total-row">
        <span>Tổng: </span>
        <span class="text-bold">{{ props.dataSource.length }}</span>
      </p>
      <div class="ms-table__page-infor">
        <div class="ms-table__page-size">
          <span>Số bản ghi/trang: 10</span>
          <span class="ms-table__dropdown-btn ms-icon--angle-down-24" title="Dropdown"> </span>
        </div>

        <div class="ms-table__records-range">
          <p>
            1 -
            <span class="text-bold">{{ props.dataSource.length }}</span>
            bản ghi
          </p>
        </div>

        <div class="ms-table__page-controls">
          <span
            class="ms-table__prev-btn ms-icon--angle-left-24 disable"
            title="Trang trước"
          ></span>
          <span class="ms-table__next-btn ms-icon--angle-right-24" title="Trang sau"></span>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed, ref, onMounted } from "vue";

const emit = defineEmits(["select-row"]);

const props = defineProps({
  // Định nghĩa các cột - các trường
  // một trường bao gồm: key, title, dataIndex, width, align
  columns: {
    type: Array,
    default() {
      return [];
    },
  },

  // Định nghĩa dữ liệu - các bản ghi
  // một bản ghi bao gồm: key, tên trường (dataIndex)
  dataSource: {
    type: Array,
    default() {
      return [];
    },
  },

  // Các bản ghi đã được chọn
  selectedRows: {
    type: Array,
    default() {
      return [];
    },
  },
});

// ----- State -----
const tableActionsPosState = ref(0);
const tableContainerRef = ref(null);

/**
 * Description: Xử lý thêm trường "checked" với bản ghi
 * đã được chọn
 * Author: txphuc (24/06/2023)
 */
const dataSourceWithSelectedRows = computed(() => {
  try {
    return props.dataSource?.map((row) => {
      row["checked"] = props.selectedRows?.find((selectedItem) => selectedItem.key == row.key);
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

    // Chọn nhiều hàng
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
 * Description: Lấy chiều dài đã cuộn đẻ di chuyển vị trí
 * của các nút actions vào khung nhìn
 * Author: txphuc (25/06/2023)
 */
const changeActionsPos = () => {
  const scrollWidth = tableContainerRef.value.scrollWidth;
  const scrollLeft = tableContainerRef.value.scrollLeft;
  const clientWidth = tableContainerRef.value.clientWidth;

  tableActionsPosState.value = scrollWidth - clientWidth - scrollLeft + 16;
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
