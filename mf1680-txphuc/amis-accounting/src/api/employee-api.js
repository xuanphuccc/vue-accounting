import axiosClient from "./axios-client";

const employeeApi = {
  getAll() {
    const url = "/Employees";
    return axiosClient.get(url);
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
};

export default employeeApi;
