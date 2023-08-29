import axiosClient from "./axios-client";

const rootUrl = "/EmployeeRelationships";

const employeeRelationshipApi = {
  /**
   * Description: Lấy một thành viên gia đình theo Id
   * Author: txphuc (29/08/2023)
   */
  get(relationshipId) {
    const url = `${rootUrl}/${relationshipId}`;
    return axiosClient.get(url);
  },

  /**
   * Description: Xoá thành viên gia đình theo Id
   * Author: txphuc (29/08/2023)
   */
  delete(relationshipId) {
    const url = `${rootUrl}/${relationshipId}`;
    return axiosClient.delete(url);
  },

  /**
   * Description: Tạo một thành viên gia đình mới
   * Author: txphuc (29/08/2023)
   */
  create(relationship) {
    const url = rootUrl;
    return axiosClient.post(url, relationship);
  },

  /**
   * Description: Cập nhật một thành viên gia đình theo Id
   * Author: txphuc (29/08/2023)
   */
  update(relationshipId, relationship) {
    const url = `${rootUrl}/${relationshipId}`;
    return axiosClient.put(url, relationship);
  },
};

export default employeeRelationshipApi;
