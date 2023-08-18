<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">Hồ sơ người nộp thuế</h1>
      </div>

      <div class="page__header-controls">
        <MISAButton color="secondary"
          >Đồng bộ AMIS Hệ thống
          <template slot="icon">
            <MISAIcon icon="amis-system" />
          </template>
        </MISAButton>

        <MISAButton
          @click="
            () => {
              this.$router.push({ name: 'manage-license' });
            }
          "
          color="secondary"
          >Quản lý lao động sử dụng dịch vụ
          <template slot="icon">
            <MISAIcon color="#007aff" icon="manage-license" no-color />
          </template>
        </MISAButton>
      </div>
    </div>

    <div class="page__content">
      <div class="controls-wrapper">
        <div v-if="selectedRowsData?.length > 0" class="selection-container">
          <div class="selection-info">
            <span>Đã chọn</span>
            <span class="text-bold selection-info__number">{{ selectedRowsData?.length }}</span>

            <div class="v-separate"></div>

            <MISAButton @click="clearAllSelection" type="link" color="danger">Bỏ chọn</MISAButton>
          </div>
          <div class="selection-controls">
            <div class="controls__group">
              <MISAButton color="secondary">
                Lập tờ khai
                <template slot="icon">
                  <MISAIcon size="20" icon="plus" />
                </template>
              </MISAButton>

              <MISAButton color="secondary">
                Lập thủ tục
                <template slot="icon">
                  <MISAIcon size="20" icon="plus" />
                </template>
              </MISAButton>
            </div>

            <div class="controls__group">
              <MISAButton color="secondary">
                Xuất khẩu
                <template slot="icon">
                  <MISAIcon size="20" icon="export" />
                </template>
              </MISAButton>

              <MISAButton color="secondary">
                Xoá
                <template slot="icon">
                  <MISAIcon color="#eb3333" size="20" icon="trash" />
                </template>
              </MISAButton>
            </div>
          </div>
        </div>

        <div v-if="selectedRowsData?.length === 0" class="filter-container">
          <div class="filter__left">
            <div class="controls__group">
              <DxTextBox placeholder="Tìm theo Mã/Tên nhân viên">
                <div class="input-action">
                  <MISAIcon size="20" icon="search" />
                </div>
              </DxTextBox>

              <MISASelectBox placeholder="Bộ phận/phòng ban" />
            </div>

            <div class="controls__group">
              <MISAButton color="secondary">
                Xuất khẩu
                <template slot="icon">
                  <MISAIcon :size="20" icon="export" />
                </template>
              </MISAButton>
            </div>
          </div>

          <div class="filter__right">
            <MISAButtonGroup>
              <MISAButton
                @click="
                  () => {
                    this.$router.push({ name: 'employee-detail' });
                  }
                "
              >
                Thêm mới
                <template slot="icon">
                  <MISAIcon size="20" icon="plus" />
                </template>
              </MISAButton>
              <MISAButton>
                <template slot="icon">
                  <MISAIcon :size="20" icon="angle-down" />
                </template>
              </MISAButton>
            </MISAButtonGroup>

            <MISAButton color="secondary">
              <template slot="icon">
                <MISAIcon size="20" icon="mintax-filter" />
              </template>
            </MISAButton>
            <MISAButton color="secondary">
              <template slot="icon">
                <MISAIcon size="20" icon="setting-gear" />
              </template>
            </MISAButton>
          </div>
        </div>
      </div>

      <!-- Table -->
      <MISATable
        @selection-changed="onSelectionChanged"
        @row-dbl-click="onRowDoubleClick"
        @sort-change="onSortChange"
        @fixed-column-change="onFixedColumnChange"
        :sort="filterRequest"
        :columns="tableColumns"
        :dataSource="dataSource"
        keyExpr="EmployeeID"
        ref="tableRef"
      ></MISATable>
      <MISATableFooter :pageSize="15" :totalRecords="100" />

      <!-- Table customize -->
      <MISATableCustomize v-if="false" :columns="tableColumns" :defaultColumns="defaultColumns" />
    </div>
  </div>
</template>

<script>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISAButtonGroup from "@/components/base/button/MISAButtonGroup.vue";
import MISATable from "@/components/base/table/MISATable.vue";
import MISATableFooter from "@/components/base/table-footer/MISATableFooter.vue";
import MISATableCustomize from "@/components/base/table-customize/MISATableCustomize.vue";
import DxTextBox from "devextreme-vue/text-box";
import MISASelectBox from "@/components/base/select-box/MISASelectBox.vue";
import mockEmployee from "./mock-employee";

const defaultColumns = [
  {
    dataField: "EmployeeID",
    caption: "Mã nhân viên",
    dataType: "number",
    alignment: "left",
    customizeText: (e) => "NV" + e.value,
    fixed: true,
    width: 150,
  },
  {
    dataField: "FullName",
    caption: "Tên nhân viên",
    dataType: "string",
    alignment: "left",
    width: 150,
    fixed: true,
    allowSorting: false,
  },
  {
    dataField: "Position",
    caption: "Chức danh",
    dataType: "string",
    alignment: "left",
    width: 180,
  },
  {
    dataField: "BirthDate",
    caption: "Ngày sinh",
    dataType: "date",
    alignment: "center",
    width: 180,
  },
  {
    dataField: "Address",
    caption: "Địa chỉ",
    dataType: "string",
    alignment: "left",
    width: 240,
  },
  {
    dataField: "City",
    caption: "Thành phố",
    dataType: "string",
    alignment: "left",
    width: 150,
  },
  {
    dataField: "Region",
    caption: "Khu vực",
    dataType: "string",
    alignment: "left",
    width: 150,
  },
  {
    dataField: "PostalCode",
    caption: "Mã bưu chính",
    dataType: "string",
    alignment: "left",
    width: 150,
  },
  {
    dataField: "Country",
    caption: "Quốc gia",
    dataType: "string",
    alignment: "left",
    width: 150,
  },
];

export default {
  name: "EmployeeList",
  components: {
    MISAIcon,
    MISAButton,
    MISAButtonGroup,
    MISATable,
    MISATableFooter,
    MISATableCustomize,
    DxTextBox,
    MISASelectBox,
  },
  data: function () {
    return {
      dataSource: mockEmployee.getEmployees() || [],
      defaultColumns: [...defaultColumns],
      tableColumns: [...defaultColumns],
      selectedRowsData: [],
      filterRequest: {
        sortColumn: null,
        sortOrder: null,
      },
    };
  },
  methods: {
    /**
     * Description: Lấy các hàng được chọn
     * Author: txphuc (17/08/2023)
     */
    onSelectionChanged(data) {
      this.selectedRowsData = data.selectedRowsData;
    },

    /**
     * Description: Xử lý khi double click vào một hàng
     * Author: txphuc (17/08/2023)
     */
    onRowDoubleClick(data) {
      console.log(data);
    },

    /**
     * Description: Bỏ chọn tất cả dòng
     * Author: txphuc (17/08/2023)
     */
    clearAllSelection() {
      console.log(this.$refs);
      this.$refs.tableRef.clearAllSelection();
    },

    /**
     * Description: Lấy thông tin sắp xếp
     * Author: txphuc (17/08/2023)
     */
    onSortChange(column) {
      this.filterRequest.sortColumn = column.dataField;
      this.filterRequest.sortOrder = column.sortOrder;
    },

    /**
     * Description: Lấy thông tin ghim cột
     * Author: txphuc (17/08/2023)
     */
    onFixedColumnChange(columns) {
      this.tableColumns = columns;
    },

    test(e) {
      console.log(e);
    },
  },
};
</script>

<style scoped></style>
