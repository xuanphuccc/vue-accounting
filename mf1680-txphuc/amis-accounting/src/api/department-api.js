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
};

export default departmentApi;
