// routes.js 파일은 router의 구성요소를 가진다. 

import Intro from '../components/Intro.vue'
import HelloWorld from '../components/HelloWorld.vue'
import MapMain from '../components/MapMain.vue'
import { defineComponent } from 'vue'

const NotFound = defineComponent({
    template: `
        <div>
            <h1>404 - Not Found</h1>
        </div>
    `
});

const routes = [    
    { path: '/', redirect: '/map' },
    { path: '/home', name: 'Home', component: MapMain },
    { path: '/map', name: 'Map', component: MapMain },
    { path: '/intro', name: 'Intro', component: Intro },
    { path: '/hello', name: 'HelloWorld', component: HelloWorld },
    { path: '/:catchAll(.*)', name: 'NotFound', component: NotFound },
    //{ path: '/:pathMatch(.*)*', name: 'NotFound', component: NotFound }
]

export default routes;