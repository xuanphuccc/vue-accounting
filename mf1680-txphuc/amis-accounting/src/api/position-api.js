import axiosClient from "./axios-client";

const rootUrl = "/Positions";

const positionApi = {
  getAll() {
    const url = rootUrl;
    return axiosClient.get(url);
  },
};

export default positionApi;
