<template>
  <div @keydown.stop="handleKeyboardEvent" class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">
          {{
            formMode == 0
              ? $t("employee.employeeDetail.createFormTitle")
              : $t("employee.employeeDetail.updateFormTitle")
          }}
        </h1>
      </div>

      <div class="page__header-controls">
        <MISAButton @click="onCloseForm" color="secondary">{{ $t("button.cancel") }}</MISAButton>

        <MISAButton
          v-tooltip="'Ctrl + Shift + S'"
          @click="handleSubmitForm(true)"
          color="secondary"
        >
          {{ $t("button.saveAndAddNew") }}
        </MISAButton>
        <MISAButton v-tooltip="'Ctrl + S'" @click="handleSubmitForm(false)" color="primary">
          {{ $t("button.save") }}
        </MISAButton>
      </div>
    </div>

    <div class="page__content">
      <div class="form-content">
        <ValidationObserver ref="formValidation">
          <div class="form-content-wrapper">
            <div class="form-content__header pb-24">
              {{ $t("employee.employeeDetail.mainInfoTitle") }}
            </div>

            <div class="form-content__subheader">
              {{ $t("employee.employeeDetail.personalInfoSubTitle") }}
            </div>

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
                          {{ $t("employee.employeeDetail.employeeType") }}
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          :dataSource="employeeTypes"
                          v-model="formData.EmployeeType"
                          displayExpr="label"
                          valueExpr="value"
                          auto-focus
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
                          {{ $t("employee.employeeDetail.employeeCode") }}
                          <span class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          :name="$t('employee.employeeDetail.employeeCode')"
                          rules="required"
                          v-slot="{ errors }"
                          slim
                        >
                          <div class="width-100">
                            <MISATextBox
                              v-model="formData.EmployeeCode"
                              :is-valid="!errors[0]"
                              :max-length="20"
                              :placeholder="`${$t('placeholder.input')} ${$t(
                                'employee.employeeDetail.employeeCode'
                              ).toLowerCase()}`"
                              id="employee-code"
                            />
                            <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                          </div>
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
                          {{ $t("employee.employeeDetail.fullName") }}
                          <span class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          :name="$t('employee.employeeDetail.fullName')"
                          rules="required"
                          v-slot="{ errors }"
                          slim
                        >
                          <div class="width-100">
                            <MISATextBox
                              v-model="formData.FullName"
                              :is-valid="!errors[0]"
                              :max-length="100"
                              :placeholder="`${$t('placeholder.input')} ${$t(
                                'employee.employeeDetail.fullName'
                              ).toLowerCase()}`"
                              id="full-name"
                            />
                            <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                          </div>
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
                        >
                          {{ $t("employee.employeeDetail.dateOfBirth") }}
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISADatePicker
                          v-model="formData.DateOfBirth"
                          :max="new Date()"
                          id="date-of-birth"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label for="gender" class="height-36 d-flex align-center flex-wrap pr-12">{{
                          $t("employee.employeeDetail.gender")
                        }}</label>
                      </MISACol>
                      <MISACol :span="8">
                        <div class="height-36 d-flex align-center">
                          <DxRadioGroup
                            v-model="formData.Gender"
                            :items="[
                              { value: 0, label: $t('gender.male') },
                              { value: 1, label: $t('gender.female') },
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
                          {{ $t("employee.employeeDetail.mobile") }}
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          :name="$t('employee.employeeDetail.mobile')"
                          rules="mobile"
                          v-slot="{ errors }"
                          slim
                        >
                          <div class="width-100">
                            <MISATextBox
                              v-model="formData.Mobile"
                              :is-valid="!errors[0]"
                              :placeholder="`${$t('placeholder.input')} ${$t(
                                'employee.employeeDetail.mobile'
                              ).toLowerCase()}`"
                              id="mobile"
                            />
                            <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                          </div>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label for="email" class="height-36 d-flex align-center flex-wrap pr-12">{{
                          $t("employee.employeeDetail.email")
                        }}</label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          :name="$t('employee.employeeDetail.email')"
                          rules="email"
                          v-slot="{ errors }"
                          slim
                        >
                          <div class="width-100">
                            <MISATextBox
                              v-model="formData.Email"
                              :is-valid="!errors[0]"
                              :placeholder="`${$t('placeholder.input')} ${$t(
                                'employee.employeeDetail.email'
                              ).toLowerCase()}`"
                              id="email"
                            />
                            <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                          </div>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
                <MISACol :span="6">
                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="tax-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >{{ $t("employee.employeeDetail.taxCode") }}</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <div class="d-flex width-100 col-gap-8">
                          <MISATextBox
                            v-model="formData.TaxCode"
                            :max-length="10"
                            width="100%"
                            :placeholder="`${$t('placeholder.input')} ${$t(
                              'employee.employeeDetail.taxCode'
                            ).toLowerCase()}`"
                            id="tax-code"
                          />

                          <MISAButton color="secondary">
                            {{ $t("employee.employeeDetail.button.getInfo") }}
                            <template #icon>
                              <MISAIcon :size="20" icon="get-info" />
                            </template>
                          </MISAButton>
                        </div>
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
                          {{ $t("employee.employeeDetail.identifyType") }}
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.IdentifyType"
                          :dataSource="identifyTypes"
                          displayExpr="label"
                          valueExpr="value"
                          id="identify-type"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          v-tooltip="getIdentifyType(formData.IdentifyType)?.description"
                          for="identify-number"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                        >
                          {{
                            $t("employee.employeeDetail.identifyNumber", {
                              identifyType: getIdentifyType(formData.IdentifyType)?.label,
                            })
                          }}
                          <span v-if="!formData.TaxCode" class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <div class="d-flex width-100 col-gap-8">
                          <ValidationProvider
                            :name="
                              $t('employee.employeeDetail.identifyNumber', {
                                identifyType: getIdentifyType(formData.IdentifyType)?.label,
                              })
                            "
                            :rules="`${!formData.TaxCode ? 'required' : ''}|numeric`"
                            v-slot="{ errors }"
                            slim
                          >
                            <div class="width-100">
                              <MISATextBox
                                v-model="formData.IdentifyNumber"
                                :is-valid="!errors[0]"
                                :max-length="20"
                                width="100%"
                                :placeholder="`${$t('placeholder.input')} ${$t(
                                  'employee.employeeDetail.identifyNumber',
                                  {
                                    identifyType: getIdentifyType(formData.IdentifyType)?.label,
                                  }
                                )}`"
                                id="identify-number"
                              />
                              <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                            </div>
                          </ValidationProvider>

                          <MISAButton color="secondary">
                            {{ $t("employee.employeeDetail.button.getInfo") }}
                            <template #icon>
                              <MISAIcon :size="20" icon="get-info" />
                            </template>
                          </MISAButton>
                        </div>
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
                          {{ $t("employee.employeeDetail.identifyDate") }}
                          <span v-if="!formData.TaxCode" class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          :name="$t('employee.employeeDetail.identifyDate')"
                          :rules="`${!formData.TaxCode ? 'required' : ''}`"
                          v-slot="{ errors }"
                          slim
                        >
                          <div class="width-100">
                            <MISADatePicker
                              v-model="formData.IdentifyDate"
                              :max="new Date()"
                              :is-valid="!errors[0]"
                              id="identify-date"
                            />
                            <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                          </div>
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
                          {{ $t("employee.employeeDetail.identifyIssuedPlace") }}
                          <span v-if="!formData.TaxCode" class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          :name="$t('employee.employeeDetail.identifyIssuedPlace')"
                          :rules="`${!formData.TaxCode ? 'required' : ''}`"
                          v-slot="{ errors }"
                          slim
                        >
                          <div class="width-100">
                            <MISASelectBox
                              v-model="formData.IdentifyIssuedPlaceCode"
                              :dataSource="getIdentifyPlaceDatasource(formData.IdentifyType)"
                              displayExpr="label"
                              valueExpr="value"
                              :searchEnabled="true"
                              :is-valid="!errors[0]"
                              :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                                'employee.employeeDetail.identifyIssuedPlace'
                              ).toLowerCase()}`"
                              id="identify-issued-place-code"
                            />
                            <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                          </div>
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
                          >{{ $t("employee.employeeDetail.national") }}</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NationalCode"
                          :dataSource="countries"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                            'employee.employeeDetail.national'
                          ).toLowerCase()}`"
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
                          {{ $t("employee.employeeDetail.contractType") }}
                          <span v-if="!formData.TaxCode" class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          :name="$t('employee.employeeDetail.contractType')"
                          :rules="`${!formData.TaxCode ? 'required' : ''}`"
                          v-slot="{ errors }"
                          slim
                        >
                          <div class="width-100">
                            <MISASelectBox
                              v-model="formData.ContractMintaxType"
                              :dataSource="contractTypes"
                              displayExpr="label"
                              valueExpr="value"
                              :searchEnabled="false"
                              :is-valid="!errors[0]"
                              id="contract-mintax-type"
                            />
                            <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                          </div>
                        </ValidationProvider>
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
              </MISARow>
            </div>

            <div class="form-content__subheader">
              {{ $t("employee.employeeDetail.permanentResidenceSubTitle") }}
            </div>

            <div class="mb-24">
              <MISARow :gutter="{ x: 80 }">
                <MISACol :span="6">
                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label
                          for="native-country-code"
                          class="height-36 d-flex align-center flex-wrap pr-12"
                          >{{ $t("employee.employeeDetail.country") }}</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeCountryCode"
                          :dataSource="countries"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                            'employee.employeeDetail.country'
                          ).toLowerCase()}`"
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
                          {{ $t("employee.employeeDetail.province") }}
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeProvinceCode"
                          :dataSource="provinces"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                            'employee.employeeDetail.province'
                          ).toLowerCase()}`"
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
                          >{{ $t("employee.employeeDetail.district") }}</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeDistrictCode"
                          :dataSource="getDistrictsOfProvince(formData.NativeProvinceCode)"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                            'employee.employeeDetail.district'
                          ).toLowerCase()}`"
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
                          >{{ $t("employee.employeeDetail.ward") }}</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.NativeWardCode"
                          :dataSource="getWardsOfDistrict(formData.NativeDistrictCode)"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                            'employee.employeeDetail.ward'
                          ).toLowerCase()}`"
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
                          {{ $t("employee.employeeDetail.streetNumber") }}
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox
                          v-model="formData.NativeStreetHouseNumber"
                          :placeholder="`${$t('placeholder.input')} ${$t(
                            'employee.employeeDetail.streetNumber'
                          ).toLowerCase()}`"
                          id="native-street"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label for="test" class="height-36 d-flex align-center flex-wrap pr-12">{{
                          $t("employee.employeeDetail.address")
                        }}</label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox :value="nativeAddress" :disabled="true" />
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
              </MISARow>
            </div>

            <div class="form-content__subheader">
              {{ $t("employee.employeeDetail.currentAccommodationSubTitle") }}
            </div>

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
                          {{ $t("employee.employeeDetail.isCopyAddress") }}
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
                          >{{ $t("employee.employeeDetail.country") }}</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentCountryCode"
                          :dataSource="countries"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          id="current-country-code"
                          :disabled="formData.IsCopyAddress"
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
                          {{ $t("employee.employeeDetail.province") }}
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentProvinceCode"
                          :dataSource="provinces"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                            'employee.employeeDetail.province'
                          ).toLowerCase()}`"
                          id="current-province-code"
                          :disabled="formData.IsCopyAddress"
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
                          >{{ $t("employee.employeeDetail.district") }}</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentDistrictCode"
                          :dataSource="getDistrictsOfProvince(formData.CurrentProvinceCode)"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                            'employee.employeeDetail.district'
                          ).toLowerCase()}`"
                          id="current-district-code"
                          :disabled="formData.IsCopyAddress"
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
                          >{{ $t("employee.employeeDetail.ward") }}</label
                        >
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.CurrentWardCode"
                          :dataSource="getWardsOfDistrict(formData.CurrentDistrictCode)"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="true"
                          :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                            'employee.employeeDetail.ward'
                          ).toLowerCase()}`"
                          id="current-ward-code"
                          :disabled="formData.IsCopyAddress"
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
                          {{ $t("employee.employeeDetail.streetNumber") }}
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox
                          v-model="formData.CurrentStreetHouseNumber"
                          :placeholder="`${$t('placeholder.input')} ${$t(
                            'employee.employeeDetail.streetNumber'
                          ).toLowerCase()}`"
                          id="current-street"
                          :disabled="formData.IsCopyAddress"
                        />
                      </MISACol>
                    </MISARow>
                  </div>

                  <div class="mt-16">
                    <MISARow>
                      <MISACol :span="4">
                        <label for="test" class="height-36 d-flex align-center flex-wrap pr-12">{{
                          $t("employee.employeeDetail.address")
                        }}</label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISATextBox :value="currentAddress" :disabled="true" />
                      </MISACol>
                    </MISARow>
                  </div>
                </MISACol>
              </MISARow>
            </div>

            <!-- ----- THÔNG TIN CÔNG VIỆC ----- -->
            <div class="form-content__header">{{ $t("employee.employeeDetail.jobInfoTitle") }}</div>

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
                          {{ $t("employee.employeeDetail.department") }}
                          <span class="required-mark">*</span>
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
                          {{ $t("employee.employeeDetail.jobPosition") }}
                          <span class="required-mark">*</span>
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <ValidationProvider
                          :name="$t('employee.employeeDetail.jobPosition')"
                          rules="required"
                          v-slot="{ errors }"
                          slim
                        >
                          <div class="width-100">
                            <MISASelectBox
                              v-model="formData.JobPositionId"
                              :dataSource="positions"
                              displayExpr="label"
                              valueExpr="value"
                              :searchEnabled="true"
                              :is-valid="!errors[0]"
                              :placeholder="`${$t('placeholder.selectOrInput')} ${$t(
                                'employee.employeeDetail.jobPosition'
                              ).toLowerCase()}`"
                              id="job-position-id"
                            />
                            <p v-if="errors[0]" class="validate-error">{{ errors[0] }}</p>
                          </div>
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
                          >{{ $t("employee.employeeDetail.jobTitle") }}</label
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
                          {{ $t("employee.employeeDetail.employeeStatus") }}
                        </label>
                      </MISACol>
                      <MISACol :span="8">
                        <MISASelectBox
                          v-model="formData.EmployeeStatus"
                          :dataSource="workStatuses"
                          displayExpr="label"
                          valueExpr="value"
                          :searchEnabled="false"
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
                          {{ $t("employee.employeeDetail.probationDate") }}
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
                          {{ $t("employee.employeeDetail.hireDate") }}
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
                          {{ $t("employee.employeeDetail.receiveDate") }}
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
                          {{ $t("employee.employeeDetail.terminationDate") }}
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
              <div class="form-content__header">
                {{ $t("employee.employeeDetail.familyInfoTitle") }}
              </div>
              <MISAButton
                v-tooltip="'Ctrl + 1'"
                @click="openFormForCreate"
                type="outline"
                color="primary"
              >
                {{ $t("button.add") }}
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

            <div v-if="displayRelationships?.length == 0" class="ms-empty-data">
              {{ $t("employee.employeeDetail.familyInfoEmpty") }}
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
  getIdentifyPlaceDatasource,
  getIdentifyPlace,
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

      // Cho phép load data vào các ô địa chỉ khi update mà không bị clear
      // (VD: thay đổi quân/huyện thì clear xã/phường)
      allowClearNativeAddress: true,
      allowClearCurrentAddress: true,
    };
  },

  computed: {
    ...mapState("employeeRelationshipStore", {
      employeeRelationshipStore: (state) => state,
    }),

    ...mapGetters("employeeRelationshipStore", ["displayRelationships"]),

    /**
     * Description: Lấy địa chỉ đầy đủ của hộ khẩu thường trú
     * Author: txphuc (02/09/2023)
     */
    nativeAddress() {
      let addressArr = [
        this.formData?.NativeStreetHouseNumber,
        getWard(this.formData?.NativeWardCode)?.label,
        getDistrict(this.formData?.NativeDistrictCode)?.label,
        getProvince(this.formData?.NativeProvinceCode)?.label,
        getCountry(this.formData?.NativeCountryCode)?.label,
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
        this.formData?.CurrentStreetHouseNumber,
        getWard(this.formData?.CurrentWardCode)?.label,
        getDistrict(this.formData?.CurrentDistrictCode)?.label,
        getProvince(this.formData?.CurrentProvinceCode)?.label,
        getCountry(this.formData?.CurrentCountryCode)?.label,
      ];

      // Bỏ qua giá trị rỗng
      addressArr = addressArr.filter((item) => item != null && item != undefined);

      return addressArr.join(", ");
    },
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

    "formData.IsCopyAddress": function () {
      if (this.formData?.IsCopyAddress) {
        this.formData = {
          ...this.formData,

          CurrentCountryCode: this.formData?.NativeCountryCode,
          CurrentProvinceCode: this.formData?.NativeProvinceCode,
          CurrentDistrictCode: this.formData?.NativeDistrictCode,
          CurrentWardCode: this.formData?.NativeWardCode,
          CurrentStreetHouseNumber: this.formData?.NativeStreetHouseNumber,
        };
      }
    },

    /**
     * Description: Reset quận/huyện và xã/phường khi tỉnh/TP thay đổi
     * Author: txphuc (31/08/2023)
     */
    "formData.NativeProvinceCode": function () {
      if (this.allowClearNativeAddress) {
        this.formData.NativeDistrictCode = null;
        this.formData.NativeWardCode = null;
      }

      // Cập nhật chỗ ở hiện nay khi hộ khẩu thường trú thay đổi
      if (this.formData.IsCopyAddress) {
        this.formData.CurrentProvinceCode = this.formData?.NativeProvinceCode;
      }
    },
    "formData.CurrentProvinceCode": function () {
      if (!this.formData.IsCopyAddress && this.allowClearCurrentAddress) {
        this.formData.CurrentDistrictCode = null;
        this.formData.CurrentWardCode = null;
      }
    },

    /**
     * Description: Reset xã/phường khi quận/huyện thay đổi
     * Author: txphuc (31/08/2023)
     */
    "formData.NativeDistrictCode": function () {
      if (this.allowClearNativeAddress) {
        this.formData.NativeWardCode = null;
      }

      // Cập nhật chỗ ở hiện nay khi hộ khẩu thường trú thay đổi
      if (this.formData.IsCopyAddress) {
        this.formData.CurrentDistrictCode = this.formData?.NativeDistrictCode;
      }
    },
    "formData.CurrentDistrictCode": function () {
      if (!this.formData.IsCopyAddress && this.allowClearCurrentAddress) {
        this.formData.CurrentWardCode = null;
      }
    },

    /**
     * Description: Trả lại trạng thái cho phép clear địa chỉ
     * khi đã load dữ liệu cho update xong
     * Author: txphuc (02/09/2023)
     */
    "formData.NativeWardCode": function () {
      this.allowClearNativeAddress = true;

      // Cập nhật chỗ ở hiện nay khi hộ khẩu thường trú thay đổi
      if (this.formData.IsCopyAddress) {
        this.formData.CurrentWardCode = this.formData?.NativeWardCode;
      }
    },
    "formData.CurrentWardCode": function () {
      this.allowClearCurrentAddress = true;
    },

    /**
     * Description: Cập nhật chỗ ở hiện nay khi hộ khẩu thường trú thay đổi
     * Author: txphuc (02/09/2023)
     */
    "formData.NativeStreetHouseNumber": function () {
      if (this.formData.IsCopyAddress) {
        this.formData.CurrentStreetHouseNumber = this.formData?.NativeStreetHouseNumber;
      }
    },
  },

  methods: {
    getDistrictsOfProvince,
    getWardsOfDistrict,
    getIdentifyType,
    getIdentifyPlaceDatasource,

    /**
     * Description: Hàm xử lý gọi api lấy mã nhân viên mới nhất
     * Author: txphuc (28/06/2023)
     */
    async getNewEmployeeCode() {
      try {
        if (this.formMode === enums.form.mode.CREATE) {
          // Tránh thay đổi trạng thái của form
          this.isLoadFormData = true;

          const response = await employeeApi.getNewCode();

          this.formData.EmployeeCode = response.data;
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
      let data = {
        ...this.formData,

        IdentifyDate: formatDate(this.formData?.IdentifyDate, "yyyy-MM-dd"),
        DateOfBirth: formatDate(this.formData?.DateOfBirth, "yyyy-MM-dd"),
        ProbationDate: formatDate(this.formData?.ProbationDate, "yyyy-MM-dd"),
        HireDate: formatDate(this.formData?.HireDate, "yyyy-MM-dd"),
        ReceiveDate: formatDate(this.formData?.ReceiveDate, "yyyy-MM-dd"),
        TerminationDate: formatDate(this.formData?.TerminationDate, "yyyy-MM-dd"),

        // Lấy thông tin bổ sung
        EmployeeTypeName: getEmployeeType(this.formData?.EmployeeType)?.label,
        GenderName: getGender(this.formData?.Gender)?.label,
        IdentifyTypeName: getIdentifyType(this.formData?.IdentifyType)?.label,
        IdentifyIssuedPlaceName: getIdentifyPlace(
          this.formData?.IdentifyType,
          this.formData?.IdentifyIssuedPlaceCode
        )?.label,
        NationalName: getCountry(this.formData?.NationalCode)?.label,
        ContractMintaxTypeName: getContractType(this.formData?.ContractMintaxType)?.label,
        NativeCountryName: getCountry(this.formData?.NativeCountryCode)?.label,
        NativeProvinceName: getProvince(this.formData?.NativeProvinceCode)?.label,
        NativeDistrictName: getDistrict(this.formData?.NativeDistrictCode)?.label,
        NativeWardName: getWard(this.formData?.NativeWardCode)?.label,
        CurrentCountryName: getCountry(this.formData?.CurrentCountryCode)?.label,
        CurrentProvinceName: getProvince(this.formData?.CurrentProvinceCode)?.label,
        CurrentDistrictName: getDistrict(this.formData?.CurrentDistrictCode)?.label,
        CurrentWardName: getWard(this.formData?.CurrentWardCode)?.label,
        OrganizationUnitName: "Nhân sự điều hành",
        JobPositionName: getPosition(this.formData?.JobPositionId)?.label,
        EmployeeStatusName: getWorkStatus(this.formData?.EmployeeStatus)?.label,
      };

      // Lấy danh sách thành viên gia đình
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
            message: this.$t("employee.toast.addSuccess"),
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

          // Tránh thay đổi trạng thái của form
          this.isLoadFormData = true;

          // Ngăn các ô địa chỉ bị clear
          this.allowClearNativeAddress = false;
          this.allowClearCurrentAddress = false;

          // Lấy Id từ param
          const employeeId = this.$route.params?.id;

          // Gọi API lấy thông tin nhân viên cần sửa
          const response = await employeeApi.get(employeeId);
          const employeeData = response.data;

          // Binding dữ liệu vào form
          this.formData = {
            ...employeeData,

            IdentifyDate: employeeData?.IdentifyDate && new Date(employeeData?.IdentifyDate),
            DateOfBirth: employeeData?.DateOfBirth && new Date(employeeData?.DateOfBirth),
            ProbationDate: employeeData?.ProbationDate && new Date(employeeData?.ProbationDate),
            HireDate: employeeData?.HireDate && new Date(employeeData?.HireDate),
            ReceiveDate: employeeData?.ReceiveDate && new Date(employeeData?.ReceiveDate),
            TerminationDate:
              employeeData?.TerminationDate && new Date(employeeData?.TerminationDate),
          };

          // Load danh sách thành viên gia đình vào bảng
          this.$store.dispatch(
            "employeeRelationshipStore/setRelationships",
            employeeData?.EmployeeRelationships
          );

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
            message: this.$t("employee.toast.updateSuccess"),
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
      this.showDeleteConfirmDialog(this.$t("employee.dialog.deleteFamilyDesc"));
    },

    /**
     * Description: Hiện dialog xác nhận xoá
     * Author: txphuc (24/06/2023).
     */
    showDeleteConfirmDialog(description) {
      this.$store.dispatch("dialogStore/showDeleteWarning", {
        title: this.$t("dialog.deleteTitle"),
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
        const shiftKey = e.shiftKey;
        const ctrlKey = e.ctrlKey;

        switch (keyCode) {
          case enums.key.NUM_1:
            if (ctrlKey) {
              e.preventDefault();

              // Ctrl + 1: Mở form thêm thành viên gia đình
              this.openFormForCreate();
            }
            break;
          case enums.key.S:
            if (ctrlKey && shiftKey) {
              e.preventDefault();

              // Ctrl + Shift + S: Lưu và thêm mới
              this.handleSubmitForm(true);
            } else if (ctrlKey) {
              e.preventDefault();

              // Ctrl + S: Lưu và đóng form
              this.handleSubmitForm(false);
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
