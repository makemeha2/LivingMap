<script>
import { ref, onMounted, computed } from 'vue';
import { useCounterStore } from '../store/counter.js';
//import LeftSideNav from './leftsidenav.vue';

export default {
    name: 'Container',
    setup(props, { emit }) {
        const leftMenuList = [
            { key: 'clothes', value: '의류수거함', url:'/map/clothes', icon:'fa-shirt' },
            { key: 'battery', value: '폐건전지', url:'/map/battery', icon:'fa-battery-empty' },
            { key: 'smoking', value: '흡연구역', url:'/map/smoking', icon:'fa-smoking' },
        ]


        const onLeftMenuClicked = (menu) => {
            console.log('at Parent : ' + menu);
            emit('menuClicked', menu);
        }

        return {
            onLeftMenuClicked,
            leftMenuList,
        }
    },
    // components: {
    //     LeftSideNav
    // }
}

</script>

<template>
    <div id="layoutSidenav">
        <div id="layoutSidenav_nav">
            <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                <div class="sb-sidenav-menu">

                    <div class="nav" v-for="(menu, index) in leftMenuList" :key="menu.key" @click="onLeftMenuClicked(menu)">
                        <div v-if="index == 0" class="sb-sidenav-menu-heading">지도 구분</div>
                        <router-link :to="menu.url" class="nav-link" >
                            <div class="sb-nav-link-icon"><i :class="'fa-solid ' + menu.icon"></i></div>
                            {{menu.value}}
                        </router-link>
                    </div>
                    
                </div>
                <div class="sb-sidenav-footer">
                    <div class="small">Logged in as:</div>
                    Start Bootstrap
                </div>
            </nav>
        </div>

        <div id="layoutSidenav_content">
            <main>
                <div class="containter-fluid-custom main">
                    <router-view />
                </div>
            </main>
            <footer class="py-4 bg-light mt-auto">
                <div class="container-fluid px-4">
                    <div class="d-flex align-items-center justify-content-between small">
                        <div class="text-muted">Copyright &copy; Your Website 2023</div>
                        <div>
                            <a href="#">Privacy Policy</a>
                            &middot;
                            <a href="#">Terms &amp; Conditions</a>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </div>
</template>