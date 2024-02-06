<script>
import { ref, onMounted, inject } from 'vue';

export default {
    setup() {
        // ref를 사용하여 지도를 담을 변수를 생성합니다.
        const mapElement = ref(null);
        const errorMessage = ref(null);
        const naverMapService = inject('naverMapService');

        let defaultCoords = { "latitude" : "37.5259136", "longitude" : "126.9858304" };

        const initializeMap = (latitude, longitude) => {

            var mapOptions = {
                center: new naver.maps.LatLng(latitude, longitude),
                zoom: 15
            };

            var map = new naver.maps.Map(`${mapElement.value.id}`, mapOptions);

            // 중요 코드
            naver.maps.Event.addListener(map, 'click', function(e) {
                console.log(e.coord);
            });

            naverMapService.reverseGeocode({
                coords: mapOptions.center,
                orders: [
                    naverMapService.OrderType.ADDR,
                    naverMapService.OrderType.ROAD_ADDR
                ].join(',')
            }, function (status, response) {
                if (status === naverMapService.Status.ERROR) {
                    return alert('Something Wrong!');
                }

                console.log(response.v2.results);
            });
        };

        onMounted(() => {

            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(
                    position => {
                        initializeMap(position.coords.latitude, position.coords.longitude);
                    },
                    error => {
                        errorMessage.value = '위치 정보를 가져오는 데 실패했습니다: ' + error.message;
                        initializeMap(defaultCoords.latitude, defaultCoords.longitude);
                    }
                );
            } else {
                errorMessage.value = 'Geolocation이 지원되지 않는 브라우저입니다.';
                initializeMap(defaultCoords.latitude, defaultCoords.longitude);
            }
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