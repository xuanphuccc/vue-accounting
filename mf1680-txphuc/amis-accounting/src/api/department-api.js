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
   * Description: Lấy một đơn vị theo Id
   * Author: txphuc (27/07/2023)
   */
  get(departmentId) {
    const url = `${rootUrl}/${departmentId}`;
    return axiosClient.get(url);
  },

  /**
   * Description: Lấy mã đơn vị mới
   * Author: txphuc (27/07/2023)
   */
  getNewCode() {
    const url = `${rootUrl}/NewCode`;
    return axiosClient.get(url);
  },

  /**
   * Description: Tạo một đơn vị mới
   * Author: txphuc (27/07/2023)
   */
  create(data) {
    const url = rootUrl;
    return axiosClient.post(url, data);
  },

  /**
   * Description: Cập nhật một đơn vị theo Id
   * Author: txphuc (27/07/2023)
   */
  update(id, data) {
    const url = `${rootUrl}/${id}`;
    return axiosClient.put(url, data);
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
