<script setup>
import Header from './Header.vue';
import MapMain from './MapMain.vue';
</script>

<template>
    <Header />

    <div id="layoutSidenav">
        <div id="layoutSidenav_nav">
            <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                <div class="sb-sidenav-menu">
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
                    <MapMain />
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