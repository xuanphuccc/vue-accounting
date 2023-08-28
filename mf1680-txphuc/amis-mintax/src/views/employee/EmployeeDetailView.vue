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
            <MISAButton type="outline" color="primary"
              >Thêm
              <template #icon>
                <MISAIcon :size="20" icon="plus" />
              </template>
            </MISAButton>
          </div>

          <!-- Form thông tin gia đình -->
          <EmployeeFamilyDetail v-if="employeeRelationshipStore.active" />

          <!-- Bảng thông tin gia đình -->
          <MISATable
            v-if="employeeData?.EmployeeRelationships?.length > 0"
            @edit-row="onClickEditRow"
            @delete-row="onClickDeleteRow"
            :columns="tableColumns"
            :dataSource="employeeData?.EmployeeRelationships"
            :allowSelection="false"
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
import { employeeRelationshipColumns } from "./employee-columns";
import { mapState, mapGetters } from "vuex";

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

    employeeFormated() {
      const data = { ...this.employeeData };

      // Loại đối tượng
      data.EmployeeTypeName =
        data.EmployeeType == enums.employeeType.employee
          ? this.$t("page.employee.employeeType.employee")
          : this.$t("page.employee.employeeType.client");

      // Ngày sinh
      data.DateOfBirthFormated =
        data.DateOfBirth && formatDate(new Date(data.DateOfBirth), "dd/MM/yyyy");

      // Loại giấy tờ
      data.IdentifyTypeName =
        data.IdentifyType == enums.identifyType.nationalIdentityCard
          ? this.$t("identifyType.nationalIdentityCard")
          : enums.identifyType.citizenCard
          ? this.$t("identifyType.citizenCard")
          : this.$t("identifyType.passport");

      // Ngày cấp
      data.IdentifyDateFormated =
        data.IdentifyDate && formatDate(new Date(data.IdentifyDate), "dd/MM/yyyy");

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
        handler: this.deleteActiveEmployee,
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

          await employeeApi.deleteById(this.employeeData.EmployeeID);

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
      console.log(row);
      // this.$store.dispatch("employeeRelationshipStore/openFormForUpdate", row.data);
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
        handler: this.deleteActiveRelationship,
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
        this.$store.dispatch("employeeRelationshipStore/removeRelationship", key);

        // Ẩn dialog xác nhận xoá
        this.hideRelationshipConfirmDialog();
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
  },
};
</script>

<style lang="scss" scoped></style>
