<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">
          <div
            @click="
              () => {
                this.$router.push({ name: 'employee' });
              }
            "
            class="page__back-btn"
          >
            <MISAIcon size="24" icon="arrow-left" />
          </div>
          Quản lý lao động sử dụng dịch vụ
        </h1>
      </div>

      <div class="page__header-controls">
        <MISAButton color="primary"
          >Thiết lập quy tắc tự động
          <template slot="icon">
            <MISAIcon icon="mintax-setting" />
          </template>
        </MISAButton>
      </div>
    </div>

    <div v-if="isOpenCounter" class="counter-block">
      <div class="counter-block__item --blue">
        <div class="counter-block__number">1078</div>
        <div class="counter-block__title">Tổng số lao động</div>
        <div class="counter-block__text">
          Tất cả người nộp thuế có loại đối tượng là Nhân viên Vãng lai trên AMIS Thuế TNCN
        </div>
      </div>
      <div class="counter-block__item --green">
        <div class="counter-block__number">1078</div>
        <div class="counter-block__title">Tổng số lao động</div>
        <div class="counter-block__text">
          Tất cả người nộp thuế có loại đối tượng là Nhân viên Vãng lai trên AMIS Thuế TNCN
        </div>
      </div>
      <div class="counter-block__item --red">
        <div class="counter-block__number">1078</div>
        <div class="counter-block__title">Tổng số lao động</div>
        <div class="counter-block__text">
          Tất cả người nộp thuế có loại đối tượng là Nhân viên Vãng lai trên AMIS Thuế TNCN
        </div>
      </div>
    </div>
    <div :class="['counter-block-collapse', { '--collapse': !isOpenCounter }]">
      <div class="counter-block-collapse__line"></div>
      <div @click="toggleCounter" class="counter-block-collapse__thumb">
        <MISAIcon size="16" icon="angle-down" />
      </div>
    </div>

    <div class="page__content">
      <div class="controls-wrapper">
        <div v-if="selectedRowsData.length > 0" class="selection-container">
          <div class="selection-info">
            <span>Đã chọn</span>
            <span class="text-bold selection-info__number">{{ selectedRowsData.length }}</span>

            <div class="v-separate"></div>

            <MISAButton @click="clearAllSelection" type="link" color="danger">Bỏ chọn</MISAButton>
          </div>
          <div class="selection-controls">
            <div class="selection-controls__group">
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

            <div class="selection-controls__group">
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

        <div v-if="selectedRowsData.length === 0" class="filter-container">
          <div class="filter__left"></div>

          <div class="filter__right">
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
      <MISATableFooter />
    </div>
  </div>
</template>

<script>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISATable from "@/components/base/table/MISATable.vue";
import MISATableFooter from "@/components/base/table-footer/MISATableFooter.vue";
import mockEmployee from "@/views/employee/mock-employee";

export default {
  name: "EmployeeList",
  components: {
    MISAIcon,
    MISAButton,

    MISATable,
    MISATableFooter,
  },
  data: function () {
    return {
      dataSource: mockEmployee.getEmployees(),
      tableColumns: [
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
      ],
      isOpenCounter: true,
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

    /**
     * Description: Đóng/mở counter (đếm nhân viên)
     * Author: txphuc (17/08/2023)
     */
    toggleCounter() {
      this.isOpenCounter = !this.isOpenCounter;
    },
  },
};
</script>

<style scoped></style>
