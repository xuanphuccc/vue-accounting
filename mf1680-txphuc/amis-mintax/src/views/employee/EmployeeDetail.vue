<template>
  <div @keydown.stop="handleKeyboardEvent" class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">{{ formMode == 0 ? "Thêm" : "Sửa" }} người nộp thuế</h1>
      </div>

      <div class="page__header-controls">
        <MISAButton @click="onCloseForm" color="secondary">Huỷ</MISAButton>

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
                        <label
                          for="employee-type"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Loại đối tượng
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          :dataSource="employeeTypes"
                          v-model="formData.EmployeeType"
                          displayExpr="label"
                          valueExpr="value"
                          auto-focus
                          placeholder="Chọn loại đối tượng"
                          id="employee-type"
                          :tabIndex="1"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="employee-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
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
                            :is-valid="!errors[0]"
                            placeholder="Nhập mã người nộp thuế"
                            id="employee-code"
                          />
                          <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="full-name"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Họ tên <span class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider name="Họ tên" rules="required" v-slot="{ errors }">
                          <MISATextBox
                            v-model="formData.FullName"
                            :is-valid="!errors[0]"
                            placeholder="Nhập họ tên"
                            id="full-name"
                          />
                          <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="date-of-birth"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >Ngày sinh</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.DateOfBirth" id="date-of-birth" />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label for="gender" class="height-36 d-flex align-center flex-wrap pr-12"
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
                        <label for="mobile" class="height-36 d-flex align-center flex-wrap pr-12">
                          Số điện thoại
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox
                          v-model="formData.Mobile"
                          placeholder="Nhập số điện thoại"
                          id="mobile"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label for="email" class="height-36 d-flex align-center flex-wrap pr-12"
                          >Email</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox v-model="formData.Email" placeholder="Nhập email" id="email" />
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
                <MISACol :span="6">
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
                              width="100%"
                              placeholder="Nhập mã số thuế"
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

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="identify-type"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Loại giấy tờ
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.IdentifyType"
                          :dataSource="identifyTypes"
                          displayExpr="label"
                          valueExpr="value"
                          placeholder="Chọn loại giấy tờ"
                          id="identify-type"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="identify-number"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Số CMND <span class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISARow>
                          <div class="d-flex width-100 col-gap-8">
                            <ValidationProvider name="Số CMND" rules="required" v-slot="{ errors }">
                              <MISATextBox
                                v-model="formData.IdentifyNumber"
                                :is-valid="!errors[0]"
                                width="100%"
                                placeholder="Nhập số CMND"
                                id="identify-number"
                              />
                              <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
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
                        <label
                          for="identify-date"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Ngày cấp <span class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider name="Ngày cấp" rules="required" v-slot="{ errors }">
                          <MISADatePicker
                            v-model="formData.IdentifyDate"
                            :is-valid="!errors[0]"
                            id="identify-date"
                          />
                          <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="identify-issued-place-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Nơi cấp <span class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider name="Nơi cấp" rules="required" v-slot="{ errors }">
                          <MISASelectBox
                            v-model="formData.IdentifyIssuedPlaceCode"
                            :dataSource="provinces"
                            displayExpr="label"
                            valueExpr="value"
                            :searchEnabled="true"
                            :is-valid="!errors[0]"
                            placeholder="Chọn/nhập nơi cấp"
                            id="identify-issued-place-code"
                          />
                          <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="national-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >Quốc tịch</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NationalCode"
                          :dataSource="countries"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập quốc tịch"
                          id="national-code"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="contract-mintax-type"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Loại hợp đồng <span class="required-mark">*</span>
                        </label>
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
                            :is-valid="!errors[0]"
                            placeholder="Chọn loại hợp đồng"
                            id="contract-mintax-type"
                          />
                          <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
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
                        <label
                          for="native-country-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >Quốc gia</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeCountryCode"
                          :dataSource="countries"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập quốc gia"
                          id="native-country-code"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="native-province-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Tỉnh/thành phố
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeProvinceCode"
                          :dataSource="provinces"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập tỉnh/thành phố"
                          id="native-province-code"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="native-district-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >Quận/huyện</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeDistrictCode"
                          :dataSource="getDistrictsOfProvince(formData.NativeProvinceCode)"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập quận/huyện"
                          id="native-district-code"
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
                          for="native-ward-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >Xã/phường</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeWardCode"
                          :dataSource="getWardsOfDistrict(formData.NativeDistrictCode)"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập xã/phường"
                          id="native-ward-code"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="native-street"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Số nhà, đường/phố, thôn/xóm
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox
                          v-model="formData.NativeStreetHouseNumber"
                          placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                          id="native-street"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label for="test" class="height-36 d-flex align-center flex-wrap pr-12"
                          >Địa chỉ</label
                        >
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
                        <label
                          for="is-copy-address"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Giống hộ khẩu thường trú
                        </label>
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
                        <label
                          for="current-country-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >Quốc gia</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentCountryCode"
                          :dataSource="countries"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập quốc gia"
                          id="current-country-code"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="current-province-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Tỉnh/thành phố
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentProvinceCode"
                          :dataSource="provinces"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập tỉnh/thành phố"
                          id="current-province-code"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="current-district-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >Quận/huyện</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentDistrictCode"
                          :dataSource="getDistrictsOfProvince(formData.CurrentProvinceCode)"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập quận/huyện"
                          id="current-district-code"
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
                        <label
                          for="current-ward-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >Xã/phường</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentWardCode"
                          :dataSource="getWardsOfDistrict(formData.CurrentDistrictCode)"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          placeholder="Chọn/nhập xã/phường"
                          id="current-ward-code"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="current-street"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Số nhà, đường/phố, thôn/xóm
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox
                          v-model="formData.CurrentStreetHouseNumber"
                          placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                          id="current-street"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label for="test" class="height-36 d-flex align-center flex-wrap pr-12"
                          >Địa chỉ</label
                        >
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
                        <label
                          for="organization-unit-id"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Bộ phận/phòng ban <span class="required-mark">*</span>
                        </label>
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
                        <label
                          for="job-position-id"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Vị trí công việc <span class="required-mark">*</span>
                        </label>
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
                            :is-valid="!errors[0]"
                            placeholder="Chọn/ nhập vị trí công việc"
                            id="job-position-id"
                          />
                          <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="job-title-id"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >Chức danh</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox
                          v-model="formData.JobTitleId"
                          :disabled="true"
                          id="job-title-id"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="employee-status"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Trạng thái làm việc
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.EmployeeStatus"
                          :dataSource="workStatuses"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="false"
                          placeholder="Chọn trạng thái làm việc"
                          id="employee-status"
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
                          for="probation-date"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Ngày học việc
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.ProbationDate" id="probation-date" />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="hire-date"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Ngày thử việc
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.HireDate" id="hire-date" />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="receive-date"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Ngày chính thức
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.ReceiveDate" id="receive-date" />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="termination-date"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          Ngày nghỉ việc
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker v-model="formData.TerminationDate" id="termination-date" />
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
              </MISARow>
            </div>

            <!-- ----- THÔNG TIN GIA ĐÌNH ----- -->
            <div class="d-flex align-center justify-content-between mt-44 pb-24">
              <div class="form-content__header">Thông tin gia đình</div>
              <MISAButton @click="openFormForCreate" type="outline" color="primary">
                Thêm
                <template #icon>
                  <MISAIcon :size="20" icon="plus" />
                </template>
              </MISAButton>
            </div>

            <!-- Form thông tin gia đình -->
            <EmployeeFamilyDetail v-if="employeeRelationshipStore.active" />

            <!-- Bảng thông tin gia đình -->
            <MISATable
              v-if="displayRelationships?.length > 0"
              @edit-row="onClickEditRow"
              @delete-row="onClickDeleteRow"
              :columns="tableColumns"
              :dataSource="displayRelationships"
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

            <div v-if="displayRelationships?.length == 0" class="ms-empty-data">
              Chưa có thông tin gia đình
            </div>
          </div>
        </ValidationObserver>
      </div>
    </div>
  </div>
