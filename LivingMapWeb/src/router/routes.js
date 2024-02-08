// routes.js 파일은 router의 구성요소를 가진다. 

import Intro from '../components/Intro.vue'
import HelloWorld from '../components/HelloWorld.vue'
import MapMain from '../components/MapMain.vue'
import LeftSideNav from '../components/LeftSideNav.vue'
import { defineComponent } from 'vue'

const NotFound = defineComponent({
    template: `
        <div>
            <h1>404 - Not Found</h1>
        </div>
    `
});

const routes = [
    { path: '/', redirect: '/map/clothes' },
    { path: '/map/:div', name: 'Map', component: MapMain, props:true },
    { path: '/intro', name: 'Intro', component: Intro },
    { path: '/hello', name: 'HelloWorld', component: HelloWorld },
    {
        path: '/test', name: 'Test', component: {
            default: MapMain,
            secondComponent: LeftSideNav
        }
    },
    { path: '/:catchAll(.*)', name: 'NotFound', component: NotFound },
    //{ path: '/:pathMatch(.*)*', name: 'NotFound', component: NotFound }
]

export default routes;