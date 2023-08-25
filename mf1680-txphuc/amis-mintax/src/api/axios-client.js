import axios from "axios";
import enums from "@/enum/enum";
import store from "@/store";

// Create new instance
const axiosClient = axios.create({
  baseURL: "https://localhost:7047/api/v1",
  headers: {
    "Content-Type": "application/json",
    ContentLanguage: localStorage.getItem("lang") ?? enums?.language?.VN,
  },
});

// Add a request interceptor
axiosClient.interceptors.request.use(
  function (config) {
    // Do something before request is sent
    return config;
  },
  function (error) {
    // Do something with request error
    return Promise.reject(error);
  }
);

// Add a response interceptor
axiosClient.interceptors.response.use(
  function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data
    return response;
  },
  function (error) {
    // Any status codes that falls outside the range of 2xx cause this function to trigger
    // Do something with response error

    // Hiển thị dialog báo lỗi
    const userMessage = error.response?.data?.UserMessage ?? "Lỗi hệ thống, vui lòng thử lại sau";
    store.dispatch("dialogStore/showWarning", userMessage);

    return Promise.reject(error);
  }
);

export default axiosClient;
