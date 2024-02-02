// router.js 는 실제로 이 구성요소를 바탕으로 router 인스턴스를 생성하는데 사용된다. 

import { createRouter, createWebHistory } from "vue-router";
import routes from "./routes";

export const router = createRouter({
    history: createWebHistory(),
    linkActiveClass: 'active',
    routes,
})