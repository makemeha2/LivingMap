// routes.js 파일은 router의 구성요소를 가진다. 

import HelloWorld from '../components/HelloWorld.vue'
import { defineComponent } from 'vue'

const NotFound = defineComponent({
    template: `
        <div>
            <h1>404 - Not Found</h1>
        </div>
    `
});

const routes = [    
    { path: '/', component: HelloWorld },
    { path: '/:pathMatch(.*)*', name: 'NotFound', component: NotFound }
]