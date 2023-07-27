import axiosClient from "./axios-client";

const rootUrl = "/Positions";

const positionApi = {
  /**
   * Description: Lấy danh sách toàn bộ vị trí
   * Author: txphuc (27/07/2023)
   */
  getAll() {
    const url = rootUrl;
    return axiosClient.get(url);
  },
};

export default positionApi;
