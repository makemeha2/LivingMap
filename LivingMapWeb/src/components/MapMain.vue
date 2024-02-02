<script>
import { ref, onMounted } from 'vue';

export default {
    setup() {
        // ref를 사용하여 지도를 담을 변수를 생성합니다.
        const mapElement = ref(null);

        onMounted(() => {

            const script = document.createElement('script');

            if (mapElement.value) {
                mapElement.value.id = 'map';
            }

            script.textContent = `
            var mapOptions = {
                center: new naver.maps.LatLng(37.3595704, 127.105399),
                zoom: 10
            };

            var map = new naver.maps.Map('${mapElement.value.id}', mapOptions);
            `;
            // body에 스크립트 추가
            document.body.appendChild(script);
        });

        // 컴포넌트에서 반환할 것들을 객체로 정의합니다.
        return {
            mapElement,
        };
    },
};
</script>

<template>
    <div class="col-md-12" ref="mapElement" id="map" style="flex: 1;width: 100%; height: 100vh;"></div>
</template>