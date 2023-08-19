<template>
  <DxDropDownBox
    :input-attr="{ 'aria-label': 'Owner' }"
    :show-clear-button="true"
    :data-source="treeDataSource"
    value-expr="ID"
    display-expr="name"
    :placeholder="placeholder"
    drop-down-button-template="imageIcon"
  >
    <template #content="{}">
      <DxTreeView
        :data-source="treeDataSource"
        :select-by-click="true"
        data-structure="plain"
        key-expr="ID"
        parent-id-expr="categoryId"
        selection-mode="single"
        display-expr="name"
        :search-enabled="true"
      />
    </template>

    <template #imageIcon="{}">
      <div :class="['select-dropdown-icon']">
        <MISAIcon size="16" icon="angle-down" />
      </div>
    </template>
  </DxDropDownBox>
</template>

<script>
import DxDropDownBox from "devextreme-vue/drop-down-box";
import DxTreeView from "devextreme-vue/tree-view";
import mockTreeViewData from "@/views/employee/mock-treeview";
import MISAIcon from "../icon/MISAIcon.vue";

export default {
  name: "MISATreeView",
  components: {
    DxDropDownBox,
    DxTreeView,
    MISAIcon,
  },
  props: {
    // Gợi ý
    placeholder: {
      type: String,
    },
  },
  data: function () {
    return {
      treeDataSource: mockTreeViewData.getEmployees(),
    };
  },
};
</script>

<style>
@import url("./tree-view.scss");
</style>
