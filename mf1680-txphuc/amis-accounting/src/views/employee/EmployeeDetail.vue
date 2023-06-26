<template>
  <Teleport to="#app">
    <MISAPopup
      @close="$emit('close')"
      :active="props.active"
      :width="600"
      title="Thông tin nhân viên"
    >
      <template #default>
        <MISAFormGroup for="ms-input">
          <MISAInput id="ms-input" />
        </MISAFormGroup>
        <MISAFormGroup for="ms-input">
          <MISAInput id="ms-input" />
        </MISAFormGroup>

        <MISARow :gutter="{ x: 8, y: 8 }">
          <MISACol span="7"><div class="test">abc</div></MISACol>
          <MISACol span="3"><div class="test">abc</div></MISACol>
          <MISACol span="2"><div class="test">abc</div></MISACol>
          <MISACol span="7"><div class="test">abc</div></MISACol>
          <MISACol span="3"><div class="test">abc</div></MISACol>
          <MISACol span="2"><div class="test">abc</div></MISACol>
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

<style scoped>
.test {
  background-color: #ccc;
}
</style>
