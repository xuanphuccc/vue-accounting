import Vue from "vue";
import VueRouter from "vue-router";
import EmployeeList from "@/views/employee/EmployeeList.vue";
import EmployeeManagerList from "@/views/employee-manager/EmployeeManagerList.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: null,
    meta: { layout: "default" },
  },
  {
    path: "/employee",
    name: "employee",
    component: EmployeeList,
    meta: { layout: "default" },
  },
  {
    path: "/manage-license",
    name: "manage-license",
    component: EmployeeManagerList,
    meta: { layout: "default" },
  },
  { path: "*", component: null, meta: { layout: "empty" } },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
