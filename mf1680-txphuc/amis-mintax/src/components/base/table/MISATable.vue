<template>
  <div class="ms-table">
    <DxDataGrid
      id="grid-container"
      :data-source="dataSource"
      :key-expr="keyExpr"
      :allow-column-resizing="true"
      column-resizing-mode="widget"
      :column-auto-width="true"
      :show-row-lines="true"
      :show-column-lines="false"
      :show-borders="false"
      :hover-state-enabled="true"
      @selection-changed="$emit('selection-changed', $event)"
      @row-dbl-click="$emit('row-dbl-click', $event)"
    >
      <!-- Cột chọn dòng -->
      <DxColumn type="selection" :width="44" :allow-resizing="false" />
      <DxSelection mode="multiple" show-check-boxes-mode="always" />

      <!-- Các cột dữ liệu -->
      <DxColumn
        v-for="column in columns"
        :key="column.dataField"
        v-bind="column"
        :allow-sorting="false"
        header-cell-template="headerCellTemplate"
      />
      <template #headerCellTemplate="{ data }">
        <div class="ms-table__header-cell">
          {{ data.column.caption }}
          <span class="ms-table__sort-icon">
            <MISAIcon size="20" icon="arrow-down" />
          </span>

          <div class="ms-table__pin-icon">
            <MISAIcon size="20" icon="pin" />
          </div>
        </div>
      </template>

      <!-- Cột action -->
      <DxColumn cell-template="cellTemplate" css-class="ms-table__action-column"> </DxColumn>
      <template #cellTemplate="{}">
        <div class="ms-table__action-container">
          <MISAButton type="rounded" color="secondary">
            <template slot="icon">
              <MISAIcon size="20" icon="new-window" />
            </template>
          </MISAButton>

          <MISAButton type="rounded" color="secondary">
            <template slot="icon">
              <MISAIcon size="20" icon="pen" />
            </template>
          </MISAButton>

          <MISAButton type="rounded" color="secondary">
            <template slot="icon">
              <MISAIcon color="#eb3333" size="20" icon="trash" />
            </template>
          </MISAButton>
        </div>
      </template>
    </DxDataGrid>
  </div>
</template>

<script>
import { DxDataGrid, DxColumn, DxSelection } from "devextreme-vue/data-grid";
import MISAButton from "../button/MISAButton.vue";
import MISAIcon from "../icon/MISAIcon.vue";

export default {
  name: "MISATable",
  components: {
    DxDataGrid,
    DxColumn,
    DxSelection,
    MISAButton,
    MISAIcon,
  },
  emits: ["selection-changed", "row-dbl-click"],
  props: {
    // Các cột của bảng
    columns: {
      type: Array,
      default() {
        return [];
      },
    },

    // Dữ liệu của bảng
    dataSource: {
      type: Array,
      default() {
        return [];
      },
    },

    // Trường lấy làm khoá
    keyExpr: {
      type: String,
      default: "",
    },
  },
  data: function () {
    return {};
  },
  methods: {
    selectEmployee(test) {
      console.log(test);
    },
    cloneIconClick(e) {
      console.log("click");
      console.log(e);
    },
  },
};
</script>

<style lang="scss">
@import url("./table.scss");
</style>
