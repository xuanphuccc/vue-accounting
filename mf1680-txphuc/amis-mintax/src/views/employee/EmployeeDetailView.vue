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
          Thông tin người nộp thuế
        </h1>
      </div>

      <div class="page__header-controls">
        <MISAButton color="light-danger">
          <template #icon>
            <MISAIcon size="20" icon="trash" />
          </template>
          Xoá
        </MISAButton>

        <MISAButton color="primary">
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
                      <div class="height-36 d-flex align-center flex-wrap pr-12">Số CMND</div>
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
                        {{ employeeFormated?.NativeAddress ?? "-" }}
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
                        {{ employeeFormated?.CurrentAddress ?? "-" }}
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
            <MISAButton @click="isOpenEmployeeFamilyDetail = true" type="outline" color="primary"
              >Thêm
              <template #icon>
                <MISAIcon :size="20" icon="plus" />
              </template>
            </MISAButton>
          </div>

          <EmployeeFamilyDetail
            v-if="isOpenEmployeeFamilyDetail"
            @close="isOpenEmployeeFamilyDetail = false"
          />

          <div class="ms-empty-data">Chưa có thông tin gia đình</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISARow from "@/components/base/grid/MISARow.vue";
import MISACol from "@/components/base/grid/MISACol.vue";
import DxRadioGroup from "devextreme-vue/radio-group";
import EmployeeFamilyDetail from "./EmployeeFamilyDetail.vue";
import employeeApi from "@/api/employee-api";
import enums from "@/enum/enum";
import { formatDate } from "devextreme/localization";
import {
  getCountry,
  getDepartment,
  getDistrict,
  getPosition,
  getProvince,
  getWard,
} from "@/api/mock-data";

export default {
  name: "EmployeeDetailView",
  components: {
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
      isOpenEmployeeFamilyDetail: false,
    };
  },
  computed: {
    employeeFormated() {
      const data = { ...this.employeeData };

      // Loại đối tượng
      data.EmployeeTypeName =
        data.EmployeeType == enums.employeeType.employee
          ? this.$t("page.employee.employeeType.employee")
          : this.$t("page.employee.employeeType.client");

      // Ngày sinh
      data.DateOfBirthFormated = formatDate(new Date(data.DateOfBirth), "dd/MM/yyyy");

      // Loại giấy tờ
      data.IdentifyTypeName =
        data.IdentifyType == enums.identifyType.nationalIdentityCard
          ? this.$t("identifyType.nationalIdentityCard")
          : enums.identifyType.citizenCard
          ? this.$t("identifyType.citizenCard")
          : this.$t("identifyType.passport");

      // Ngày cấp
      data.IdentifyDateFormated = formatDate(new Date(data.IdentifyDate), "dd/MM/yyyy");

      // Nơi cấp
      data.IdentifyIssuedPlaceName = getProvince(data.IdentifyIssuedPlaceCode)?.label;

      // Quốc tịch
      data.NationalName = getCountry(data.NationalCode)?.label;

      // Loại hợp đồng
      data.ContractMintaxTypeName =
        data.ContractMintaxType == enums.contractType.nonResident
          ? this.$t("contractType.nonResident")
          : data.ContractMintaxType == enums.contractType.residenceWithContract
          ? this.$t("contractType.residenceWithContract")
          : this.$t("contractType.residenceWithoutContract");

      // HỘ KHẨU THƯỜNG TRÚ
      // Quóc gia
      data.NativeCountryName = getCountry(data.NativeCountryCode)?.label;

      // Tỉnh thành phố
      data.NativeProvinceName = getProvince(data.NativeProvinceCode)?.label;

      // Quận/huyện
      data.NativeDistrictName = getDistrict(data.NativeDistrictCode)?.label;

      // Xã/phường
      data.NativeWardName = getWard(data.NativeWardCode)?.label;

      // CHỖ Ở HIỆN NAY
      // Quóc gia
      data.CurrentCountryName = getCountry(data.CurrentCountryCode)?.label;

      // Tỉnh thành phố
      data.CurrentProvinceName = getProvince(data.CurrentProvinceCode)?.label;

      // Quận/huyện
      data.CurrentDistrictName = getDistrict(data.CurrentDistrictCode)?.label;

      // Xã/phường
      data.CurrentWardName = getWard(data.CurrentWardCode)?.label;

      // THÔNG TIN CÔNG VIỆC
      // Bộ phận/phòng ban
      data.OrganizationUnitName = getDepartment(data.OrganizationUnitId)?.label;

      // Vị trí công việc
      data.JobPositionName = getPosition(data.JobPositionId)?.label;

      // Chức danh
      data.JobTitleName = null;

      // Trạng thái làm việc
      data.EmployeeStatusName =
        data.EmployeeStatus == enums.workStatus.currentlyEmployed
          ? this.$t("page.employee.workStatus.currentlyEmployed")
          : this.$t("page.employee.workStatus.formerlyEmployed");

      // Ngày học việc
      data.ProbationDateFormated = formatDate(new Date(data.ProbationDate), "dd/MM/yyyy");

      // Ngày thử việc
      data.HireDateFormated = formatDate(new Date(data.HireDate), "dd/MM/yyyy");

      // Ngày chính thức
      data.ReceiveDateFormated = formatDate(new Date(data.ReceiveDate), "dd/MM/yyyy");

      // Ngảy nghỉ việc
      data.TerminationDateFormated = formatDate(new Date(data.TerminationDate), "dd/MM/yyyy");

      return data;
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
  },

  /**
   * Description: Load dữ liệu khi mở
   * Author: txphuc (23/08/2023)
   */
  created: function () {
    this.getEmployeeData();
  },
};
</script>

<style lang="scss" scoped></style>
