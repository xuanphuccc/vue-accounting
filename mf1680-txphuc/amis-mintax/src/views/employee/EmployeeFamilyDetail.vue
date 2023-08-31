<template>
  <MISAPopup
    @submit="handleSubmitForm()"
    @close="onCloseForm"
    title="Thêm thành viên gia đình"
    :width="1146"
  >
    <ValidationObserver ref="formValidation">
      <div class="mb-24">
        <MISARow :gutter="{ x: 80 }">
          <MISACol :span="6">
            <div class="">
              <MISARow>
                <MISACol :span="4">
                  <label for="fullname" class="height-36 d-flex align-center flex-wrap pr-12">
                    Họ tên thành viên <span class="required-mark">*</span>
                  </label>
                </MISACol>
                <MISACol :span="8">
                  <ValidationProvider name="Họ tên thành viên" rules="required" v-slot="{ errors }">
                    <MISATextBox
                      v-model="formData.FullName"
                      :is-valid="!errors[0]"
                      auto-focus
                      placeholder="Nhập họ tên thành viên"
                      id="fullname"
                    />
                    <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                  </ValidationProvider>
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label for="relationship" class="height-36 d-flex align-center flex-wrap pr-12">
                    Quan hệ <span class="required-mark">*</span>
                  </label>
                </MISACol>
                <MISACol :span="8">
                  <ValidationProvider name="Quan hệ" rules="required" v-slot="{ errors }">
                    <MISASelectBox
                      v-model="formData.Relationship"
                      :dataSource="relationships"
                      displayExpr="label"
                      valueExpr="value"
                      :searchEnabled="true"
                      :is-valid="!errors[0]"
                      placeholder="Chọn/nhập quan hệ"
                      id="relationship"
                    />
                    <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                  </ValidationProvider>
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label for="dateofbirth" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Ngày sinh</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISADatePicker v-model="formData.DateOfBirth" id="dateofbirth" />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label for="test" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Giới tính</label
                  >
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
                  <label for="tax-code" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Mã số thuế</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISARow>
                    <div class="d-flex width-100 col-gap-8">
                      <MISATextBox
                        v-model="formData.TaxCode"
                        placeholder="Nhập mã số thuế"
                        width="100%"
                        id="tax-code"
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
                  <label
                    for="nationality-code"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Quốc tịch</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.NationalityCode"
                    :dataSource="countries"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập quốc tịch"
                    id="nationality-code"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="identify-kind-of-paper"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Loại giấy tờ</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.IdentifyKindOfPaper"
                    :dataSource="identifyTypes"
                    displayExpr="label"
                    valueExpr="value"
                    placeholder="Chọn loại giấy tờ"
                    id="identify-kind-of-paper"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="identify-paper-number"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Số CMND</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISARow>
                    <div class="d-flex width-100 col-gap-8">
                      <MISATextBox
                        v-model="formData.IdentifyPaperNumber"
                        placeholder="Nhập số CMND/CCCD/Hộ chiếu"
                        width="100%"
                        id="identify-paper-number"
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
                  <label
                    for="identify-number-issued-date"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Ngày cấp</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISADatePicker
                    v-model="formData.IdentifyNumberIssuedDate"
                    id="identify-number-issued-date"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="identify-number-issued-place-code"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Nơi cấp</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.IdentifyNumberIssuedPlaceCode"
                    :dataSource="provinces"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập nơi cấp"
                    id="identify-number-issued-place-code"
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
                  <label
                    for="dependent-number"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Số khai sinh</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISATextBox
                    v-model="formData.DependentNumber"
                    placeholder="Nhập số khai sinh"
                    id="dependent-number"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label for="number-book" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Quyển số</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISATextBox
                    v-model="formData.NumberBook"
                    placeholder="Nhập quyển số"
                    id="number-book"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="birth-certification-issue-date"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                  >
                    Ngày cấp giấy khai sinh
                  </label>
                </MISACol>
                <MISACol :span="8">
                  <MISADatePicker
                    v-model="formData.BirthCertificationIssueDate"
                    id="birth-certification-issue-date"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label for="country-code" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Quốc gia</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.CountryCode"
                    :dataSource="countries"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập quốc gia"
                    id="country-code"
                  />
                </MISACol>
              </MISARow>
            </div>
          </MISACol>
          <MISACol :span="6">
            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label for="province-code" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Tỉnh/thành phố</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.ProvinceCode"
                    :dataSource="provinces"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập tỉnh/thành phố"
                    id="province-code"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label for="district-code" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Quận/huyện</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.DistrictCode"
                    :dataSource="getDistrictsOfProvince(formData.ProvinceCode)"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập quận/huyện"
                    id="district-code"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label for="ward-code" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Xã/phường</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.WardCode"
                    :dataSource="getWardsOfDistrict(formData.DistrictCode)"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập xã/phường"
                    id="ward-code"
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
                  <label
                    for="family-permanent-address-province-code"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Tỉnh/thành phố</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.FamilyPermanentAddressProvinceCode"
                    :dataSource="provinces"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập tỉnh/thành phố"
                    id="family-permanent-address-province-code"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="family-permanent-address-district-code"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Quận/huyện</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.FamilyPermanentAddressDistrictCode"
                    :dataSource="
                      getDistrictsOfProvince(formData.FamilyPermanentAddressProvinceCode)
                    "
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập quận/huyện"
                    id="family-permanent-address-district-code"
                  />
                </MISACol>
              </MISARow>
            </div>
          </MISACol>
          <MISACol :span="6">
            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="family-permanent-address-ward-code"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Xã/phường</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.FamilyPermanentAddressWardCode"
                    :dataSource="getWardsOfDistrict(formData.FamilyPermanentAddressDistrictCode)"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập xã/phường"
                    id="family-permanent-address-ward-code"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="family-permanent-address-street"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                  >
                    Số nhà, đường/phố, thôn/xóm
                  </label>
                </MISACol>
                <MISACol :span="8">
                  <MISATextBox
                    v-model="formData.FamilyPermanentAddressStreetHouseNumber"
                    placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                    id="family-permanent-address-street"
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
                  <label
                    for="family-current-province-code"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Tỉnh/thành phố</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.FamilyCurrentProvinceCode"
                    :dataSource="provinces"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập tỉnh/thành phố"
                    id="family-current-province-code"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="family-current-district-code"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Quận/huyện</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.FamilyCurrentDistrictCode"
                    :dataSource="getDistrictsOfProvince(formData.FamilyCurrentProvinceCode)"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập quận/huyện"
                    id="family-current-district-code"
                  />
                </MISACol>
              </MISARow>
            </div>
          </MISACol>
          <MISACol :span="6">
            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="family-current-ward-code"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Xã/phường</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISASelectBox
                    v-model="formData.FamilyCurrentWardCode"
                    :dataSource="getWardsOfDistrict(formData.FamilyCurrentDistrictCode)"
                    displayExpr="label"
                    valueExpr="value"
                    :searchEnabled="true"
                    placeholder="Chọn/nhập xã/phường"
                    id="family-current-ward-code"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="family-current-street"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                  >
                    Số nhà, đường/phố, thôn/xóm
                  </label>
                </MISACol>
                <MISACol :span="8">
                  <MISATextBox
                    v-model="formData.FamilyCurrentStreetHouseNumber"
                    placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                    id="family-current-street"
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
                  <label for="isdependent" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Là người phụ thuộc</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <div class="d-flex">
                    <DxCheckBox
                      v-model="formData.IsDependent"
                      :element-attr="{ id: 'isdependent' }"
                    />
                    <div class="height-36"></div>
                  </div>
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="deduction-start-date"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Giảm trừ từ tháng</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISADatePicker
                    v-model="formData.DeductionStartDate"
                    displayFormat="MM/yyyy"
                    placeholder="__/ ____"
                    zoomLevel="year"
                    id="deduction-start-date"
                  />
                </MISACol>
              </MISARow>
            </div>

            <div class="mt-16">
              <MISARow>
                <MISACol :span="4">
                  <label
                    for="deduction-end-date"
                    class="height-36 d-flex align-center flex-wrap pr-12"
                    >Giảm trừ đến tháng</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <MISADatePicker
                    v-model="formData.DeductionEndDate"
                    displayFormat="MM/yyyy"
                    placeholder="__/ ____"
                    zoomLevel="year"
                    id="deduction-end-date"
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
                  <label for="description" class="height-36 d-flex align-center flex-wrap pr-12"
                    >Ghi chú</label
                  >
                </MISACol>
                <MISACol :span="8">
                  <DxTextArea
                    v-model="formData.Description"
                    :min-height="72"
                    :input-attr="{ id: 'description' }"
                  ></DxTextArea>
                </MISACol>
              </MISARow>
            </div>
          </MISACol>
        </MISARow>
      </div>
    </ValidationObserver>

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
import { ValidationProvider, ValidationObserver } from "vee-validate";
import enums from "@/enum/enum";
import { mapState } from "vuex";
import {
  relationships,
  countries,
  provinces,
  identifyTypes,
  getRelationship,
  getGender,
  getIdentifyType,
  getCountry,
  getProvince,
  getDistrict,
  getDistrictsOfProvince,
  getWard,
  getWardsOfDistrict,
} from "@/api/mock-data";
import { formatDate } from "devextreme/localization";
import employeeRelationshipApi from "@/api/employee-relationship-api";

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
    ValidationProvider,
    ValidationObserver,
  },
  props: {
    // Xác định form có gọi api để lưu luôn hay không
    callApi: {
      type: Boolean,
      default: false,
    },

    // Id của employee
    parentId: {
      type: String,
    },
  },
  data: function () {
    return {
      relationships,
      countries,
      provinces,
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

    /**
     * Description: Reset quận/huyện và xã/phường khi tỉnh/TP thay đổi
     * Author: txphuc (31/08/2023)
     */
    "formData.ProvinceCode": function () {
      this.formData.DistrictCode = null;
      this.formData.WardCode = null;
    },
    "formData.FamilyPermanentAddressProvinceCode": function () {
      this.formData.FamilyPermanentAddressDistrictCode = null;
      this.formData.FamilyPermanentAddressWardCode = null;
    },
    "formData.FamilyCurrentProvinceCode": function () {
      this.formData.FamilyCurrentDistrictCode = null;
      this.formData.FamilyCurrentWardCode = null;
    },

    /**
     * Description: Reset xã/phường khi quận/huyện thay đổi
     * Author: txphuc (31/08/2023)
     */
    "formData.DistrictCode": function () {
      this.formData.WardCode = null;
    },
    "formData.FamilyPermanentAddressDistrictCode": function () {
      this.formData.FamilyPermanentAddressWardCode = null;
    },
    "formData.FamilyCurrentDistrictCode": function () {
      this.formData.FamilyCurrentWardCode = null;
    },
  },

  methods: {
    getDistrictsOfProvince,
    getWardsOfDistrict,

    /**
     * Description: Xử lý sự kiện thoát form
     * Author: txphuc (25/08/2023)
     */
    onCloseForm() {
      if (this.formModified) {
        // Nếu form đã bị sửa đổi thì hiện cảnh báo
        this.$store.dispatch("dialogStore/showExistFormWarning", {
          cancel: this.confirmExitForm,
          submit: this.confirmSubmitForm,
        });
      } else {
        // Form chưa bị sửa đổi thì đóng form
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

        // Validate toàn bộ input
        const success = await this.$refs.formValidation.validate();

        if (success) {
          if (this.employeeRelationshipStore.mode === enums.form.mode.CREATE) {
            result = await this.handleCreateRelationship();
          } else if (this.employeeRelationshipStore.mode === enums.form.mode.UPDATE) {
            result = await this.handleUpdateRelationship();
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

        //
        RelationshipName: getRelationship(this.formData.Relationship)?.label,
        GenderName: getGender(this.formData.Gender)?.label,
        NationalityName: getCountry(this.formData.NationalityCode)?.label,
        IdentifyKindOfPaperName: getIdentifyType(this.formData.IdentifyKindOfPaper)?.label,
        IdentifyNumberIssuedPlaceName: getProvince(this.formData.IdentifyNumberIssuedPlaceCode)
          ?.label,
        CountryName: getCountry(this.formData.CountryCode)?.label,
        ProvinceName: getProvince(this.formData.ProvinceCode)?.label,
        DistrictName: getDistrict(this.formData.DistrictCode)?.label,
        WardName: getWard(this.formData.WardCode)?.label,
        FamilyPermanentAddressProvinceName: getProvince(
          this.formData.FamilyPermanentAddressProvinceCode
        )?.label,
        FamilyPermanentAddressDistrictName: getDistrict(
          this.formData.FamilyPermanentAddressDistrictCode
        )?.label,
        FamilyPermanentAddressWardName: getWard(this.formData.FamilyPermanentAddressWardCode)
          ?.label,
        FamilyCurrentProvinceName: getProvince(this.formData.FamilyCurrentProvinceCode)?.label,
        FamilyCurrentDistrictName: getDistrict(this.formData.FamilyCurrentDistrictCode)?.label,
        FamilyCurrentWardName: getWard(this.formData.FamilyCurrentWardCode)?.label,
      };

      return data;
    },

    /**
     * Description: Hàm xử lý thêm thành viên gia đình
     * Author: txphuc (26/08/2023)
     */
    async handleCreateRelationship() {
      try {
        if (this.employeeRelationshipStore.mode === enums.form.mode.CREATE) {
          const data = this.generateData();

          if (this.callApi) {
            data.EmployeeID = this.parentId;

            await employeeRelationshipApi.create(data);

            // Hiện toast message thành công
            this.$store.dispatch("toastStore/pushSuccessMessage", {
              message: "Thêm thông tin gia đình thành công",
            });

            this.$emit("submit");
          } else {
            this.$store.dispatch("employeeRelationshipStore/addRelationship", data);
          }

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

          // Tránh thay đổi trạng thái sửa đổi form
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
    async handleUpdateRelationship() {
      try {
        if (this.employeeRelationshipStore.mode === enums.form.mode.UPDATE) {
          const data = this.generateData();

          if (this.callApi) {
            await employeeRelationshipApi.update(data.EmployeeRelationshipID, data);

            // Hiện toast message thành công
            this.$store.dispatch("toastStore/pushSuccessMessage", {
              message: "Sửa thông tin gia đình thành công",
            });
            this.$emit("submit");
          } else {
            this.$store.dispatch("employeeRelationshipStore/updateRelationship", data);
          }

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
