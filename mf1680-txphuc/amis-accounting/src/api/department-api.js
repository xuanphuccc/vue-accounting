import axiosClient from "./axios-client";

const rootUrl = "/Departments";

const departmentApi = {
  getAll() {
    const url = rootUrl;
    return axiosClient.get(url);
  },
};

export default departmentApi;
