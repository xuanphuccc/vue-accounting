import axiosClient from "./axios-client";

const rootUrl = "/Departments";

const departmentApi = {
  /**
   * Description: Lấy danh sách toàn bộ đơn vị
   * Author: txphuc (27/07/2023)
   */
  getAll() {
    const url = rootUrl;
    return axiosClient.get(url);
  },

  /**
   * Description: Xoá danh sách đơn vị theo Id
   * Author: txphuc (27/07/2023)
   */
  delete(data) {
    const url = `${rootUrl}`;
    return axiosClient.delete(url, {
      data: data,
    });
  },

  /**
   * Description: Xoá đơn vị theo Id
   * Author: txphuc (27/07/2023)
   */
  deleteById(id) {
    const url = `${rootUrl}/${id}`;
    return axiosClient.delete(url);
  },
};

export default departmentApi;
