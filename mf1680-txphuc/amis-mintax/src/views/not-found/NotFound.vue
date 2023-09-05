<template>
  <div class="ms-notfound">
    <div :style="{ width: 200 + 'px' }">
      <MISATreeView
        v-model="selectedValue"
        :dataSource="dataSource"
        valueExpr="value"
        placeholder="Chọn giá trị"
      ></MISATreeView>

      <MISASelectBox
        :dataSource="dataSource"
        v-model="selectedValue"
        valueExpr="value"
        displayExpr="label"
      />
    </div>
  </div>
</template>

<script>
import MISATreeView from "@/components/base/tree-view/MISATreeView.vue";
import mockTreeViewData from "@/views/employee/mock-treeview";
import MISASelectBox from "@/components/base/select-box/MISASelectBox.vue";

export default {
  name: "NotFound",
  components: {
    MISATreeView,
    MISASelectBox,
  },
  data: function () {
    return {
      dataSource: mockTreeViewData.getEmployees(),
      selectedValue: 1,
    };
  },
};
</script>

<style lang="scss" scoped>
.ms-notfound {
  width: 100%;
  height: 100%;
  background: var(--background-medium-color);
  padding: 56px;
}
</style>
