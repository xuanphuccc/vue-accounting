<template>
  <MISAPopup
    @submit="$emit('submit')"
    @close="$store.dispatch('employeeRelationshipStore/closeForm')"
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
                <MISATextBox placeholder="Nhập họ tên thành viên" />
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
                <MISADatePicker />
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
                    :items="[
                      { id: 0, text: 'Nam' },
                      { id: 1, text: 'Nữ' },
                    ]"
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
                    <MISATextBox placeholder="Nhập mã số thuế" width="100%" />

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
                    <MISATextBox placeholder="Nhập số CMND/CCCD/Hộ chiếu" width="100%" />

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
                <MISADatePicker />
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
                <MISATextBox placeholder="Nhập số khai sinh" />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Quyển số</div>
              </MISACol>
              <MISACol :span="8">
                <MISATextBox placeholder="Nhập quyển số" />
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
                <MISADatePicker />
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
                <MISATextBox placeholder="Nhập số nhà, đường/phố, thôn/xóm" />
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
                <MISATextBox placeholder="Nhập số nhà, đường/phố, thôn/xóm" />
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
                  <DxCheckBox />
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
                <MISADatePicker displayFormat="MM/yyyy" placeholder="__/ ____" />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center flex-wrap pr-12">Giảm trừ đến tháng</div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker displayFormat="MM/yyyy" placeholder="__/ ____" />
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
                <DxTextArea :min-height="72"></DxTextArea>
              </MISACol>
            </MISARow>
          </div>
        </MISACol>
      </MISARow>
    </div>

    <template #controls-right>
      <MISAButton @click="$store.dispatch('employeeRelationshipStore/closeForm')" color="secondary"
        >Huỷ</MISAButton
      >
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

const defaultFormData = {
  FullName: "string",
  Relationship: 0,
  DateOfBirth: null,
  Gender: 0,
  TaxCode: null,
  NationalityCode: null,
  IdentifyKindOfPaper: null,
  IdentifyPaperNumber: null,
  IdentifyNumberIssuedDate: null,
  IdentifyNumberIssuedPlaceCode: null,
  DependentNumber: null,
  NumberBook: null,
  BirthCertificationIssueDate: null,
  CountryCode: null,
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
  IsDependent: true,
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
      // Dữ liệu của form
      formData: {
        ...defaultFormData,
      },
    };
  },

  computed: {
    ...mapState("employeeRelationshipStore", {
      employeeRelationshipStore: (state) => state,
    }),
  },

  methods: {
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
            result = this.handleUpdateEmployee();
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
      };

      return data;
    },

    /**
     * Description: Hàm xử lý gọi api thêm thành viên gia đình
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
  },
};
</script>

<style></style>
