import axiosClient from "./axios-client";

const rootUrl = "/Employees";

const employeeApi = {
  /**
   * Description: Lấy danh sách toàn bộ nhân viên
   * Author: txphuc (27/07/2023)
   */
  getAll() {
    const url = rootUrl;
    return axiosClient.get(url);
  },

  /**
   * Description: Lấy một nhân viên theo Id
   * Author: txphuc (27/07/2023)
   */
  get(employeeId) {
    const url = `${rootUrl}/${employeeId}`;
    return axiosClient.get(url);
  },

  /**
   * Description: Lấy danh sách nhân viên theo điều kiện lọc
   * và phân trang
   * Author: txphuc (27/07/2023)
   */
  filter(params = {}) {
    const url = `${rootUrl}/filter`;
    return axiosClient.post(url, params);
  },

  /**
   * Description: Lấy mã nhân viên mới
   * Author: txphuc (27/07/2023)
   */
  getNewCode() {
    const url = `${rootUrl}/NewCode`;
    return axiosClient.get(url);
  },

  /**
   * Description: Đếm số bản ghi đang sử dụng
   * Author: txphuc (27/07/2023)
   */
  getUsageCount() {
    const url = `${rootUrl}/UsageCount`;
    return axiosClient.get(url);
  },

  /**
   * Description: Tạo một nhân viên mới
   * Author: txphuc (27/07/2023)
   */
  create(employee) {
    const url = rootUrl;
    return axiosClient.post(url, employee);
  },

  /**
   * Description: Cập nhật một nhân viên theo Id
   * Author: txphuc (27/07/2023)
   */
  update(employeeId, employee) {
    const url = `${rootUrl}/${employeeId}`;
    return axiosClient.put(url, employee);
  },

  /**
   * Description: Cập nhật danh sách nhân viên theo Id
   * Author: txphuc (29/08/2023)
   */
  updateMultiple(employees) {
    const url = `${rootUrl}`;
    return axiosClient.put(url, employees);
  },

  /**
   * Description: Xoá danh sách nhân viên theo Id
   * Author: txphuc (27/07/2023)
   */
  deleteMultiple(employeeIds) {
    const url = `${rootUrl}`;
    return axiosClient.delete(url, {
      data: employeeIds,
    });
  },

  /**
   * Description: Xoá nhân viên theo Id
   * Author: txphuc (27/07/2023)
   */
  delete(employeeId) {
    const url = `${rootUrl}/${employeeId}`;
    return axiosClient.delete(url);
  },

  /**
   * Description: Download Excel
   * - Download toàn bộ danh sách (không truyền employeeIds)
   * - Download theo các cột (có thứ tự)
   * - Download theo các bản ghi được chọn
   * Author: txphuc (27/07/2023)
   */
  downloadExcel(excelExportSheets = [], employeeIds = []) {
    const url = `${rootUrl}/Excel/Export`;
    const data = {
      EntityIds: employeeIds,
      ExcelExportSheets: excelExportSheets,
    };

    return axiosClient.post(url, data, {
      responseType: "arraybuffer",
    });
  },
};

export default employeeApi;
