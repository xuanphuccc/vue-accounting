<template>
  <div tabindex="-1" class="ms-combobox">
    <input class="ms-combobox__input" type="text" id="combobox2" placeholder="Chọn công ty" />

    <div class="ms-combobox__toggle" title="Combobox">
      <span class="ms-combobox__toggle-icon ms-icon--angle-down-16"></span>
    </div>

    <div class="ms-combobox__list-container">
      <ul class="ms-combobox__select-list">
        <li class="ms-combobox__item --selected">
          Type 1
          <span class="ms-combobox__item-icon ms-icon--check-24"></span>
        </li>
        <li class="ms-combobox__item">Type 2</li>
        <li class="ms-combobox__item">Type 3</li>
      </ul>
    </div>
  </div>
</template>

<style scoped>
@import url("./combobox.css");
</style>
