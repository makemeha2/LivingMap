<script setup>
import { ref, onMounted } from 'vue';
import LeftSideNav from './LeftSideNav.vue';

//const currentPath = ref($route.path);

//console.log(currentPath);

</script>

<template>
    <div id="layoutSidenav">
        <LeftSideNav>
            <div class="nav">
                <div class="sb-sidenav-menu-heading">지도 구분</div>
                <a class="nav-link" href="index.html">
                    <div class="sb-nav-link-icon"><i class="fa-solid fa-shirt"></i></div>
                    의류수거함
                </a>
                <a class="nav-link" href="index.html">
                    <div class="sb-nav-link-icon"><i class="fa-solid fa-battery-empty"></i></div>
                    폐건전지
                </a>
                <a class="nav-link" href="index.html">
                    <div class="sb-nav-link-icon"><i class="fa-solid fa-smoking"></i></div>
                    흡연구역
                </a>
            </div>
        </LeftSideNav>
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