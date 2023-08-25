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
        <div class="counter-block__number">{{ usageCount.totalRecords }}</div>
        <div class="counter-block__title">Tổng số lao động</div>
        <div class="counter-block__text">
          Tất cả người nộp thuế có loại đối tượng là Nhân viên và Vãng lai trên AMIS Thuế TNCN
        </div>
      </div>
      <div class="counter-block__item --green">
        <div class="counter-block__number">{{ usageCount.usedRecords }}</div>
        <div class="counter-block__title">Đang sử dụng dịch vụ</div>
        <div class="counter-block__text">
          Người nộp thuế có loại đối tượng là Nhân viên và Vãng lai có thiết lập sử dụng dịch vụ
          Thuế TNCN
        </div>
      </div>
      <div class="counter-block__item --red">
        <div class="counter-block__number">{{ usageCount.unusedRecords }}</div>
        <div class="counter-block__title">Không sử dụng dịch vụ</div>
        <div class="counter-block__text">
          Người nộp thuế có loại đối tượng là Nhân viên và Vãng lai không thiết lập sử dụng dịch vụ
          Thuế TNCN
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
            <div class="controls__group">
              <MISAButton color="secondary">
                Sử dụng
                <template slot="icon">
                  <MISAIcon color="#50b83c" size="20" icon="plus" />
                </template>
              </MISAButton>
            </div>

            <div class="controls__group">
              <MISAButton color="secondary">
                Ngừng sử dụng
                <template slot="icon">
                  <MISAIcon color="#eb3333" size="20" icon="circle-slash" />
                </template>
              </MISAButton>
            </div>
          </div>
        </div>

        <div v-if="selectedRowsData.length === 0" class="filter-container">
          <div class="filter__left">
            <div class="controls__group">
              <MISATextBox placeholder="Tìm theo Mã/Tên nhân viên">
                <MISAIcon size="20" icon="search" />
              </MISATextBox>

              <MISATreeView placeholder="Bộ phận/phòng ban" />

              <MISASelectBox placeholder="Trạng thái sử dụng" />
            </div>
          </div>

          <div class="filter__right">
            <MISAButton @click="isOpenTableCustomize = true" color="secondary">
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
        :data-source="dataSource"
        keyExpr="EmployeeID"
        :action-column-enabled="false"
        ref="tableRef"
      ></MISATable>
      <MISATableFooter />

      <!-- Tuỳ chỉnh cột -->
      <MISATableCustomize
        @close="isOpenTableCustomize = false"
        @change="applyTableCustomize"
        v-if="isOpenTableCustomize"
        :columns="tableColumns"
        :defaultColumns="defaultColumns"
      />
    </div>
  </div>
</template>

<script>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISATextBox from "@/components/base/text-box/MISATextBox.vue";
import MISATable from "@/components/base/table/MISATable.vue";
import MISATableFooter from "@/components/base/table-footer/MISATableFooter.vue";
import MISATableCustomize from "@/components/base/table-customize/MISATableCustomize.vue";
import employeeColumns from "../employee/employee-columns";
import MISATreeView from "@/components/base/tree-view/MISATreeView.vue";
import MISASelectBox from "@/components/base/select-box/MISASelectBox.vue";
import employeeApi from "@/api/employee-api";

export default {
  name: "EmployeeList",
  components: {
    MISAIcon,
    MISAButton,
    MISATextBox,
    MISATreeView,
    MISASelectBox,
    MISATable,
    MISATableFooter,
    MISATableCustomize,
  },
  data: function () {
    return {
      dataSource: [],

      defaultColumns: [...employeeColumns],

      // Loại bỏ tham chiếu tránh thay đổi mảng gốc
      tableColumns: employeeColumns.map((col) => ({ ...col })),

      isOpenCounter: true,

      // Các bản ghi đang được chọn
      selectedRowsData: [],

      // Filter
      filterRequest: {
        page: 1,
        pageSize: 15,
        search: null,
        sortColumn: null,
        sortOrder: null,
      },

      // Thông tin phân trang
      pagingInfo: {
        totalRecords: 0,
        totalPages: 0,
      },

      // Đếm số bản ghi đang sử dụng
      usageCount: {
        totalRecords: 0,
        usedRecords: 0,
        unusedRecords: 0,
      },

      isOpenTableCustomize: false,
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

    /**
     * Description: Lưu sự thay đổi tuỳ chỉnh cột
     * Author: txphuc (18/08/2023)
     */
    applyTableCustomize(columns) {
      this.tableColumns = columns;
    },

    /**
     * Description: Hàm load dữ liệu danh sách nhân viên từ api
     * Author: txphuc (27/06/2023)
     */
    async getEmployeesData() {
      try {
        // Loading
        this.$store.dispatch("commonStore/setLoading", true);

        const response = await employeeApi.filter(this.filterRequest);

        // Hiển thị dữ liệu ra bảng
        this.dataSource = response.data?.Data;

        // Lấy dữ liệu phân trang
        const totalRecords = response.data.TotalRecords;
        const pageSize = this.filterRequest.pageSize;
        const totalPages = Math.ceil(totalRecords / pageSize);

        this.pagingInfo.totalRecords = totalRecords;
        this.pagingInfo.totalPages = totalPages;

        // Tắt loading
        this.$store.dispatch("commonStore/setLoading", false);

        // Nếu trang hiện tại không có data thì về trang cuối
        // (dùng cho trường hợp xoá hết bản ghi trang cuối)
        if (response.data?.Data?.length === 0) {
          this.filterRequest.page = totalPages;
        }
      } catch (error) {
        console.warn(error);
      }
    },

    /**
     * Description: Đếm số bản ghi đang sử dụng
     * Author: txphuc (25/08/2023)
     */
    async getUsageCount() {
      try {
        const response = await employeeApi.getUsageCount();

        const usageCount = response.data;

        const totalRecords = usageCount.TotalRecords;
        const usedRecords = usageCount.UsedRecords;

        this.usageCount = {
          totalRecords,
          usedRecords,
          unusedRecords: totalRecords - usedRecords,
        };
      } catch (error) {
        console.warn(error);
      }
    },
  },

  /**
   * Description: Get dữ liệu khi khởi tạo
   * Author: txphuc (22/08/2023)
   */
  created: function () {
    this.getEmployeesData();

    this.getUsageCount();
  },
};
</script>

<style scoped></style>
