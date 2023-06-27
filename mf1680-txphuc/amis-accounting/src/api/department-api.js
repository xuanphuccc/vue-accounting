import axiosClient from "./axios-client";

const departmentApi = {
  getAll() {
    const url = `/Departments`;
    return axiosClient.get(url);
  },
};

export default departmentApi;