</template>

<script>
import MISATable from "@/components/base/table/MISATable.vue";
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
  contractTypes,
  departments,
  positions,
  workStatuses,
  getEmployeeType,
  getGender,
  getIdentifyType,
  getCountry,
  getProvince,
  getDistrict,
  getDistrictsOfProvince,
  getWard,
  getWardsOfDistrict,
  getPosition,
  getWorkStatus,
  getContractType,
} from "@/api/mock-data";
import { mapState, mapGetters } from "vuex";
import enums from "@/enum/enum";
import employeeApi from "@/api/employee-api";
import { formatDate } from "devextreme/localization";
import { ValidationProvider, ValidationObserver } from "vee-validate";
import { employeeRelationshipColumns } from "./employee-columns";

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
  IdentifyDate: null,
  IdentifyIssuedPlaceCode: "",
  NationalCode: "VN",
  ContractMintaxType: 1,
  NativeCountryCode: "VN",
  NativeProvinceCode: null,
  NativeDistrictCode: null,
  NativeWardCode: null,
  NativeStreetHouseNumber: null,
  IsCopyAddress: false,
  CurrentCountryCode: "VN",
  CurrentProvinceCode: null,
  CurrentDistrictCode: null,
  CurrentWardCode: null,
  CurrentStreetHouseNumber: null,
  OrganizationUnitId: 0,
  JobPositionId: null,
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
    MISATable,
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
      contractTypes,
      departments,
      positions,
      workStatuses,

      // Chế độ của form
      formMode: this.$route.params?.id ? enums.form.mode.UPDATE : enums.form.mode.CREATE,

      // Dữ liệu của form
      formData: {
        ...defaultFormData,
      },

      // Trạng thái sửa đổi form
      formModified: false,
      isLoadFormData: false,

      // Các cột của bảng thành viên gia đình
      tableColumns: employeeRelationshipColumns.map((col) => ({ ...col })),

      // Bản ghi thành viên gia đình đang chờ xoá
      activeRowState: null,
    };
  },

  computed: {
    ...mapState("employeeRelationshipStore", {
      employeeRelationshipStore: (state) => state,
    }),

    ...mapGetters("employeeRelationshipStore", ["displayRelationships"]),
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
    "formData.NativeProvinceCode": function () {
      this.formData.NativeDistrictCode = null;
      this.formData.NativeWardCode = null;
    },
    "formData.CurrentProvinceCode": function () {
      this.formData.CurrentDistrictCode = null;
      this.formData.CurrentWardCode = null;
    },

    /**
     * Description: Reset xã/phường khi quận/huyện thay đổi
     * Author: txphuc (31/08/2023)
     */
    "formData.NativeDistrictCode": function () {
      this.formData.NativeWardCode = null;
    },
    "formData.CurrentDistrictCode": function () {
      this.formData.CurrentWardCode = null;
    },
  },

  methods: {
    getDistrictsOfProvince,
    getWardsOfDistrict,

    /**
     * Description: Hàm xử lý gọi api lấy mã nhân viên mới nhất
     * Author: txphuc (28/06/2023)
     */
    async getNewEmployeeCode() {
      try {
        if (this.formMode === enums.form.mode.CREATE) {
          const response = await employeeApi.getNewCode();

          this.formData.EmployeeCode = response.data;

          // Tránh thay đổi trạng thái của form
          this.isLoadFormData = true;
        }
      } catch (error) {
        console.warn(error);
      }
    },

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
        this.$router.push({ name: "employee" });
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
      this.$router.push({ name: "employee" });
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
     * Author: txphuc (10/08/2023)
     */
    async handleSubmitForm(isContinue = true) {
      try {
        let result = false;

        // Validate toàn bộ input
        const success = await this.$refs.formValidation.validate();

        if (success) {
          // Bắt đầu loading
          this.$store.dispatch("commonStore/setLoading", true);

          if (this.formMode === enums.form.mode.CREATE) {
            result = await this.handleCreateEmployee();
          } else if (this.formMode === enums.form.mode.UPDATE) {
            result = await this.handleUpdateEmployee();

            // if (result) {
            //   // Reset lại trạng thái form
            //   modifiedInput.value = false;
            // }
          }

          if (result && isContinue) {
            // Reset intpus và reload bảng
            await this.resetInputs();

            // Đặt lại trạng thái validate
            this.$refs.formValidation.reset();

            // Focus vào ô đầu tiên
            // if (employeeCodeRef.value) {
            //   employeeCodeRef.value.focus();
            // }
          } else if (result) {
            // Đóng form và chuyển sang trang xem chi tiết
            let employeeId = result;

            if (this.formMode === enums.form.mode.UPDATE) {
              employeeId = this.$route.params?.id;
            }

            this.$router.push({ name: "employee-detail-view", params: { id: employeeId } });
          }

          // Tắt loading
          this.$store.dispatch("commonStore/setLoading", false);
        }
      } catch (error) {
        console.warn(error);
      }
    },

    /**
     * Description: Reset toàn bộ input về trạng thái ban đầu
     * Author: txphuc (28/08/2023)
     */
    async resetInputs() {
      if (this.formMode === enums.form.mode.CREATE) {
        this.formData = { ...defaultFormData };

        await this.getNewEmployeeCode();
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

        //
        EmployeeTypeName: getEmployeeType(this.formData.EmployeeType)?.label,
        GenderName: getGender(this.formData.Gender)?.label,
        IdentifyTypeName: getIdentifyType(this.formData.IdentifyType)?.label,
        IdentifyIssuedPlaceName: getProvince(this.formData.IdentifyIssuedPlaceCode)?.label,
        NationalName: getCountry(this.formData.NationalCode)?.label,
        ContractMintaxTypeName: getContractType(this.formData.ContractMintaxType)?.label,
        NativeCountryName: getCountry(this.formData.NativeCountryCode)?.label,
        NativeProvinceName: getProvince(this.formData.NativeProvinceCode)?.label,
        NativeDistrictName: getDistrict(this.formData.NativeDistrictCode)?.label,
        NativeWardName: getWard(this.formData.NativeWardCode)?.label,
        CurrentCountryName: getCountry(this.formData.CurrentCountryCode)?.label,
        CurrentProvinceName: getProvince(this.formData.CurrentProvinceCode)?.label,
        CurrentDistrictName: getDistrict(this.formData.CurrentDistrictCode)?.label,
        CurrentWardName: getWard(this.formData.CurrentWardCode)?.label,
        OrganizationUnitName: "Nhân sự điều hành",
        JobPositionName: getPosition(this.formData.JobPositionId)?.label,
        EmployeeStatusName: getWorkStatus(this.formData.EmployeeStatus)?.label,
      };

      if (this.formMode === enums.form.mode.CREATE) {
        // Chỉ lấy bản ghi thành viên gia đình có EditMode khác Delete
        data.EmployeeRelationships = this.displayRelationships;
      } else if (this.formMode === enums.form.mode.UPDATE) {
        // Lấy tất cả các bản ghi thành viên gia đình
        data.EmployeeRelationships = this.employeeRelationshipStore.relationships;
      }

      return data;
    },

    /**
     * Description: Hàm xử lý gọi api tạo nhân viên
     * Author: txphuc (28/06/2023)
     */
    async handleCreateEmployee() {
      try {
        if (this.formMode === enums.form.mode.CREATE) {
          const data = this.generateData();

          const result = await employeeApi.create(data);

          // Hiện toast message thành công
          this.$store.dispatch("toastStore/pushSuccessMessage", {
            message: "Thêm người nộp thuế thành công",
          });

          return result.data;
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
        if (this.formMode == enums.form.mode.UPDATE) {
          // Bật loading
          this.$store.dispatch("commonStore/setLoading", true);

          // Lấy Id từ param
          const employeeId = this.$route.params?.id;

          // Gọi API lấy thông tin nhân viên cần sửa
          const response = await employeeApi.get(employeeId);
          const employeeData = response.data;

          // Binding dữ liệu vào form
          this.formData = {
            ...employeeData,
            IdentifyDate: employeeData.IdentifyDate && new Date(employeeData.IdentifyDate),
            DateOfBirth: employeeData.DateOfBirth && new Date(employeeData.DateOfBirth),
            ProbationDate: employeeData.ProbationDate && new Date(employeeData.ProbationDate),
            HireDate: employeeData.HireDate && new Date(employeeData.HireDate),
            ReceiveDate: employeeData.ReceiveDate && new Date(employeeData.ReceiveDate),
            TerminationDate: employeeData.TerminationDate && new Date(employeeData.TerminationDate),
          };

          // Load danh sách thành viên gia đình vào bảng
          this.$store.dispatch(
            "employeeRelationshipStore/setRelationships",
            employeeData.EmployeeRelationships
          );

          // Tránh thay đổi trạng thái của form
          this.isLoadFormData = true;

          // Tắt loading
          this.$store.dispatch("commonStore/setLoading", false);
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
        if (this.formMode === enums.form.mode.UPDATE) {
          const employeeId = this.$route.params?.id;

          const data = this.generateData();

          const result = await employeeApi.update(employeeId, data);

          // Hiện toast message thành công
          this.$store.dispatch("toastStore/pushSuccessMessage", {
            message: "Sửa người nộp thuế thành công",
          });

          return result.data;
        }
      } catch (error) {
        console.warn(error);

        return false;
      }
    },

    // -------------- Thành viên gia đình --------------

    /**
     * Description: Mở form thêm mới thành viên gia đình
     * Author: txphuc (24/08/2023)
     */
    openFormForCreate() {
      this.$store.dispatch("employeeRelationshipStore/openFormForCreate");
    },

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
      this.showDeleteConfirmDialog(
        `Bạn có chắc chắn xóa thông tin gia đình này khỏi danh sách không?`
      );
    },

    /**
     * Description: Hiện dialog xác nhận xoá
     * Author: txphuc (24/06/2023).
     */
    showDeleteConfirmDialog(description) {
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
    hideConfirmDialog() {
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
        this.hideConfirmDialog();
      } catch (error) {
        console.warn(error);

        // Ẩn dialog xác nhận xoá
        this.hideConfirmDialog();
      }
    },

    /**
     * Description: Xử lý sự kiện bàn phím
     * Author: txphuc (31/08/2023)
     */
    handleKeyboardEvent(e) {
      try {
        const keyCode = e.keyCode;
        const ctrlKey = e.ctrlKey;

        switch (keyCode) {
          case enums.key.NUM_1:
            if (ctrlKey) {
              e.preventDefault();

              // Ctrl + 1: Mở form thêm thành viên gia đình
              this.openFormForCreate();
            }
            break;

          default:
            break;
        }
      } catch (error) {
        console.warn(error);
      }
    },
  },

  /**
   * Description: Load dữ liệu khi form được tạo
   * Author: txphuc (25/08/2023)
   */
  created: function () {
    this.getNewEmployeeCode();
    this.handleLoadDataForUpdate();

    // Xoá dữ liệu cũ khi mở form
    this.$store.dispatch("employeeRelationshipStore/setRelationships", []);
  },
};
</script>

<style lang="scss" scoped></style>
