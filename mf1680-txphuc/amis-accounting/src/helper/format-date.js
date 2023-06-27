/**
 * Author: txphuc (20/06/2023)
 * Description: Generate in format: DD/MM/YYYY
 */
function formatDate(dateString) {
  try {
    dateString = new Date(dateString);

    const date = dateString.getDate();
    const month = dateString.getMonth() + 1;
    const year = dateString.getFullYear();

    return `${date < 10 ? "0" + date : date}/${month < 10 ? "0" + month : month}/${year}`;
  } catch (error) {
    return "";
  }
}

export default formatDate;
