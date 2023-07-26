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
  delete(data) {
    const url = `${rootUrl}`;
    return axiosClient.delete(url, {
      data: data,
    });
  },
  deleteById(id) {
    const url = `${rootUrl}/${id}`;
    return axiosClient.delete(url);
  },
  getNewCode() {
    const url = `${rootUrl}/NewCode`;
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
  downloadExcel(columns = [], employeeIds = []) {
    const url = `${rootUrl}/Excel/Export`;
    const data = {
      entityIds: employeeIds,
      columns: columns,
    };

    return axiosClient.post(url, data, {
      responseType: "arraybuffer",
    });
  },
};

export default employeeApi;
