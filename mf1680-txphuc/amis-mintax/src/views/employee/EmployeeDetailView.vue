<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">
          <div
            v-tooltip="'Quay lại'"
            @click="
              () => {
                this.$router.push({ name: 'employee' });
              }
            "
            class="page__back-btn"
          >
            <MISAIcon size="24" icon="arrow-left" />
          </div>
          Thông tin người nộp thuế
        </h1>
      </div>

      <div class="page__header-controls">
        <MISAButton @click="showDeleteConfirmDialog" color="light-danger">
          <template #icon>
            <MISAIcon size="20" icon="trash" />
          </template>
          Xoá
        </MISAButton>

        <MISAButton @click="onClickEditButton" color="primary">
          <template #icon>
            <MISAIcon size="20" icon="pen" />
          </template>
          Chỉnh sửa
        </MISAButton>
      </div>
    </div>

    <div class="page__content">
      <div class="form-content">
        <div class="form-sidebar">
          <div
            @click="onClickSidebar(item.key)"
            v-for="item in formSidebarItems"
            :key="item.key"
            :class="['form-sidebar__item', { '--active': item.key === activeFormSidebarItem }]"
          >
            {{ item.title }}
          </div>
        </div>
        <div class="form-content-wrapper">
          <div ref="mainInfo" class="form-content__header pb-24">Thông tin chung</div>

          <div class="form-content__subheader">Thông tin cá nhân</div>

          <div class="mb-24">
            <MISARow :gutter="{ x: 80 }">
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Loại đối tượng
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.EmployeeTypeName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <label for="test" class="height-36 d-flex align-center flex-wrap pr-12">
                        Mã người nộp thuế
                      </label>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">{{ employeeFormated?.EmployeeCode }}</div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Họ tên</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">{{ employeeFormated?.FullName ?? "-" }}</div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Ngày sinh</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.DateOfBirthFormated ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Giới tính</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="height-36 d-flex align-center">
                        <DxRadioGroup
                          :disabled="true"
                          :value="employeeFormated?.Gender"
                          :items="[
                            { value: 0, label: this.$t('gender.male') },
                            { value: 1, label: this.$t('gender.female') },
                          ]"
                          display-expr="label"
                          value-expr="value"
                          layout="horizontal"
                        />
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Số điện thoại</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">{{ employeeFormated?.Mobile ?? "-" }}</div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Email</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">{{ employeeFormated?.Email ?? "-" }}</div>
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Mã số thuế</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">{{ employeeFormated?.TaxCode ?? "-" }}</div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Loại giấy tờ</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.IdentifyTypeName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div
                        v-tooltip="'Số Chứng minh nhân dân'"
                        class="height-36 d-flex align-center flex-wrap pr-12"
                      >
                        Số {{ employeeFormated?.IdentifyTypeName ?? "-" }}
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.IdentifyNumber ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Ngày cấp</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.IdentifyDateFormated ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Nơi cấp</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.IdentifyIssuedPlaceName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Quốc tịch</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">{{ employeeFormated?.NationalName ?? "-" }}</div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Loại hợp đồng</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.ContractMintaxTypeName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
            </MISARow>
          </div>

          <div class="form-content__subheader mt-44">Hộ khẩu thường trú</div>

          <div class="mb-24">
            <MISARow :gutter="{ x: 80 }">
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Quốc gia</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.NativeCountryName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Tỉnh/thành phố
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.NativeProvinceName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Quận/huyện</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.NativeDistrictName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Xã/phường</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.NativeWardName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Số nhà, đường/phố, thôn/xóm
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.NativeStreetHouseNumber ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Địa chỉ</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ nativeAddress ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
            </MISARow>
          </div>

          <div class="form-content__subheader mt-44">Chỗ ở hiện nay</div>

          <div class="mb-24">
            <MISARow :gutter="{ x: 80 }">
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Quốc gia</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.CurrentCountryName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Tỉnh/thành phố
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.CurrentProvinceName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Quận/huyện</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.CurrentDistrictName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Xã/phường</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.CurrentWardName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Số nhà, đường/phố, thôn/xóm
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.CurrentStreetHouseNumber ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Địa chỉ</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ currentAddress ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
            </MISARow>
          </div>

          <!-- ----- THÔNG TIN CÔNG VIỆC ----- -->
          <div ref="jobInfo" class="form-content__header mt-44">Thông tin công việc</div>

          <div class="mb-24">
            <MISARow :gutter="{ x: 80 }">
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Bộ phận/phòng ban
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.OrganizationUnitName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Vị trí công việc
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.JobPositionName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Chức danh</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">{{ employeeFormated?.JobTitleName ?? "-" }}</div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Trạng thái làm việc
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.EmployeeStatusName ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>

              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Ngày học việc</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.ProbationDateFormated ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Ngày thử việc</div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.HireDateFormated ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Ngày chính thức
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.ReceiveDateFormated ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-36 d-flex align-center flex-wrap pr-12">
                        Ngày nghỉ việc
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <div class="form-input-view">
                        {{ employeeFormated?.TerminationDateFormated ?? "-" }}
                      </div>
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
            </MISARow>
          </div>

          <!-- ----- THÔNG TIN GIA ĐÌNH ----- -->
          <div ref="familyInfo" class="d-flex align-center justify-content-between mt-44 pb-24">
            <div class="form-content__header">Thông tin gia đình</div>
            <MISAButton
              @click="$store.dispatch('employeeRelationshipStore/openFormForCreate')"
              type="outline"
              color="primary"
              >Thêm
              <template #icon>
                <MISAIcon :size="20" icon="plus" />
              </template>
            </MISAButton>
          </div>

          <!-- Form thông tin gia đình -->
          <EmployeeFamilyDetail
            @submit="getEmployeeData"
            :parentId="employeeData?.EmployeeID"
            :callApi="true"
            v-if="employeeRelationshipStore.active"
          />

          <!-- Bảng thông tin gia đình -->
          <MISATable
            v-if="employeeData?.EmployeeRelationships?.length > 0"
            @edit-row="onClickEditRow"
            @delete-row="onClickDeleteRow"
            :columns="tableColumns"
            :dataSource="employeeData?.EmployeeRelationships"
            :allowSelection="false"
            :actions="['edit', 'delete']"
            tableStyle="solid"
          >
            <template #IsDependent="{ value }">
              <div v-if="value" class="width-100 d-flex justify-content-center text-blue">
                <MISAIcon icon="check" />
              </div>
              <div v-else></div>
            </template>
          </MISATable>

          <div v-if="employeeData?.EmployeeRelationships?.length == 0" class="ms-empty-data">
            Chưa có thông tin gia đình
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import MISATable from "@/components/base/table/MISATable.vue";
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISARow from "@/components/base/grid/MISARow.vue";
import MISACol from "@/components/base/grid/MISACol.vue";
import DxRadioGroup from "devextreme-vue/radio-group";
import EmployeeFamilyDetail from "./EmployeeFamilyDetail.vue";
import employeeApi from "@/api/employee-api";
import employeeRelationshipApi from "@/api/employee-relationship-api";
import { formatDate } from "devextreme/localization";
import { employeeRelationshipColumns } from "./employee-columns";
import { mapState, mapGetters } from "vuex";
import { getCountry, getProvince, getDistrict, getWard } from "@/api/mock-data";

