<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">Thêm người nộp thuế</h1>
      </div>

      <div class="page__header-controls">
        <MISAButton @click="$store.dispatch('employeeStore/closeForm')" color="secondary"
          >Huỷ</MISAButton
        >

        <MISAButton @click="handleSubmitForm(true)" color="secondary">Lưu & Thêm mới</MISAButton>
        <MISAButton @click="handleSubmitForm(false)" color="primary">Lưu</MISAButton>
      </div>
    </div>

    <div class="page__content">
      <div class="form-content">
        <ValidationObserver ref="formValidation">
          <div class="form-content-wrapper">
            <div class="form-content__header pb-24">Thông tin chung</div>

            <div class="form-content__subheader">Thông tin cá nhân</div>

            <div class="mb-24">
              <MISARow :gutter="{ x: 80 }">
                <MISACol :span="6">
                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-100 d-flex align-center flex-wrap pr-12">
                          Loại đối tượng
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          :dataSource="employeeTypes"
                          v-model="formData.EmployeeType"
                          displayExpr="label"
                          valueExpr="value"
                          placeholder="Chọn loại đối tượng"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label class="height-36 d-flex align-center flex-wrap pr-12">
                          Mã người nộp thuế <span class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          name="Mã người nộp thuế"
                          rules="required"
                          v-slot="{ errors }"
                        >
                          <MISATextBox
                            v-model="formData.EmployeeCode"
                            placeholder="Nhập mã người nộp thuế"
                          />
                          <p class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Họ tên <span class="required-mark">*</span>
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider name="Họ tên" rules="required" v-slot="{ errors }">
                          <MISATextBox v-model="formData.FullName" placeholder="Nhập họ tên" />
                          <p class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Ngày sinh</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.DateOfBirth" />
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
                            v-model="formData.Gender"
                            :items="[
                              { value: 0, label: 'Nam' },
                              { value: 1, label: 'Nữ' },
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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Số điện thoại
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox v-model="formData.Mobile" placeholder="Nhập số điện thoại" />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Email</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox v-model="formData.Email" placeholder="Nhập email" />
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
                        <MISARow>
                          <div class="d-flex width-100 col-gap-8">
                            <MISATextBox
                              v-model="formData.TaxCode"
                              width="100%"
                              placeholder="Nhập mã số thuế"
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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Loại giấy tờ
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.IdentifyType"
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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Số CMND <span class="required-mark">*</span>
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISARow>
                          <div class="d-flex width-100 col-gap-8">
                            <ValidationProvider name="Số CMND" rules="required" v-slot="{ errors }">
                              <MISATextBox
                                v-model="formData.IdentifyNumber"
                                width="100%"
                                placeholder="Nhập số CMND"
                              />
                              <p class="validate-error">{{ errors[0] }}</p>
                            </ValidationProvider>

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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Ngày cấp <span class="required-mark">*</span>
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider name="Ngày cấp" rules="required" v-slot="{ errors }">
                          <MISADatePicker v-model="formData.IdentifyDate" />
                          <p class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Nơi cấp <span class="required-mark">*</span>
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider name="Nơi cấp" rules="required" v-slot="{ errors }">
                          <MISASelectBox
                            v-model="formData.IdentifyIssuedPlaceCode"
                            :dataSource="provinces"
                            displayExpr="label"
                            valueExpr="value"
                            :searchEnabled="true"
                            placeholder="Chọn/nhập nơi cấp"
                          />
                          <p class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Quốc tịch</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NationalCode"
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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Loại hợp đồng <span class="required-mark">*</span>
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          name="Loại hợp đồng"
                          rules="required"
                          v-slot="{ errors }"
                        >
                          <MISASelectBox
                            v-model="formData.ContractMintaxType"
                            :dataSource="contractTypes"
                            displayExpr="label"
                            valueExpr="value"
                            :searchEnabled="false"
                            placeholder="Chọn loại hợp đồng"
                          />
                          <p class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
              </MISARow>
            </div>

            <div class="form-content__subheader">Hộ khẩu thường trú</div>

            <div class="mb-24">
              <MISARow :gutter="{ x: 80 }">
                <MISACol :span="6">
                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Quốc gia</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeCountryCode"
                          :dataSource="countries"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập quốc gia"
                        />
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
                        <MISASelectBox
                          v-model="formData.NativeProvinceCode"
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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Quận/huyện</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeDistrictCode"
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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Xã/phường</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeWardCode"
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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Số nhà, đường/phố, thôn/xóm
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox
                          v-model="formData.NativeStreetHouseNumber"
                          placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Địa chỉ</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox :disabled="true" />
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
              </MISARow>
            </div>

            <div class="form-content__subheader">Chỗ ở hiện nay</div>

            <div class="mb-24">
              <MISARow :gutter="{ x: 80 }">
                <MISACol :span="6">
                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Giống hộ khẩu thường trú
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <div class="d-flex">
                          <DxCheckBox v-model="formData.IsCopyAddress" />
                          <div class="height-36"></div>
                        </div>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Quốc gia</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentCountryCode"
                          :dataSource="countries"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập quốc gia"
                        />
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
                        <MISASelectBox
                          v-model="formData.CurrentProvinceCode"
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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Quận/huyện</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentDistrictCode"
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
                      <div class="height-36"></div>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Xã/phường</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentWardCode"
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
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Số nhà, đường/phố, thôn/xóm
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox
                          v-model="formData.CurrentStreetHouseNumber"
                          placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">Địa chỉ</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox :disabled="true" />
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
              </MISARow>
            </div>

            <!-- ----- THÔNG TIN CÔNG VIỆC ----- -->
            <div class="form-content__header">Thông tin công việc</div>

            <div class="mb-24">
              <MISARow :gutter="{ x: 80 }">
                <MISACol :span="6">
                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Bộ phận/phòng ban <span class="required-mark">*</span>
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATreeView
                          v-model="formData.OrganizationUnitId"
                          :data-source="departments"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-36 d-flex align-center flex-wrap pr-12">
                          Vị trí công việc <span class="required-mark">*</span>
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          name="Vị trí công việc"
                          rules="required"
                          v-slot="{ errors }"
                        >
                          <MISASelectBox
                            v-model="formData.JobPositionId"
                            :dataSource="positions"
                            displayExpr="label"
                            valueExpr="value"
                            :searchEnabled="true"
                            placeholder="Chọn/ nhập vị trí công việc"
                          />
                          <p class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-100 d-flex align-center flex-wrap pr-12">Chức danh</div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox v-model="formData.JobTitleId" :disabled="true" />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-100 d-flex align-center flex-wrap pr-12">
                          Trạng thái làm việc
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.EmployeeStatus"
                          :dataSource="workStatuses"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="false"
                          placeholder="Chọn trạng thái làm việc"
                        />
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>

                <MISACol :span="6">
                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-100 d-flex align-center flex-wrap pr-12">
                          Ngày học việc
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.ProbationDate" />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-100 d-flex align-center flex-wrap pr-12">
                          Ngày thử việc
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.HireDate" />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-100 d-flex align-center flex-wrap pr-12">
                          Ngày chính thức
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.ReceiveDate" />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <div class="height-100 d-flex align-center flex-wrap pr-12">
                          Ngày nghỉ việc
                        </div>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.TerminationDate" />
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
              </MISARow>
            </div>

            <!-- ----- THÔNG TIN GIA ĐÌNH ----- -->
            <div class="d-flex align-center justify-content-between mt-44 pb-24">
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
        </ValidationObserver>
      </div>
    </div>
  </div>
