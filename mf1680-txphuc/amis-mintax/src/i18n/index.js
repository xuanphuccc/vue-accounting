import Vue from "vue";
import VueI18n from "vue-i18n";
import resourceVn from "./resource-vn";
import resourceEn from "./resource-en";

Vue.use(VueI18n);

const messages = {
  vi: resourceVn,
  en: resourceEn,
};

const i18n = new VueI18n({
  locale: "en",
  fallbackLocale: "vi",
  messages,
  silentFallbackWarn: true,
});

export default i18n;
