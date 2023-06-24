<template>
  <div class="ms-table">
    <div class="ms-table__container">
      <table class="ms-table__table">
        <thead>
          <tr>
            <th>
              <input
                @click="this.selectRow(this.dataSource)"
                :checked="this.selectedRows.length === this.dataSource.length"
                type="checkbox"
                name=""
              />
            </th>
            <th v-for="item in this.columns" :key="item.key">
              {{ item.title }}

              <!-- resize column -->
              <span @mousedown="this.activeResize" class="ms-table__col-resize"></span>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="row in this.dataSourceWithSelectedRows" :key="row.key">
            <td>
              <input
                @click="this.selectRow(row)"
                :checked="row.checked"
                type="checkbox"
                name=""
                id=""
              />
            </td>
            <template v-for="(column, index) in Object.keys(row)" :key="index">
              <td v-if="column !== 'key' && column !== 'checked'">
                <slot :name="column" v-bind="row">
                  {{ row[column] }}
                </slot>
              </td>
            </template>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="ms-table__footer">
      <p class="total-row">
        <span>Tổng: </span>
        <span class="text-bold">{{ this.dataSource?.length }}</span>
      </p>
      <div class="ms-table__page-infor">
        <div class="ms-table__page-size">
          <span>Số bản ghi/trang: 10</span>
          <span class="ms-table__dropdown-btn ms-icon--angle-down-24" title="Dropdown"> </span>
        </div>

        <div class="ms-table__records-range">
          <p>
            1 -
            <span class="text-bold">{{ this.dataSource?.length }}</span>
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

<script>
export default {
  name: "MISATable",
  emits: ["select-row"],
  props: {
    columns: {
      type: Array,
      default() {
        return [];
      },
    },
    dataSource: {
      type: Array,
      default() {
        return [];
      },
    },
    selectedRows: {
      type: Array,
      default() {
        return [];
      },
    },
  },
  data() {
    return {};
  },
  computed: {
    dataSourceWithSelectedRows() {
      return this.dataSource?.map((row) => {
        row["checked"] = this.selectedRows?.find((selectedItem) => selectedItem.key == row.key);
        return row;
      });
    },
  },
  methods: {
    selectRow(value) {
      try {
        let localSelectedRows = [...this.selectedRows];

        // select all rows
        if (Array.isArray(value)) {
          if (localSelectedRows.length === this.dataSource?.length) {
            localSelectedRows = [];
          } else {
            localSelectedRows = value;
          }

          // select row
        } else {
          if (localSelectedRows.find((selectedRow) => selectedRow.key == value.key)) {
            localSelectedRows = localSelectedRows.filter(
              (selectedRow) => selectedRow.key !== value.key
            );
          } else {
            localSelectedRows.push(value);
          }
        }

        this.$emit("select-row", localSelectedRows);
      } catch (error) {
        console.warn(error);
      }
    },
    // enable resizing when resize button pressed
    activeResize(e) {
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
    },
  },
};
</script>

<style scoped>
@import url("./table.css");
</style>
