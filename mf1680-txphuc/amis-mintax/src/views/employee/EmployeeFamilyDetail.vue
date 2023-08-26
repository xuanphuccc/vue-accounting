<template>
  <MISAPopup
    @submit="handleSubmitForm()"
    @close="onCloseForm"
    title="Thêm thành viên gia đình"
    :width="1146"
  >
    <div class="mb-24">
      <MISARow :gutter="{ x: 80 }">
        <MISACol :span="6">
          <div class="">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">
                  Họ tên thành viên <span class="required-mark">*</span>
                </div>
              </MISACol>
              <MISACol :span="8">
                <MISATextBox v-model="formData.FullName" placeholder="Nhập họ tên thành viên" />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">
                  Quan hệ <span class="required-mark">*</span>
                </div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.Relationship"
                  :dataSource="relationships"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập quan hệ"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Ngày sinh</div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker v-model="formData.DateOfBirth" />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Giới tính</div>
              </MISACol>
              <MISACol :span="8">
                <div class="height-36 d-flex align-center">
                  <DxRadioGroup
                    v-model="formData.Gender"
                    :items="[
                      { value: 0, label: 'Nam' },
                      { value: 1, label: 'Nữ' },
                    ]"
                    value-expr="value"
                    display-expr="label"
                    layout="horizontal"
                  />
                </div>
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Mã số thuế</div>
              </MISACol>
              <MISACol :span="8">
                <MISARow>
                  <div class="d-flex width-100 col-gap-8">
                    <MISATextBox
                      v-model="formData.TaxCode"
                      placeholder="Nhập mã số thuế"
                      width="100%"
                    />

                    <MISAButton color="secondary"
                      >Lấy thông tin
                      <template #icon>
                        <MISAIcon :size="20" icon="get-info" />
                      </template>
                    </MISAButton>
                  </div>
                </MISARow>
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
        <MISACol :span="6">
          <div class="">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Quốc tịch</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.NationalityCode"
                  :dataSource="countries"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập quốc tịch"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Loại giấy tờ</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.IdentifyKindOfPaper"
                  :dataSource="identifyTypes"
                  displayExpr="label"
                  valueExpr="value"
                  placeholder="Chọn loại giấy tờ"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Số CMND</div>
              </MISACol>
              <MISACol :span="8">
                <MISARow>
                  <div class="d-flex width-100 col-gap-8">
                    <MISATextBox
                      v-model="formData.IdentifyPaperNumber"
                      placeholder="Nhập số CMND/CCCD/Hộ chiếu"
                      width="100%"
                    />

                    <MISAButton color="secondary"
                      >Lấy thông tin
                      <template #icon>
                        <MISAIcon :size="20" icon="get-info" />
                      </template>
                    </MISAButton>
                  </div>
                </MISARow>
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Ngày cấp</div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker v-model="formData.IdentifyNumberIssuedDate" />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Nơi cấp</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.IdentifyNumberIssuedPlaceCode"
                  :dataSource="provinces"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập nơi cấp"
                />
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
      </MISARow>
    </div>

    <!-- ----- THÔNG TIN KHAI SINH ----- -->
    <div class="form-content__header">Thông tin khai sinh</div>
    <div class="mb-24">
      <MISARow :gutter="{ x: 80 }">
        <MISACol :span="6">
          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Số khai sinh</div>
              </MISACol>
              <MISACol :span="8">
                <MISATextBox v-model="formData.DependentNumber" placeholder="Nhập số khai sinh" />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Quyển số</div>
              </MISACol>
              <MISACol :span="8">
                <MISATextBox v-model="formData.NumberBook" placeholder="Nhập quyển số" />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">
                  Ngày cấp giấy khai sinh
                </div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker v-model="formData.BirthCertificationIssueDate" />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Quốc gia</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.CountryCode"
                  :dataSource="countries"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập quốc gia"
                />
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
        <MISACol :span="6">
          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Tỉnh/thành phố</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.ProvinceCode"
                  :dataSource="provinces"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập tỉnh/thành phố"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Quận/huyện</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.DistrictCode"
                  :dataSource="districts"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập quận/huyện"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Xã/phường</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.WardCode"
                  :dataSource="wards"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập xã/phường"
                />
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
      </MISARow>
    </div>

    <!-- ----- HỘ KHẨU THƯỜNG TRÚ ----- -->
    <div class="form-content__header">Hộ khẩu thường trú</div>
    <div class="mb-24">
      <MISARow :gutter="{ x: 80 }">
        <MISACol :span="6">
          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Tỉnh/thành phố</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.FamilyPermanentAddressProvinceCode"
                  :dataSource="provinces"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập tỉnh/thành phố"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Quận/huyện</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.FamilyPermanentAddressDistrictCode"
                  :dataSource="districts"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập quận/huyện"
                />
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
        <MISACol :span="6">
          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Xã/phường</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.FamilyPermanentAddressWardCode"
                  :dataSource="wards"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập xã/phường"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">
                  Số nhà, đường/phố, thôn/xóm
                </div>
              </MISACol>
              <MISACol :span="8">
                <MISATextBox
                  v-model="formData.FamilyPermanentAddressStreetHouseNumber"
                  placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                />
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
      </MISARow>
    </div>

    <!-- ----- CHỖ Ở HIỆN NAY ----- -->
    <div class="form-content__header">Chỗ ở hiện nay</div>
    <div class="mb-24">
      <MISARow :gutter="{ x: 80 }">
        <MISACol :span="6">
          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Tỉnh/thành phố</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.FamilyCurrentProvinceCode"
                  :dataSource="provinces"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập tỉnh/thành phố"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Quận/huyện</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.FamilyCurrentDistrictCode"
                  :dataSource="districts"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập quận/huyện"
                />
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
        <MISACol :span="6">
          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Xã/phường</div>
              </MISACol>
              <MISACol :span="8">
                <MISASelectBox
                  v-model="formData.FamilyCurrentWardCode"
                  :dataSource="wards"
                  displayExpr="label"
                  valueExpr="value"
                  :searchEnabled="true"
                  placeholder="Chọn/nhập xã/phường"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">
                  Số nhà, đường/phố, thôn/xóm
                </div>
              </MISACol>
              <MISACol :span="8">
                <MISATextBox
                  v-model="formData.FamilyCurrentStreetHouseNumber"
                  placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                />
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
      </MISARow>
    </div>

    <!-- ----- THÔNG TIN GIẢM TRỪ ----- -->
    <div class="form-content__header">Thông tin giảm trừ</div>
    <div class="mb-24">
      <MISARow :gutter="{ x: 80 }">
        <MISACol :span="6">
          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Là người phụ thuộc</div>
              </MISACol>
              <MISACol :span="8">
                <div class="d-flex">
                  <DxCheckBox v-model="formData.IsDependent" />
                  <div class="height-36"></div>
                </div>
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Giảm trừ từ tháng</div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker
                  v-model="formData.DeductionStartDate"
                  displayFormat="MM/yyyy"
                  placeholder="__/ ____"
                />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Giảm trừ đến tháng</div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker
                  v-model="formData.DeductionEndDate"
                  displayFormat="MM/yyyy"
                  placeholder="__/ ____"
                />
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
        <MISACol :span="6">
          <div class="mt-16">
            <MISARow>
              <div class="height-36"></div>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Ghi chú</div>
              </MISACol>
              <MISACol :span="8">
                <DxTextArea v-model="formData.Description" :min-height="72"></DxTextArea>
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
      </MISARow>
    </div>

    <template #controls-right>
      <MISAButton @click="onCloseForm" color="secondary">Huỷ</MISAButton>
      <MISAButton @click="handleSubmitForm()">Đồng ý</MISAButton>
    </template>
  </MISAPopup>
