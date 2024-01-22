<script>
import { ref, onMounted } from 'vue';
//import Name from '@/components/Name.vue';

export default {
    setup() {
        // ref를 사용하여 지도를 담을 변수를 생성합니다.
        const map = ref(null);

        // onMounted 훅을 사용하여 컴포넌트가 마운트된 후에 실행할 코드를 작성합니다.
        onMounted(() => {
            // Naver 지도 API 스크립트를 동적으로 로드
            const script = document.createElement('script');
            script.src = 'https://oapi.map.naver.com/openapi/v3/maps.js?ncpClientId=' + import.meta.env.VITE_NAVER_C_KEY
            // script.async = false;
            // script.defer = false;
            document.head.appendChild(script);

            script.onload = () => {
                // Naver 지도 API 스크립트 로드 후 실행될 코드
                initializeMap();
            };
        });

        // 실제 지도 초기화 코드를 함수로 작성
        const initializeMap = () => {
            const mapOptions = {
                center: new window.naver.maps.LatLng(37.5665, 126.9780), // 초기 중심 좌표
                zoom: 16, // 초기 확대 수준
            };

            // this.$refs.map은 Vue에서 ref로 지정한 요소에 대한 참조를 제공합니다.
            const mapDiv = map.value; // ref에서 실제 DOM 요소를 가져옵니다.

            console.log(mapDiv);

            //new window.naver.maps.Map(mapDiv);
            new naver.maps.Map(mapDiv, mapOptions);
        };

        // 컴포넌트에서 반환할 것들을 객체로 정의합니다.
        return {
            map,
        };
    },
};
</script>

<template>
    <div ref="map"></div>
</template>

<style scoped>
    .map {
        width:100%;
        height: 600px;
    }
</style>