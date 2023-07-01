import axiosClient from "./axios-client";

const employeeApi = {
  getAll() {
    const url = "/Employees";
    return axiosClient.get(url);
  },
  filter(params = {}) {
    const url = "/Employees/filter";
    return axiosClient.get(url, {
      params: params,
    });
  },
  delete(id) {
    const url = `/Employees/${id}`;
    return axiosClient.delete(url);
  },
  getNewCode() {
    const url = `/Employees/NewEmployeeCode`;
    return axiosClient.get(url);
  },
  create(data) {
    const url = `/Employees`;
    return axiosClient.post(url, data);
  },
  update(id, data) {
    const url = `/Employees/${id}`;
    return axiosClient.put(url, data);
  },
};

export default employeeApi;
