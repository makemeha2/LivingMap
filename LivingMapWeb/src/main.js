import { createApp } from 'vue'
import { router } from './router/router.js'
import './style.css'
//import './js/scripts.js'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap/dist/js/bootstrap.esm.min.js'

import App from './App.vue'

//console.log(process.env.VUE_APP_NAVER_CLIENT_KEY);

const app = createApp(App);
app.use(router); 
app.mount('#app');