</template>

<script>
import MISAPopup from "@/components/base/popup/MISAPopup.vue";
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISATextBox from "@/components/base/text-box/MISATextBox.vue";
import { DxTextArea } from "devextreme-vue/text-area";
import MISASelectBox from "@/components/base/select-box/MISASelectBox.vue";
import MISADatePicker from "@/components/base/date-picker/MISADatePicker.vue";
import MISARow from "@/components/base/grid/MISARow.vue";
import MISACol from "@/components/base/grid/MISACol.vue";
import DxCheckBox from "devextreme-vue/check-box";
import DxRadioGroup from "devextreme-vue/radio-group";
// import { ValidationProvider } from "vee-validate";
import enums from "@/enum/enum";
import { mapState } from "vuex";
import {
  relationships,
  countries,
  provinces,
  districts,
  wards,
  identifyTypes,
} from "@/api/mock-data";
import { formatDate } from "devextreme/localization";

const defaultFormData = {
  FullName: null,
  Relationship: null,
  DateOfBirth: null,
  Gender: 0,
  TaxCode: null,
  NationalityCode: "VN",
  IdentifyKindOfPaper: 0,
  IdentifyPaperNumber: null,
  IdentifyNumberIssuedDate: null,
  IdentifyNumberIssuedPlaceCode: null,
  DependentNumber: null,
  NumberBook: null,
  BirthCertificationIssueDate: null,
  CountryCode: "VN",
  ProvinceCode: null,
  DistrictCode: null,
  WardCode: null,
  FamilyPermanentAddressProvinceCode: null,
  FamilyPermanentAddressDistrictCode: null,
  FamilyPermanentAddressWardCode: null,
  FamilyPermanentAddressStreetHouseNumber: null,
  FamilyCurrentProvinceCode: null,
  FamilyCurrentDistrictCode: null,
  FamilyCurrentWardCode: null,
  FamilyCurrentStreetHouseNumber: null,
  IsDependent: false,
  DeductionStartDate: null,
  DeductionEndDate: null,
  Description: null,
};

