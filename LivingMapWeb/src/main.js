import { createApp } from 'vue'
import { router } from './router/router.js'
import { createPinia } from 'pinia'
import vue3GoogleLogin from 'vue3-google-login'
import './style.css'
//import './js/scripts.js'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap/dist/js/bootstrap.esm.min.js'

import App from './App.vue'

//console.log(process.env.VUE_APP_NAVER_CLIENT_KEY);

// console.log('window', window);
// console.log('window.naver', window.naver);
// console.log('window.naver.maps', window.naver.maps);
// console.log('window.naver.maps.Service', window.naver.maps.Service);
// console.log('naver.maps.Service', naver.maps.Service);

var naverMapService = naver.maps.Service;

const app = createApp(App);
app.use(createPinia());
app.use(router); 
app.use(vue3GoogleLogin, { clientId: '804003243997-pp5313n2tiju5bgkracp3ua5b3s8fakk.apps.googleusercontent.com' })
app.provide('naverMapService', naverMapService);
app.mount('#app');