export default {
  name: "EmployeeDetailView",
  components: {
    MISATable,
    MISAButton,
    MISAIcon,
    MISARow,
    MISACol,
    DxRadioGroup,
    EmployeeFamilyDetail,
  },

  data: function () {
    return {
      employeeData: null,

      activeFormSidebarItem: "main-info",

      formSidebarItems: [
        { key: "main-info", title: "Thông tin chung" },
        { key: "job-info", title: "Thông tin công việc" },
        { key: "family-info", title: "Thông tin gia đình" },
      ],

      // Các cột của bảng thành viên gia đình
      tableColumns: employeeRelationshipColumns.map((col) => ({ ...col })),
    };
  },

  computed: {
    ...mapState("employeeRelationshipStore", {
      employeeRelationshipStore: (state) => state,
    }),

    ...mapGetters("employeeRelationshipStore", ["displayRelationships"]),

    /**
     * Description: Định dạng dữ liệu hiển thị
     * Author: txphuc (29/08/2023)
     */
    employeeFormated() {
      const data = { ...this.employeeData };

      // Ngày sinh
      data.DateOfBirthFormated =
        data.DateOfBirth && formatDate(new Date(data.DateOfBirth), "dd/MM/yyyy");

      // Ngày cấp
      data.IdentifyDateFormated =
        data.IdentifyDate && formatDate(new Date(data.IdentifyDate), "dd/MM/yyyy");

      // Ngày học việc
      data.ProbationDateFormated =
        data.ProbationDate && formatDate(new Date(data.ProbationDate), "dd/MM/yyyy");

      // Ngày thử việc
      data.HireDateFormated = data.HireDate && formatDate(new Date(data.HireDate), "dd/MM/yyyy");

      // Ngày chính thức
      data.ReceiveDateFormated =
        data.ReceiveDate && formatDate(new Date(data.ReceiveDate), "dd/MM/yyyy");

      // Ngảy nghỉ việc
      data.TerminationDateFormated =
        data.TerminationDate && formatDate(new Date(data.TerminationDate), "dd/MM/yyyy");

      return data;
    },

    /**
     * Description: Lấy địa chỉ đầy đủ của hộ khẩu thường trú
     * Author: txphuc (02/09/2023)
     */
    nativeAddress() {
      let addressArr = [
        this.employeeData?.NativeStreetHouseNumber,
        getWard(this.employeeData?.NativeWardCode)?.label,
        getDistrict(this.employeeData?.NativeDistrictCode)?.label,
        getProvince(this.employeeData?.NativeProvinceCode)?.label,
        getCountry(this.employeeData?.NativeCountryCode)?.label,
      ];

      // Bỏ qua giá trị rỗng
      addressArr = addressArr.filter((item) => item != null && item != undefined);

      return addressArr.join(", ");
    },

    /**
     * Description: Lấy địa chỉ đầy đủ của chỗ ở hiện nay
     * Author: txphuc (02/09/2023)
     */
    currentAddress() {
      let addressArr = [
        this.employeeData?.CurrentStreetHouseNumber,
        getWard(this.employeeData?.CurrentWardCode)?.label,
        getDistrict(this.employeeData?.CurrentDistrictCode)?.label,
        getProvince(this.employeeData?.CurrentProvinceCode)?.label,
        getCountry(this.employeeData?.CurrentCountryCode)?.label,
      ];

      // Bỏ qua giá trị rỗng
      addressArr = addressArr.filter((item) => item != null && item != undefined);

      return addressArr.join(", ");
    },
  },

  methods: {
    /**
     * Description: Cuộn phẩn tử tương ứng khi click vào form sidebar
     * Author: txphuc (23/08/2023)
     */
    onClickSidebar(key) {
      this.activeFormSidebarItem = key;

      switch (key) {
        case "main-info":
          this.scrollToView(this.$refs["mainInfo"]);
          break;
        case "job-info":
          this.scrollToView(this.$refs["jobInfo"]);
          break;
        case "family-info":
          this.scrollToView(this.$refs["familyInfo"]);
          break;
      }
    },

    /**
     * Description: Cuộn phần tử lên khung nhìn
     * Author: txphuc (23/08/2023)
     */
    scrollToView(element) {
      if (element) {
        element.scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
      }
    },

    /**
     * Description: Hiện dialog xác nhận xoá
     * Author: txphuc (24/08/2023).
     */
    showDeleteConfirmDialog() {
      this.$store.dispatch("dialogStore/showDeleteWarning", {
        title: "Xoá người nộp thuế",
        description: `Bạn có chắc chắn muốn xóa người nộp thuế <b>${this.employeeData?.FullName}</b> vào Thùng rác?`,
        okHandler: this.deleteActiveEmployee,
      });
    },

    /**
     * Description: Ẩn dialog xác nhận xoá
     * Author: txphuc (27/08/2023).
     */
    hideConfirmDialog() {
      this.$store.dispatch("dialogStore/closeDialog");
    },

    /**
     * Description: Hàm xoá một nhân viên đang active
     * Author: txphuc (27/08/2023)
     */
    async deleteActiveEmployee() {
      try {
        if (this.employeeData) {
          // Loading
          this.$store.dispatch("commonStore/setLoading", true);

          await employeeApi.delete(this.employeeData?.EmployeeID);

          // Ẩn dialog xác nhận xoá
          this.hideConfirmDialog();

          // Hiện toast message xoá thành công
          this.$store.dispatch("toastStore/pushSuccessMessage", {
            message: "Xoá người nộp thuế thành công",
          });

          // Tắt loading
          this.$store.dispatch("commonStore/setLoading", false);

          // Quay về trang danh sách
          this.$router.push({ name: "employee" });
        }
      } catch (error) {
        console.warn(error);

        // Ẩn dialog xác nhận xoá
        this.hideConfirmDialog();
      }
    },

    /**
     * Description: Mở form sửa bản ghi
     * Author: txphuc (24/08/2023)
     */
    onClickEditButton() {
      this.$router.push({
        name: "employee-detail-update",
        params: { id: this.employeeData?.EmployeeID },
      });
    },

    /**
     * Description: Load dữ liệu nhân viên
     * Author: txphuc (23/08/2023)
     */
    async getEmployeeData() {
      // Loading
      this.$store.dispatch("commonStore/setLoading", true);

      const employeeId = this.$route.params.id;

      var response = await employeeApi.get(employeeId);

      this.employeeData = response.data;

      // Tắt loading
      this.$store.dispatch("commonStore/setLoading", false);
    },

    // -------------- Thành viên gia đình --------------

    /**
     * Description: Mở form sửa thành viên gia đình
     * Author: txphuc (24/08/2023)
     */
    onClickEditRow(row) {
      this.$store.dispatch("employeeRelationshipStore/openFormForUpdate", row.data);
    },

    /**
     * Description: Lưu bản ghi để xác nhận xoá
     * Author: txphuc (24/08/2023)
     */
    onClickDeleteRow(row) {
      this.activeRowState = row.data;
      this.showDeleteRelationshipConfirmDialog(
        `Bạn có chắc chắn xóa thông tin gia đình này khỏi danh sách không?`
      );
    },

    /**
     * Description: Hiện dialog xác nhận xoá
     * Author: txphuc (24/06/2023).
     */
    showDeleteRelationshipConfirmDialog(description) {
      this.$store.dispatch("dialogStore/showDeleteWarning", {
        title: "Xoá dữ liệu",
        description,
        okHandler: this.deleteActiveRelationship,
      });
    },

    /**
     * Description: Ẩn dialog xác nhận
     * Author: txphuc (27/06/2023).
     */
    hideRelationshipConfirmDialog() {
      this.$store.dispatch("dialogStore/closeDialog");
      this.activeRowState = null;
    },

    /**
     * Description: Hàm xoá một thành viên gia đình đang active
     * Author: txphuc (11/07/2023)
     */
    async deleteActiveRelationship() {
      try {
        const key = this.activeRowState.EmployeeRelationshipID;

        await employeeRelationshipApi.delete(key);

        // Ẩn dialog xác nhận xoá
        this.hideRelationshipConfirmDialog();

        // Load lại dữ liệu
        await this.getEmployeeData();

        // Hiện toast message xoá thành công
        this.$store.dispatch("toastStore/pushSuccessMessage", {
          message: "Xoá thông tin gia đình thành công",
        });
      } catch (error) {
        console.warn(error);

        // Ẩn dialog xác nhận xoá
        this.hideRelationshipConfirmDialog();
      }
    },
  },

  /**
   * Description: Load dữ liệu khi mở
   * Author: txphuc (23/08/2023)
   */
  created: function () {
    this.getEmployeeData();

    // Xoá dữ liệu cũ khi mở form
    this.$store.dispatch("employeeRelationshipStore/setRelationships", []);
  },
};
</script>

<style lang="scss" scoped></style>