export default {
  name: "EmployeeFamilyDetail",
  components: {
    MISAPopup,
    MISAButton,
    MISATextBox,
    DxTextArea,
    MISAIcon,
    MISADatePicker,
    MISASelectBox,
    MISARow,
    MISACol,
    DxCheckBox,
    DxRadioGroup,
    // ValidationProvider,
  },
  props: {},
  data: function () {
    return {
      relationships,
      countries,
      provinces,
      districts,
      wards,
      identifyTypes,

      // Dữ liệu của form
      formData: {
        ...defaultFormData,
      },

      // Trạng thái sửa đổi form
      formModified: false,
      isLoadFormData: false,
    };
  },

  computed: {
    ...mapState("employeeRelationshipStore", {
      employeeRelationshipStore: (state) => state,
    }),
  },

  watch: {
    /**
     * Description: Phát hiện sự thay đổi của form
     * Author: txphuc (25/08/2023)
     */
    formData: {
      handler: function () {
        if (this.isLoadFormData) {
          // Nếu form thay đổi do load dữ liệu (mã mới, data update)
          // thì reset lại trạng thái thành chưa thay đổi
          this.formModified = false;

          this.isLoadFormData = false;
        } else {
          this.formModified = true;
        }
      },
      deep: true,
    },
  },

  methods: {
    /**
     * Description: Xử lý sự kiện thoát form
     * Author: txphuc (25/08/2023)
     */
    onCloseForm() {
      if (this.formModified) {
        this.$store.dispatch("dialogStore/showExistFormWarning", {
          cancel: this.confirmExitForm,
          submit: this.confirmSubmitForm,
        });
      } else {
        this.$store.dispatch("employeeRelationshipStore/closeForm");
      }
    },

    /**
     * Description: Xác nhận thoát form khi dialog cảnh báo thay đổi
     * được bật lên
     * Author: txphuc (25/08/2023)
     */
    confirmExitForm() {
      // Đóng dialog cảnh báo
      this.$store.dispatch("dialogStore/closeDialog");

      // Thoát form
      this.$store.dispatch("employeeRelationshipStore/closeForm");
    },

    /**
     * Description: Xác nhận submit form và đóng dialog
     * khi dialog cảnh báo thay đổi được bật lên
     * Author: txphuc (25/08/2023)
     */
    async confirmSubmitForm() {
      // Đóng dialog cảnh báo
      this.$store.dispatch("dialogStore/closeDialog");

      // Submit form
      await this.handleSubmitForm();
    },

    /**
     * Description: Hàm xử lý submit form ở các chế độ create/update
     * Author: txphuc (26/08/2023)
     */
    async handleSubmitForm() {
      try {
        let result = false;

        // const success = await this.$refs.formValidation.validate();
        const success = true;

        if (success) {
          if (this.employeeRelationshipStore.mode === enums.form.mode.CREATE) {
            result = this.handleCreateRelationship();
          } else if (this.employeeRelationshipStore.mode === enums.form.mode.UPDATE) {
            result = this.handleUpdateRelationship();
          }

          if (result) {
            this.$store.dispatch("employeeRelationshipStore/closeForm");
          }
        }
      } catch (error) {
        console.warn(error);
      }
    },

    /**
     * Description: Xử lý format data trước khi gửi
     * Author: txphuc (26/08/2023)
     */
    generateData() {
      const data = {
        ...this.formData,

        DateOfBirth: formatDate(this.formData.DateOfBirth, "yyyy-MM-dd"),

        IdentifyNumberIssuedDate: formatDate(this.formData.IdentifyNumberIssuedDate, "yyyy-MM-dd"),

        BirthCertificationIssueDate: formatDate(
          this.formData.BirthCertificationIssueDate,
          "yyyy-MM-dd"
        ),

        DeductionStartDate: formatDate(this.formData.DeductionStartDate, "yyyy-MM-dd"),
        DeductionEndDate: formatDate(this.formData.DeductionEndDate, "yyyy-MM-dd"),
      };

      return data;
    },

    /**
     * Description: Hàm xử lý thêm thành viên gia đình
     * Author: txphuc (26/08/2023)
     */
    handleCreateRelationship() {
      try {
        if (this.employeeRelationshipStore.mode === enums.form.mode.CREATE) {
          const data = this.generateData();

          this.$store.dispatch("employeeRelationshipStore/addRelationship", data);

          return true;
        }
      } catch (error) {
        console.warn(error);

        return false;
      }
    },

    /**
     * Description: Hàm load dữ liệu để thực hiện update
     * Author: txphuc (27/08/2023)
     */
    handleLoadDataForUpdate() {
      try {
        if (this.employeeRelationshipStore.mode === enums.form.mode.UPDATE) {
          const employeeData = this.employeeRelationshipStore?.currentRelationship;

          console.log(employeeData);

          // Binding dữ liệu vào form
          this.formData = {
            ...employeeData,

            DateOfBirth: employeeData.DateOfBirth && new Date(employeeData.DateOfBirth),

            IdentifyNumberIssuedDate:
              employeeData.IdentifyNumberIssuedDate &&
              new Date(employeeData.IdentifyNumberIssuedDate),

            BirthCertificationIssueDate:
              employeeData.BirthCertificationIssueDate &&
              new Date(employeeData.BirthCertificationIssueDate),

            DeductionStartDate:
              employeeData.DeductionStartDate && new Date(employeeData.DeductionStartDate),

            DeductionEndDate:
              employeeData.DeductionEndDate && new Date(employeeData.DeductionEndDate),
          };

          // Tránh thay đổi trạng thái của form
          this.isLoadFormData = true;
        }
      } catch (error) {
        console.warn(error);
      }
    },

    /**
     * Description: Hàm xử cập nhật thành viên gia đình
     * Author: txphuc (26/08/2023)
     */
    handleUpdateRelationship() {
      try {
        if (this.employeeRelationshipStore.mode === enums.form.mode.UPDATE) {
          const data = this.generateData();

          this.$store.dispatch("employeeRelationshipStore/updateRelationship", data);

          return true;
        }
      } catch (error) {
        console.warn(error);

        return false;
      }
    },
  },

  /**
   * Description: Load dữ liệu khi form được tạo
   * Author: txphuc (27/08/2023)
   */
  created: function () {
    this.handleLoadDataForUpdate();
  },
};
</script>

<style></style>
