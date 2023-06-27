import axiosClient from "./axios-client";

const positionApi = {
  getAll() {
    const url = `/Positions`;
    return axiosClient.get(url);
  },
};

export default positionApi;
