<template>
  <div @click.stop="" class="ms-filter-popup">
    <div class="ms-filter-popup__header">
      <div class="ms-filter-popup__header-title">Bộ lọc</div>
      <div v-tooltip="'Đóng'" @click="closeFilter" class="ms-filter-popup__close">
        <MISAIcon icon="times" />
      </div>
    </div>

    <div class="ms-filter-popup__scroll">
      <div class="ms-filter-popup__content">
        <div
          v-for="group in localFilterGroups"
          :key="group.key"
          :class="[
            'ms-filter-popup__item',
            { '--enabled': group.enabled },
            { '--separate-header': group.filters.length > 1 },
          ]"
        >
          <div class="ms-filter-popup__item-header">
            <DxCheckBox v-model="group.enabled" :text="group?.name" />
          </div>

          <div v-if="group.enabled">
            <div
              v-for="filter in group.filters"
              :key="filter.key"
              class="ms-filter-popup__item-content"
            >
              <DxRadioGroup
                v-if="filter.type == 'option'"
                v-model="filter.value"
                :items="filter.options"
                display-expr="label"
                value-expr="value"
                layout="horizontal"
              />

              <div v-if="filter.type == 'date-between'">
                <div class="ms-filter-popup__input-wrap">
                  <div class="ms-filter-popup__input-label">Từ ngày:</div>
                  <div class="ms-filter-popup__input">
                    <MISADatePicker v-model="filter.start" />
                  </div>
                </div>
                <div class="ms-filter-popup__input-wrap">
                  <div class="ms-filter-popup__input-label">Đến ngày:</div>
                  <div class="ms-filter-popup__input">
                    <MISADatePicker v-model="filter.end" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="ms-filter-popup__footer">
      <MISAButton @click="resetFilter" color="secondary">Bỏ lọc</MISAButton>
      <MISAButton @click="applyFilterChange" type="primary">Áp dụng</MISAButton>
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
  name: "MISAFilterPopup",
  emits: ["close", "apply", "reset"],
  components: {
    MISAButton,
    MISAIcon,
    DxCheckBox,
    DxRadioGroup,
    MISADatePicker,
  },
  props: {
    // Cấu hình bộ lọc
    filterGroups: {
      type: Array,
      default() {
        return [];
      },
    },

    // Bộ lọc mặc định
    defaultFilterGroups: {
      type: Array,
      default() {
        return [];
      },
    },
  },
  data: function () {
    return {
      // Deep clone tránh tham chiếu ra component cha
      localFilterGroups: JSON.parse(JSON.stringify(this.filterGroups)),
    };
  },
  methods: {
    /**
     * Description: Áp dụng thay đổi của filter
     * Author: txphuc (25/08/2023)
     */
    applyFilterChange() {
      // Deep clone tránh compnent cha tham chiếu vào component con
      const newFilterGroups = JSON.parse(JSON.stringify(this.localFilterGroups));

      this.$emit("apply", newFilterGroups);

      this.closeFilter();
    },

    /**
     * Description: Đóng menu và reset filter
     * Author: txphuc (22/07/2023)
     */
    resetFilter() {
      // Deep clone tránh compnent cha tham chiếu vào component con
      const defaultFilterGroups = JSON.parse(JSON.stringify(this.defaultFilterGroups));

      this.$emit("reset", defaultFilterGroups);

      this.closeFilter();
    },

    /**
     * Description: Đóng menu
     * Author: txphuc (22/07/2023)
     */
    closeFilter() {
      this.$emit("close");
    },
  },
};
</script>

<style lang="scss" scoped>
@import url("./filter-popup.scss");
</style>
