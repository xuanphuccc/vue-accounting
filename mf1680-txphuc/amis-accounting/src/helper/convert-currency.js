/**
 * Description: Hàm xử lý chuyển đổi số sang định dạng tiền
 * Author: txphuc (20/06/2023)
 */
export function convertNumberToCurrency(currency) {
  try {
    currency = convertCurrencyToNumber(currency);

    let currencyString = currency.toLocaleString("vi-VN", {
      style: "decimal",
      currency: "VND",
    });

    return currencyString;
  } catch (error) {
    console.warn(error);
    return "";
  }
}

/**
 * Description: Hàm xử lý chuyển đổi định dạng tiền sang số
 * Author: txphuc (01/07/2023)
 */
export const convertCurrencyToNumber = (currency) => {
  try {
    currency = currency.split(".").join("");
    return Number(currency);
  } catch (error) {
    console.warn(error);
    return 0;
  }
};
