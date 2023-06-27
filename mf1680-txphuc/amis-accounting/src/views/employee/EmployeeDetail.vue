<template>
  <Teleport to="#app">
    <MISAPopup @close="$emit('close')" v-if="props.active" :width="800" title="Thông tin nhân viên">
      <template #default>
        <MISARow :gutter="{ x: 24 }">
          <MISACol span="6">
            <MISARow :gutter="{ x: 8 }">
              <MISACol span="5">
                <MISAFormGroup label="Mã" for="input-id" class="mb-24">
                  <MISAInput focus="" id="input-id" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup label="Tên" for="input-name" class="mb-24">
                  <MISAInput id="input-name" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup label="Đơn vị" for="input-unit" class="mb-24">
                  <MISADropdown></MISADropdown>
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup label="Chức danh" for="input-unit" class="mb-24">
                  <MISAInput id="input-unit" />
                </MISAFormGroup>
              </MISACol>
            </MISARow>
          </MISACol>
          <MISACol span="6">
            <MISARow :gutter="{ x: 8 }">
              <MISACol span="5">
                <MISAFormGroup label="Ngày sinh" for="input-date-of-birth" class="mb-24">
                  <MISAInput type="date" id="input-date-of-birth" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup label="Giới tính" for="input-id" class="mb-24">
                  <MISAInput id="input-id" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="7">
                <MISAFormGroup label="Số CMND" for="input-id" class="mb-24">
                  <MISAInput id="input-id" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="5">
                <MISAFormGroup label="Ngày cấp" for="input-id" class="mb-24">
                  <MISAInput type="date" id="input-id" />
                </MISAFormGroup>
              </MISACol>
              <MISACol span="12">
                <MISAFormGroup label="Nơi cấp" for="input-id" class="mb-24">
                  <MISAInput id="input-id" />
                </MISAFormGroup>
              </MISACol>
            </MISARow>
          </MISACol>
        </MISARow>

        <MISARow :gutter="{ x: 8 }">
          <MISACol span="12">
            <MISAFormGroup label="Địa chỉ" for="input-id" class="mb-24">
              <MISAInput id="input-id" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup label="ĐT di động" for="input-id" class="mb-24">
              <MISAInput id="input-id" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup label="ĐT cố định" for="input-id" class="mb-24">
              <MISAInput id="input-id" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup label="Email" for="input-id" class="mb-24">
              <MISAInput id="input-id" />
            </MISAFormGroup>
          </MISACol>
        </MISARow>

        <MISARow :gutter="{ x: 8 }">
          <MISACol span="3">
            <MISAFormGroup label="TK ngân hàng" for="input-id">
              <MISAInput id="input-id" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup label="Tên ngân hàng" for="input-id">
              <MISAInput id="input-id" />
            </MISAFormGroup>
          </MISACol>
          <MISACol span="3">
            <MISAFormGroup label="Chi nhánh" for="input-id">
              <MISAInput id="input-id" />
            </MISAFormGroup>
          </MISACol>
        </MISARow>
      </template>

      <template #controls-left>
        <MISAButton type="secondary">Huỷ</MISAButton>
      </template>
      <template #controls-right>
        <MISAButton type="secondary">Cất</MISAButton>
        <MISAButton type="primary">Cất và thêm</MISAButton>
      </template>
    </MISAPopup>
  </Teleport>
</template>

<script setup>
import MISAPopup from "../../components/base/popup/MISAPopup.vue";
import MISAButton from "../../components/base/button/MISAButton.vue";
import MISAFormGroup from "../../components/base/input/MISAFormGroup.vue";
import MISAInput from "../../components/base/input/MISAInput.vue";
import MISADropdown from "../../components/base/dropdown-list/MISADropdown.vue";
import MISARow from "../../components/base/grid/MISARow.vue";
import MISACol from "../../components/base/grid/MISACol.vue";

defineEmits(["close"]);

const props = defineProps({
  // Trạng thái đóng mở popup
  active: {
    type: Boolean,
    default: false,
  },
});
</script>

<style scoped></style>
