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
              <MISATextBox @enter-key="applySearch" placeholder="Tìm theo Mã/Tên nhân viên">
                <MISAIcon size="20" icon="search" />
              </MISATextBox>

              <MISATreeView placeholder="Bộ phận/phòng ban" />
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

            <MISAButton @click="isOpenFilterPopup = true" color="secondary">
              <template slot="icon">
                <MISAIcon size="20" icon="mintax-filter" />
              </template>
            </MISAButton>
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
        :dataSource="dataSource"
        keyExpr="EmployeeID"
        ref="tableRef"
      ></MISATable>

      <!-- Phân trang -->
      <MISATableFooter
        @next-page="onNextPage"
        @prev-page="onPrevPage"
        @select-page-size="onPageSizeChange"
        :currentPage="filterRequest.page"
        :pageSize="filterRequest.pageSize"
        :totalRecords="pagingInfo.totalRecords"
        :totalPages="pagingInfo.totalPages"
      />

      <!-- Tuỳ chỉnh cột -->
      <MISATableCustomize
        @close="isOpenTableCustomize = false"
        @change="applyTableCustomize"
        v-if="isOpenTableCustomize"
        :columns="tableColumns"
        :defaultColumns="defaultColumns"
      />

      <!-- Bộ lọc nâng cao -->
      <MISAFilterPopup @close="isOpenFilterPopup = false" v-if="isOpenFilterPopup" />
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
import MISATextBox from "@/components/base/text-box/MISATextBox.vue";
import MISATreeView from "@/components/base/tree-view/MISATreeView.vue";
import MISAFilterPopup from "@/components/base/filter-popup/MISAFilterPopup.vue";
import mockEmployee from "./mock-employee";
import employeeColumns from "./employee-columns";
import employeeApi from "@/api/employee-api";

export default {
  name: "EmployeeList",
  components: {
    MISAIcon,
    MISAButton,
    MISAButtonGroup,
    MISATable,
    MISATableFooter,
    MISATableCustomize,
    MISAFilterPopup,
    MISATextBox,
    MISATreeView,
  },
  data: function () {
    return {
      dataSource: mockEmployee.getEmployees() || [],

      defaultColumns: [...employeeColumns],

      // Loại bỏ tham chiếu tránh thay đổi mảng gốc
      tableColumns: employeeColumns.map((col) => ({ ...col })),

      // Các bản ghi đã được chọn (xoá nhiều)
      selectedRowsData: [],

      // Bộ lọc, tìm kiếm, sắp xếp, phân trang
      filterRequest: {
        page: 1,
        pageSize: 15,
        search: null,
        sortColumn: null,
        sortOrder: null,
      },

      // Thông tin phân trang
      pagingInfo: {
        totalPages: 0,
        totalRecords: 0,
      },

      // Trạng thái của các popup
      isOpenTableCustomize: false,
      isOpenFilterPopup: false,

      // Trạng thái loading của table
      loading: {
        table: false,
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
     * Description: Lưu sự thay đổi tuỳ chỉnh cột
     * Author: txphuc (18/08/2023)
     */
    applyTableCustomize(columns) {
      this.tableColumns = columns;
    },

    /**
     * Description: Xử lý sang trang tiếp theo
     * Author: txphuc (22/08/2023)
     */
    onNextPage(page) {
      this.filterRequest.page = page;
    },

    /**
     * Description: Xử lý sang trang trước đó
     * Author: txphuc (22/08/2023)
     */
    onPrevPage(page) {
      this.filterRequest.page = page;
    },

    /**
     * Description: Xử lý thay đổi page size
     * Author: txphuc (22/08/2023)
     */
    onPageSizeChange(pageSize) {
      this.filterRequest.pageSize = pageSize;

      // Về trang đầu khi đổi page size
      this.filterRequest.page = 1;
    },

    /**
     * Description: Apply search để bắt đầu tìm kiếm
     * Author: txphuc (22/08/2023)
     */
    applySearch(e) {
      this.filterRequest.search = e.event?.target?.value;

      // Về trang đầu khi tìm kiếm
      this.filterRequest.page = 1;
    },

    /**
     * Description: Hàm load dữ liệu danh sách nhân viên từ api
     * Author: txphuc (27/06/2023)
     */
    async getEmployeesData() {
      try {
        this.loading.table = true;

        const response = await employeeApi.filter(this.filterRequest);

        // Hiển thị dữ liệu ra bảng
        this.dataSource = response.data?.Data;

        // Lấy dữ liệu phân trang
        const totalRecords = response.data.TotalRecords;
        const pageSize = this.filterRequest.pageSize;
        const totalPages = Math.ceil(totalRecords / pageSize);

        this.pagingInfo.totalRecords = totalRecords;
        this.pagingInfo.totalPages = totalPages;

        this.loading.table = false;

        // Nếu trang hiện tại không có data thì về trang cuối
        // (dùng cho trường hợp xoá hết bản ghi trang cuối)
        if (response.data?.Data?.length === 0) {
          this.filterRequest.page = totalPages;
        }
      } catch (error) {
        console.warn(error);
      }
    },
  },

  watch: {
    /**
     * Description: Gọi lại data khi filter thay đổi
     * Author: txphuc (22/08/2023)
     */
    filterRequest: {
      handler: function () {
        this.getEmployeesData();
      },
      deep: true,
    },
  },

  /**
   * Description: Get dữ liệu khi khởi tạo
   * Author: txphuc (22/08/2023)
   */
  created: function () {
    this.getEmployeesData();
  },
};
</script>

<style scoped></style>
