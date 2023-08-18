<template>
  <div class="page-container">
    <div class="page__header">
      <div class="page__title-wrapper">
        <h1 class="page__title">Thêm người nộp thuế</h1>
      </div>

      <div class="page__header-controls">
        <MISAButton
          @click="
            () => {
              this.$router.push({ name: 'employee' });
            }
          "
          color="secondary"
          >Huỷ</MISAButton
        >

        <MISAButton color="secondary">Lưu & Thêm mới</MISAButton>
        <MISAButton color="primary">Lưu</MISAButton>
      </div>
    </div>

    <div class="page__content">
      <div class="form-content">
        <div class="form-content-wrapper">
          <div class="form-content__header pb-24">Thông tin chung</div>

          <div class="form-content__subheader">Thông tin cá nhân</div>

          <div class="mb-24">
            <MISARow :gutter="{ x: 80 }">
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Loại đối tượng</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">
                        Mã người nộp thuế <span class="required-mark">*</span>
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox v-model="value" placeholder="Nhập mã người nộp thuế"></DxTextBox>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">
                        Họ tên <span class="required-mark">*</span>
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox v-model="value" placeholder="Nhập họ tên"></DxTextBox>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Ngày sinh</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISADatePickerVue v-model="date" />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Giới tính</div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox v-model="value" placeholder="Nhập họ tên"></DxTextBox>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Số điện thoại</div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox v-model="value" placeholder="Nhập số điện thoại"></DxTextBox>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Email</div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox v-model="value" placeholder="Nhập email"></DxTextBox>
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Mã số thuế</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISARow>
                        <div class="d-flex width-100 col-gap-8">
                          <DxTextBox
                            v-model="value"
                            width="100%"
                            placeholder="Nhập mã số thuế"
                          ></DxTextBox>
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
                      <div class="height-100 d-flex align-center">Loại giấy tờ</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">
                        Số CMND <span class="required-mark">*</span>
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISARow>
                        <div class="d-flex width-100 col-gap-8">
                          <DxTextBox
                            v-model="value"
                            width="100%"
                            placeholder="Nhập số CMND"
                          ></DxTextBox>
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
                      <div class="height-100 d-flex align-center">
                        Ngày cấp <span class="required-mark">*</span>
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISADatePickerVue v-model="date" />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">
                        Nơi cấp <span class="required-mark">*</span>
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Quốc tịch</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">
                        Loại hợp đồng <span class="required-mark">*</span>
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="false"
                        placeholder="Chọn giá trị"
                      />
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
                      <div class="height-100 d-flex align-center">Quốc gia</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Tỉnh/thành phố</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Quận/huyện</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Xã/phường</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Số nhà, đường/phố, thôn/xóm</div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox
                        v-model="value"
                        placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                      ></DxTextBox>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Địa chỉ</div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox v-model="value" :disabled="true"></DxTextBox>
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
                      <div class="height-100 d-flex align-center">Giống hộ khẩu thường trú</div>
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
                      <div class="height-100 d-flex align-center">Quốc gia</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Tỉnh/thành phố</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Quận/huyện</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
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
                      <div class="height-100 d-flex align-center">Xã/phường</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Số nhà, đường/phố, thôn/xóm</div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox
                        v-model="value"
                        placeholder="Nhập số nhà, đường/phố, thôn/xóm"
                      ></DxTextBox>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Địa chỉ</div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox v-model="value" :disabled="true"></DxTextBox>
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
                      <div class="height-100 d-flex align-center">
                        Bộ phận/phòng ban <span class="required-mark">*</span>
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="false"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">
                        Vị trí công việc <span class="required-mark">*</span>
                      </div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="true"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Chức danh</div>
                    </MISACol>
                    <MISACol :span="8">
                      <DxTextBox v-model="value" :disabled="true"></DxTextBox>
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Trạng thái làm việc</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISASelectBox
                        v-model="selectBoxValue"
                        :dataSource="simpleProducts"
                        displayExpr="label"
                        valueExpr="value"
                        :searchEnabled="false"
                        placeholder="Chọn giá trị"
                      />
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>

              <MISACol :span="6">
                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Ngày học việc</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISADatePickerVue v-model="date" />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Ngày thử việc</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISADatePickerVue v-model="date" />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Ngày chính thức</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISADatePickerVue v-model="date" />
                    </MISACol>
                  </MISARow>
                </div>

                <div class="mt-16">
                  <MISARow>
                    <MISACol :span="4">
                      <div class="height-100 d-flex align-center">Ngày nghỉ việc</div>
                    </MISACol>
                    <MISACol :span="8">
                      <MISADatePickerVue v-model="date" />
                    </MISACol>
                  </MISARow>
                </div>
              </MISACol>
            </MISARow>
          </div>

          <!-- ----- THÔNG TIN GIA ĐÌNH ----- -->
          <div class="d-flex align-center justify-content-between mt-44 pb-24">
            <div class="form-content__header">Thông tin gia đình</div>
            <MISAButton type="outline" color="primary"
              >Thêm
              <template #icon>
                <MISAIcon :size="20" icon="plus" />
              </template>
            </MISAButton>
          </div>

          <div class="ms-empty-data">Chưa có thông tin gia đình</div>

          <!-- ----- LỊCH SỬ TRẢ THU NHẬP ----- -->
          <div class="d-flex align-center justify-content-between mt-44 pb-24">
            <div class="form-content__header">Lịch sử trả thu nhập</div>
            <MISAButton type="outline" color="primary"
              >Thêm
              <template #icon>
                <MISAIcon :size="20" icon="plus" />
              </template>
            </MISAButton>
          </div>

          <div class="ms-empty-data">Chưa có lịch sử trả thu nhập</div>

          <!-- <ValidationProvider name="name" rules="even" v-slot="{ errors }">
            <DxTextBox v-model="value">
              <div class="input-action">
                <MISAIcon size="20" icon="search" />
              </div>
            </DxTextBox>
            <p>{{ errors[0] }}</p>
          </ValidationProvider> -->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import DxTextBox from "devextreme-vue/text-box";
// import { ValidationProvider } from "vee-validate";
import MISASelectBox from "@/components/base/select-box/MISASelectBox.vue";
import MISADatePickerVue from "@/components/base/date-picker/MISADatePicker.vue";
import MISARow from "@/components/base/grid/MISARow.vue";
import MISACol from "@/components/base/grid/MISACol.vue";
import DxCheckBox from "devextreme-vue/check-box";

const simpleProducts = [
  { label: "HD Video Player", value: 1 },
  { label: "SuperHD Video Player", value: 2 },
  { label: "SuperPlasma 50", value: 3 },
  { label: "SuperPlasma 4", value: 4 },
  { label: "SuperPlasma 5", value: 5 },
  { label: "SuperPlasma 6", value: 6 },
  { label: "SuperPlasma 7", value: 7 },
  { label: "SuperPlasma 8", value: 8 },
  { label: "SuperPlasma 9", value: 9 },
  { label: "SuperPlasma 10", value: 10 },
  { label: "SuperPlasma 11", value: 11 },
];

export default {
  name: "EmployeeList",
  components: {
    MISAButton,
    DxTextBox,
    MISAIcon,
    // ValidationProvider,
    MISADatePickerVue,
    MISASelectBox,
    MISARow,
    MISACol,
    DxCheckBox,
  },
  data: function () {
    return {
      value: "",
      date: null,
      simpleProducts,
      selectBoxValue: null,
    };
  },
  methods: {
    test(e) {
      console.log(e);
    },
  },
};
</script>

<style lang="scss" scoped></style>