</template>

<script>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import MISATextBox from "@/components/base/text-box/MISATextBox.vue";
import MISASelectBox from "@/components/base/select-box/MISASelectBox.vue";
import MISADatePicker from "@/components/base/date-picker/MISADatePicker.vue";
import MISARow from "@/components/base/grid/MISARow.vue";
import MISACol from "@/components/base/grid/MISACol.vue";
import DxCheckBox from "devextreme-vue/check-box";
import DxRadioGroup from "devextreme-vue/radio-group";
import EmployeeFamilyDetail from "./EmployeeFamilyDetail.vue";
import MISATreeView from "@/components/base/tree-view/MISATreeView.vue";
import {
  employeeTypes,
  identifyTypes,
  countries,
  provinces,
  districts,
  wards,
  contractTypes,
  departments,
  positions,
  workStatuses,
} from "@/api/mock-data";
import { mapState } from "vuex";
import enums from "@/enum/enum";
import employeeApi from "@/api/employee-api";
import { formatDate } from "devextreme/localization";
import { ValidationProvider, ValidationObserver } from "vee-validate";

const defaultFormData = {
  EmployeeType: 0,
  EmployeeCode: "",
  FullName: "",
  DateOfBirth: null,
  Gender: 0,
  Mobile: null,
  Email: null,
  TaxCode: null,
  IdentifyType: 0,
  IdentifyNumber: "",
  IdentifyDate: new Date(),
  IdentifyIssuedPlaceCode: "",
  NationalCode: "VN",
  ContractMintaxType: 0,
  NativeCountryCode: null,
  NativeProvinceCode: null,
  NativeDistrictCode: null,
  NativeWardCode: null,
  NativeStreetHouseNumber: null,
  IsCopyAddress: false,
  CurrentCountryCode: null,
  CurrentProvinceCode: null,
  CurrentDistrictCode: null,
  CurrentWardCode: null,
  CurrentStreetHouseNumber: null,
  OrganizationUnitId: 0,
  JobPositionId: 0,
  JobTitleId: null,
  EmployeeStatus: 1,
  ProbationDate: null,
  HireDate: null,
  ReceiveDate: null,
  TerminationDate: null,
  UsageStatus: true,
  EmployeeRelationships: [],
};

