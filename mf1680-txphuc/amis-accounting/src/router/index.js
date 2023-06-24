import { createRouter, createWebHistory } from "vue-router";

import TheDefaultLayout from "../components/layout/default-layout/TheDefaultLayout.vue";
import TheEmptyLayout from "../components/layout/empty-layout/TheEmptyLayout.vue";

import EmployeeList from "../views/employee/EmployeeList.vue";
import NotFound from "../views/notfound/NotFound.vue";

const routes = [
  { path: "/", component: EmployeeList, meta: { layout: TheDefaultLayout } },
  { path: "/:pathMatch(.*)*", component: NotFound, meta: { layout: TheEmptyLayout } }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
