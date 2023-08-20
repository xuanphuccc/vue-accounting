<template>
  <div @click.stop="" class="ms-filter-popup">
    <div class="ms-filter-popup__header">
      <div class="ms-filter-popup__header-title">Bộ lọc</div>
      <div @click="$emit('close')" class="ms-filter-popup__close">
        <MISAIcon icon="times" />
      </div>
    </div>

    <div class="ms-filter-popup__content">
      <div class="ms-filter-popup__item">
        <div class="ms-filter-popup__item-header">
          <DxCheckBox text="Trạng thái làm việc" />
        </div>
        <div class="ms-filter-popup__item-content">
          <DxRadioGroup
            :items="[
              { id: 0, text: 'Đang làm việc' },
              { id: 1, text: 'Đã nghỉ việc' },
            ]"
            layout="horizontal"
          />
        </div>
      </div>

      <div class="ms-filter-popup__item --separate-header">
        <div class="ms-filter-popup__item-header">
          <DxCheckBox text="Loại đối tượng" />
        </div>
        <div class="ms-filter-popup__item-content">
          <DxRadioGroup
            :items="[
              { id: 0, text: 'Nhân viên' },
              { id: 1, text: 'Vãng lai' },
            ]"
            layout="horizontal"
          />
        </div>
        <div class="ms-filter-popup__item-content">
          <div class="ms-filter-popup__input-wrap">
            <div class="ms-filter-popup__input-label">Từ ngày:</div>
            <div class="ms-filter-popup__input"><MISADatePicker /></div>
          </div>
          <div class="ms-filter-popup__input-wrap">
            <div class="ms-filter-popup__input-label">Đến ngày:</div>
            <div class="ms-filter-popup__input"><MISADatePicker /></div>
          </div>
        </div>
      </div>
    </div>

    <div class="ms-filter-popup__footer">
      <MISAButton @click="closeMenu" color="secondary">Bỏ lọc</MISAButton>
      <MISAButton type="primary">Áp dụng</MISAButton>
    </div>
  </div>
</template>

<script>
import DxCheckBox from "devextreme-vue/check-box";
import MISAButton from "../button/MISAButton.vue";
import MISAIcon from "../icon/MISAIcon.vue";
import DxRadioGroup from "devextreme-vue/radio-group";
import MISADatePicker from "../date-picker/MISADatePicker.vue";

export default {
  name: "MISATableCustomize",
  emits: ["close", "change"],
  components: {
    MISAButton,
    MISAIcon,
    DxCheckBox,
    DxRadioGroup,
    MISADatePicker,
  },
  props: {},
  data: function () {
    return {};
  },
  methods: {
    /**
     * Description: Đóng menu
     * Author: txphuc (22/07/2023)
     */
    closeMenu() {
      this.$emit("close");
    },
  },
};
</script>

<style lang="scss" scoped>
@import url("./filter-popup.scss");
</style>