export default {
  name: "EmployeeDetail",
  components: {
    MISAButton,
    MISATextBox,
    MISAIcon,
    MISADatePicker,
    MISASelectBox,
    MISARow,
    MISACol,
    DxCheckBox,
    DxRadioGroup,
    EmployeeFamilyDetail,
    MISATreeView,
    ValidationProvider,
    ValidationObserver,
  },
  data: function () {
    return {
      employeeTypes,
      identifyTypes,
      countries,
      provinces,
      districts,
      wards,
      contractTypes,
      departments,
      positions,
      workStatuses,

      formData: {
        ...defaultFormData,
      },

      isOpenEmployeeFamilyDetail: false,

      loading: {
        submitAndContinue: false,
        submit: false,
      },
    };
  },

  computed: {
    ...mapState("employeeStore", {
      mode: (state) => state.mode,
      title: (state) => state.title,
      currentEmployee: (state) => state.currentEmployee,
    }),
  },

  methods: {
    /**
     * Description: Xử lý validate input
     * Author: txphuc (24/08/2023)
     */
    handleValidateInputs() {
      return true;
    },

    /**
     * Description: Hàm xử lý submit form ở các chế độ create/update/duplicate
     * Author: txphuc (01/07/2023)
     */
    async handleSubmitForm(isContinue = true) {
      try {
        let result = false;

        this.$refs.formValidation.validate().then(async (success) => {
          if (success) {
            // Bắt đầu loading
            if (isContinue) {
              this.loading.submitAndContinue = true;
            } else {
              this.loading.submit = true;
            }

            if (this.mode === enums.form.mode.CREATE) {
              result = await this.handleCreateEmployee();
            } else if (this.mode === enums.form.mode.UPDATE) {
              result = await this.handleUpdateEmployee();

              // if (result) {
              //   // Reset lại trạng thái form
              //   modifiedInput.value = false;
              // }
            }
          }
        });

        if (result && isContinue) {
          // Reset intpus và reload bảng
          await this.resetInputs();
          // this.$emit("submit");

          // Focus vào ô đầu tiên
          // if (employeeCodeRef.value) {
          //   employeeCodeRef.value.focus();
          // }
        } else if (result) {
          // Đóng form và reload lại bảng
          // this.closeForm();
          // this.$emit("submit");
        }

        // Tắt loading
        this.loading.submit = false;
        this.loading.submitAndContinue = false;
      } catch (error) {
        console.warn(error);
      }
    },

    /**
     * Description: Xử lý format data trước khi gửi
     * Author: txphuc (17/07/2023)
     */
    generateData() {
      const data = {
        ...this.formData,
        IdentifyDate: formatDate(this.formData.IdentifyDate, "yyyy-MM-dd"),
        DateOfBirth: formatDate(this.formData.DateOfBirth, "yyyy-MM-dd"),
        ProbationDate: formatDate(this.formData.ProbationDate, "yyyy-MM-dd"),
        HireDate: formatDate(this.formData.HireDate, "yyyy-MM-dd"),
        ReceiveDate: formatDate(this.formData.ReceiveDate, "yyyy-MM-dd"),
        TerminationDate: formatDate(this.formData.TerminationDate, "yyyy-MM-dd"),
      };

      return data;
    },

    /**
     * Description: Hàm xử lý gọi api tạo nhân viên
     * Author: txphuc (28/06/2023)
     */
    async handleCreateEmployee() {
      try {
        if (this.mode === enums.form.mode.CREATE) {
          const data = this.generateData();

          console.log(data);

          await employeeApi.create(data);

          // Hiện toast message thành công
          this.$store.dispatch("toastStore/pushSuccessMessage", {
            message: "Thêm người nộp thuế thành công",
          });

          return true;
        }
      } catch (error) {
        console.warn(error);

        return false;
      }
    },

    /**
     * Description: Hàm load dữ liệu để thực hiện update/duplicate
     * Author: txphuc (28/06/2023)
     */
    async handleLoadDataForUpdate() {
      try {
        if (this.mode === enums.form.mode.UPDATE) {
          const employeeId = this.currentEmployee.EmployeeID;

          // Gọi API lấy thông tin nhân viên cần sửa
          const response = await employeeApi.get(employeeId);
          const employeeData = response.data;

          console.log(employeeData);

          // Binding dữ liệu vào form
          this.formData = {
            ...employeeData,
            IdentifyDate: new Date(employeeData.IdentifyDate),
            DateOfBirth: new Date(employeeData.DateOfBirth),
            ProbationDate: new Date(employeeData.ProbationDate),
            HireDate: new Date(employeeData.HireDate),
            ReceiveDate: new Date(employeeData.ReceiveDate),
            TerminationDate: new Date(employeeData.TerminationDate),
          };

          // Tránh thay đổi trạng thái của form
          // isLoadData.value = true;
        }
      } catch (error) {
        console.warn(error);
      }
    },

    /**
     * Description: Hàm xử lý gọi api cập nhật nhân viên
     * Author: txphuc (28/06/2023)
     */
    async handleUpdateEmployee() {
      try {
        if (this.mode === enums.form.mode.UPDATE) {
          const employeeId = this.currentEmployee.EmployeeID;

          const data = this.generateData();

          await employeeApi.update(employeeId, data);

          // Hiện toast message thành công
          this.$store.dispatch("toastStore/pushSuccessMessage", {
            message: "Sửa người nộp thuế thành công",
          });

          return true;
        }
      } catch (error) {
        console.warn(error);

        return false;
      }
    },
  },

  created: function () {
    this.handleLoadDataForUpdate();
  },
};
</script>

<style lang="scss" scoped></style>
