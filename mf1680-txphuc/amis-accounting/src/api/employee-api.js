import axiosClient from "./axios-client";

const rootUrl = "/Employees";

const employeeApi = {
  getAll() {
    const url = rootUrl;
    return axiosClient.get(url);
  },
  get(employeeId) {
    const url = `${rootUrl}/${employeeId}`;
    return axiosClient.get(url);
  },
  filter(params = {}) {
    const url = `${rootUrl}/filter`;
    return axiosClient.get(url, {
      params: params,
    });
  },
  delete(id) {
    const url = `${rootUrl}/${id}`;
    return axiosClient.delete(url);
  },
  getNewCode() {
    const url = `${rootUrl}/NewEmployeeCode`;
    return axiosClient.get(url);
  },
  create(data) {
    const url = rootUrl;
    return axiosClient.post(url, data);
  },
  update(id, data) {
    const url = `${rootUrl}/${id}`;
    return axiosClient.put(url, data);
  },
};

export default employeeApi;
