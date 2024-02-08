<script setup>
import { ref, onMounted, inject } from 'vue';

const onLeftMenuClicked = defineEmits(['menuClicked']);

onLeftMenuClicked('menuClicked', (menu) => {
    console.log('at child : ' + menu);
});

</script>

<template>
    <div id="layoutSidenav_nav">
        <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
            <div class="sb-sidenav-menu">
                <div class="nav">
                    <div class="sb-sidenav-menu-heading">지도 구분</div>
                    <a class="nav-link" href="#">
                        <div class="sb-nav-link-icon"><i class="fa-solid fa-shirt"></i></div>
                        의류수거함
                    </a>
                    <a class="nav-link" href="#">
                        <div class="sb-nav-link-icon"><i class="fa-solid fa-battery-empty"></i></div>
                        폐건전지
                    </a>
                    <a class="nav-link" href="#">
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
</template>