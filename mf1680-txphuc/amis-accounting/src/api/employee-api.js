import axiosClient from "./axios-client";

const employeeApi = {
  getAll() {
    const url = "/Employees";
    return axiosClient.get(url);
  },
};

export default employeeApi;
