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
    return axiosClient.get(url, {
      params: params,
    });
  },

  /**
   * Description: Xoá danh sách nhân viên theo Id
   * Author: txphuc (27/07/2023)
   */
  delete(data) {
    const url = `${rootUrl}`;
    return axiosClient.delete(url, {
      data: data,
    });
  },

  /**
   * Description: Xoá nhân viên theo Id
   * Author: txphuc (27/07/2023)
   */
  deleteById(id) {
    const url = `${rootUrl}/${id}`;
    return axiosClient.delete(url);
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
   * Description: Tạo một nhân viên mới
   * Author: txphuc (27/07/2023)
   */
  create(data) {
    const url = rootUrl;
    return axiosClient.post(url, data);
  },

  /**
   * Description: Cập nhật một nhân viên theo Id
   * Author: txphuc (27/07/2023)
   */
  update(id, data) {
    const url = `${rootUrl}/${id}`;
    return axiosClient.put(url, data);
  },

  /**
   * Description: Download Excel
   * - Download toàn bộ danh sách (không truyền employeeIds)
   * - Download theo các cột (có thứ tự)
   * - Download theo các bản ghi được chọn
   * Author: txphuc (27/07/2023)
   */
  downloadExcel(columns = [], employeeIds = []) {
    const url = `${rootUrl}/Excel/Export`;
    const data = {
      entityIds: employeeIds,
      columns: columns,
    };

    return axiosClient.post(url, data, {
      responseType: "arraybuffer",
    });
  },
};

export default employeeApi;
