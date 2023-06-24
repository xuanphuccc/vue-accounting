<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">Nhân viên</h1>
        <span class="page__title-icon ms-icon--angle-down-24" title="Dropdown"></span>
      </div>

      <div class="page__header-controls">
        <MISAButton type="primary">Thêm mới nhân viên</MISAButton>
      </div>
    </div>

    <div class="page__content">
      <div class="filter-container">
        <div class="filter__left">
          <div :class="['filter__select-infor', { '--active': this.selectedRows?.length > 0 }]">
            <div>
              Đã chọn
              <span id="selected-count" class="text-bold">{{ this.selectedRows?.length }}</span>
            </div>
            <MISAButton @click="this.removeAllSelectedRows" type="secondary">Bỏ chọn</MISAButton>
            <MISAButton type="danger">Xoá</MISAButton>
          </div>
        </div>
        <div class="filter__right">
          <MISAInputGroup>
            <MISAInput />
            <MISAInputAction />
          </MISAInputGroup>
          <MISAButton type="secondary" icon="ms-icon--reload-20" />
        </div>
      </div>

      <!-- table -->
      <MISATable
        :columns="[
          { key: 1, title: 'Tên khách hàng', dataIndex: 'name' },
          { key: 2, title: 'Giới tính', dataIndex: 'gender', width: 100 },
          { key: 3, title: 'Ngày sinh', dataIndex: 'dateOfBirth', width: 120 },
          { key: 4, title: 'Số điện thoại', dataIndex: 'phoneNumber', width: 100 },
          { key: 5, title: 'Hành động', dataIndex: 'action', width: 100 },
        ]"
        :data-source="[
          {
            key: 1,
            name: 'Nguyễn Văn A',
            gender: 'Male',
            dateOfBirth: '01/04/2002',
            phoneNumber: '0123456789',
            action: '',
          },
          {
            key: 2,
            name: 'Nguyễn Văn B',
            gender: 'Male',
            dateOfBirth: '01/04/2002',
            phoneNumber: '0123456789',
            action: '',
          },
          {
            key: 3,
            name: 'Trần Xuân Phúc',
            gender: 'Male',
            dateOfBirth: '01/04/2002',
            phoneNumber: '0123456789',
            action: '',
          },
        ]"
        :selected-rows="this.selectedRows"
        @select-row="this.selectRows"
      >
        <template #name="row">
          <MISAButton type="link">{{ row["name"] }}</MISAButton>
        </template>
        <template #action="row">
          <MISAButtonGroup>
            <MISAButton @click="this.deleteData(row)" type="secondary">Sửa</MISAButton>
            <MISAButton type="secondary">Thêm</MISAButton>
            <MISAButton type="secondary" icon="ms-icon--angle-down-20"></MISAButton>
            <MISAButton type="secondary" icon="ms-icon--angle-down-20"></MISAButton>
          </MISAButtonGroup>
        </template>
      </MISATable>

      <!-- Modal -->
      <Teleport to="#app">
        <MISADialog
          v-bind="this.dialog"
          @close="this.dialog.active = false"
          @cancel="this.dialog.active = false"
        />
      </Teleport>
    </div>
  </div>
</template>

<script>
import MISAButton from "../../components/base/button/MISAButton.vue";
import MISAButtonGroup from "../../components/base/button/MISAButtonGroup.vue";
import MISAInput from "../../components/base/input/MISAInput.vue";
import MISAInputGroup from "../../components/base/input/MISAInputGroup.vue";
import MISAInputAction from "../../components/base/input/MISAInputAction.vue";
import MISATable from "../../components/base/table/MISATable.vue";
import MISADialog from "../../components/base/dialog/MISADialog.vue";

export default {
  components: {
    MISAButton,
    MISATable,
    MISAInput,
    MISAInputGroup,
    MISAInputAction,
    MISADialog,
    MISAButtonGroup,
  },
  data() {
    return {
      selectedRows: [],
      dialog: {
        active: false,
        title: "",
        description: "",
      },
    };
  },
  methods: {
    /**
     * Hàm xử lý chọn dòng
     * Createdby: sdnfsdf(24/06/2023)
     * @param {*} value
     */
    selectRows(value) {
      this.selectedRows = value;
    },
    removeAllSelectedRows() {
      this.selectedRows = [];
    },
    deleteData(data) {
      this.dialog = {
        active: true,
        title: "Xoá nhân viên",
        type: "error",
        description: `Bạn có muốn xoá nhân viên ${data.name}`,
      };
    },
  },
};
</script>

<style scoped></style>
