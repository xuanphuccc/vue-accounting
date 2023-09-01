import Vue from "vue";
import VueRouter from "vue-router";
import EmployeeList from "@/views/employee/EmployeeList.vue";
import EmployeeManagerList from "@/views/employee-manager/EmployeeManagerList.vue";
import EmployeeDetail from "@/views/employee/EmployeeDetail.vue";
import EmployeeDetailView from "@/views/employee/EmployeeDetailView.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: null,
    meta: { layout: "default" },
  },

  // Danh sách nhân viên
  {
    path: "/employee",
    name: "employee",
    component: EmployeeList,
    meta: { layout: "default" },
  },

  // Xem chi tiết nhân viên
  {
    path: "/employee-detail-view/:id",
    name: "employee-detail-view",
    component: EmployeeDetailView,
    meta: { layout: "default" },
  },

  // Form thêm mới nhân viên
  {
    path: "/employee-detail-action",
    name: "employee-detail",
    component: EmployeeDetail,
    meta: { layout: "default" },
  },

  // Form sửa nhân viên
  {
    path: "/employee-detail-action/:id",
    name: "employee-detail-update",
    component: EmployeeDetail,
    meta: { layout: "default" },
  },

  // Danh sách lao động sử dụng dịch vụ
  {
    path: "/manage-license",
    name: "manage-license",
    component: EmployeeManagerList,
    meta: { layout: "default" },
  },

  // Not found
  { path: "*", component: null, meta: { layout: "empty" } },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
