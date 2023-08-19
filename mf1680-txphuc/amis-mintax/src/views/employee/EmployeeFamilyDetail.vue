<template>
  <MISAPopup
    @submit="$emit('submit')"
    @close="$emit('close')"
    title="Thêm thành viên gia đình"
    :width="1146"
  >
    <div class="mb-24">
      <MISARow :gutter="{ x: 80 }">
        <MISACol :span="6">
          <div class="">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center">
                  Họ tên thành viên <span class="required-mark">*</span>
                </div>
              </MISACol>
              <MISACol :span="8">
                <DxTextBox placeholder="Nhập họ tên thành viên"></DxTextBox>
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center">
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
                <div class="height-100 d-flex align-center">Ngày sinh</div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center">Giới tính</div>
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
                <div class="height-100 d-flex align-center">Mã số thuế</div>
              </MISACol>
              <MISACol :span="8">
                <MISARow>
                  <div class="d-flex width-100 col-gap-8">
                    <DxTextBox placeholder="Nhập mã số thuế" width="100%"></DxTextBox>
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
                <div class="height-100 d-flex align-center">Quốc tịch</div>
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
                <div class="height-100 d-flex align-center">Loại giấy tờ</div>
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
                <div class="height-100 d-flex align-center">Số CMND</div>
              </MISACol>
              <MISACol :span="8">
                <MISARow>
                  <div class="d-flex width-100 col-gap-8">
                    <DxTextBox placeholder="Nhập số CMND/CCCD/Hộ chiếu" width="100%"></DxTextBox>
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
                <div class="height-100 d-flex align-center">Ngày cấp</div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center">Nơi cấp</div>
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
                <div class="height-100 d-flex align-center">Số khai sinh</div>
              </MISACol>
              <MISACol :span="8">
                <DxTextBox placeholder="Nhập số khai sinh"></DxTextBox>
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center">Quyển số</div>
              </MISACol>
              <MISACol :span="8">
                <DxTextBox placeholder="Nhập quyển số"></DxTextBox>
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center">Ngày cấp giấy khai sinh</div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker />
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
                <div class="height-100 d-flex align-center">Tỉnh/thành phố</div>
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
                <div class="height-100 d-flex align-center">Quận/huyện</div>
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
                <div class="height-100 d-flex align-center">Xã/phường</div>
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
                <div class="height-100 d-flex align-center">Tỉnh/thành phố</div>
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
                <div class="height-100 d-flex align-center">Quận/huyện</div>
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
                <div class="height-100 d-flex align-center">Xã/phường</div>
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
                <div class="height-100 d-flex align-center">Số nhà, đường/phố, thôn/xóm</div>
              </MISACol>
              <MISACol :span="8">
                <DxTextBox placeholder="Nhập số nhà, đường/phố, thôn/xóm"></DxTextBox>
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
                <div class="height-100 d-flex align-center">Tỉnh/thành phố</div>
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
                <div class="height-100 d-flex align-center">Quận/huyện</div>
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
                <div class="height-100 d-flex align-center">Xã/phường</div>
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
                <div class="height-100 d-flex align-center">Số nhà, đường/phố, thôn/xóm</div>
              </MISACol>
              <MISACol :span="8">
                <DxTextBox placeholder="Nhập số nhà, đường/phố, thôn/xóm"></DxTextBox>
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
                <div class="height-100 d-flex align-center">Là người phụ thuộc</div>
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
                <div class="height-100 d-flex align-center">Giảm trừ từ tháng</div>
              </MISACol>
              <MISACol :span="8">
                <MISADatePicker displayFormat="MM/yyyy" placeholder="__/ ____" />
              </MISACol>
            </MISARow>
          </div>

          <div class="mt-16">
            <MISARow>
              <MISACol :span="4">
                <div class="height-100 d-flex align-center">Giảm trừ đến tháng</div>
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
                <div class="height-100 d-flex align-center">Ghi chú</div>
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
      <MISAButton @click="$emit('close')" color="secondary">Huỷ</MISAButton>
      <MISAButton>Đồng ý</MISAButton>
    </template>
  </MISAPopup>
</template>

<script>
import MISAPopup from "@/components/base/popup/MISAPopup.vue";
import MISAIcon from "@/components/base/icon/MISAIcon.vue";
import MISAButton from "@/components/base/button/MISAButton.vue";
import DxTextBox from "devextreme-vue/text-box";
import { DxTextArea } from "devextreme-vue/text-area";
// import { ValidationProvider } from "vee-validate";
import MISASelectBox from "@/components/base/select-box/MISASelectBox.vue";
import MISADatePicker from "@/components/base/date-picker/MISADatePicker.vue";
import MISARow from "@/components/base/grid/MISARow.vue";
import MISACol from "@/components/base/grid/MISACol.vue";
import DxCheckBox from "devextreme-vue/check-box";
import DxRadioGroup from "devextreme-vue/radio-group";

export default {
  name: "EmployeeFamilyDetail",
  emits: ["close", "submit"],
  components: {
    MISAPopup,
    MISAButton,
    DxTextBox,
    DxTextArea,
    MISAIcon,
    // ValidationProvider,
    MISADatePicker,
    MISASelectBox,
    MISARow,
    MISACol,
    DxCheckBox,
    DxRadioGroup,
  },
  props: {},
  data: function () {
    return {};
  },
};
</script>

<style></style>
