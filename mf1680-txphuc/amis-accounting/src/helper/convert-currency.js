/**
 * Description: Convert currency
 * Author: txphuc (20/06/2023)
 */
function convertCurrency(currency) {
  try {
    let currencyString = currency.toLocaleString("vi-VN", {
      style: "currency",
      currency: "VND",
    });

    return currencyString;
  } catch (error) {
    return "";
  }
}

export default convertCurrency;
