<script>
import { ref, onMounted, inject } from 'vue';
import { useRoute } from 'vue-router';
import useAxios from '../modules/axios.js';

export default {
    setup(props) {
        let defaultCoords = { "latitude": "37.576651347", "longitude": "126.922727676" };
        let map = ref(null);

        // ref를 사용하여 지도를 담을 변수를 생성합니다.
        const mapElement = ref(null);
        const errorMessage = ref(null);
        const naverMapService = inject('naverMapService');
        //const defaultCoords = { "latitude" : "37.5259136", "longitude" : "126.9858304" };
        const route = useRoute();
        const level2Text = ref('');

        const { axiosGet } = useAxios();

        onMounted(() => {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(
                    position => {
                        //defaultCoords = { "latitude": position.coords.latitude, "longitude": position.coords.longitude}
                    },
                    error => {
                        errorMessage.value = '위치 정보를 가져오는 데 실패했습니다: ' + error.message;
                    }
                );
            } else {
                errorMessage.value = 'Geolocation이 지원되지 않는 브라우저입니다.';
            }

            initializeMap(defaultCoords.latitude, defaultCoords.longitude);
        });

        const initializeMap = (latitude, longitude) => {
            var mapOptions = {
                center: new naver.maps.LatLng(latitude, longitude),
                zoom: 18
            };

            map.value = new naver.maps.Map(`${mapElement.value.id}`, mapOptions);

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

                level2Text.value = response.v2.results[0].region.area2.name;

                axiosGet(`/api/Map/${route.params.div}?level2=${level2Text.value}`,
                    (response) => {
                        // 마커 생성
                        response.forEach((item) => {

                            let icon = {
                                url: '/src/assets/img/marker-default.png',
                                size: new naver.maps.Size(24, 37),
                                // anchor: new naver.maps.Point(12, 37),
                                // origin: new naver.maps.Point(i * 29, 0)
                            };

                            let marker = new naver.maps.Marker({
                                position: new naver.maps.LatLng(item.x, item.y),
                                map: map.value,
                                icon: icon
                            });

                            marker.addListener('click', onMarkerClick);
                        });

                        // 나의 위치정보 표시
                        new naver.maps.Marker({
                            position: new naver.maps.LatLng(defaultCoords.latitude, defaultCoords.longitude),
                            map: map.value,
                            icon: {
                                url: '/src/assets/img/myLocation.png',
                                size: new naver.maps.Size(24, 37),
                            }
                        });
                    },
                    (error) => {
                        console.log(error);
                    }
                );
            });
        };

        let onMarkerClick = (e) => {
            let marker = e.overlay;

            //console.log(marker.position.x, marker.position.y, e);


            //https://localhost:7141/api/Map/coord?X=37.882795359&Y=127.737557849

            let locationInfo = null;
            axiosGet(`/api/map/coord?x=${marker.position.y}&y=${marker.position.x}`,
                (response) => {
                    
                    locationInfo = { status: 'ok', message: '', ...response };
                    console.log('success : ', locationInfo);
                    createModal(locationInfo, marker);
                },
                (error) => {
                    console.log('fail : ', error);
                    locationInfo = { status: 'fail', message: error }
                    createModal(locationInfo);
                }
            );

            const createModal = (data, marker) => {
                let infowindow = new naver.maps.InfoWindow({
                    /*
                    content:
                        [
                            '<div class="modal-dialog modal-dialog-centered" id="exampleModal" aria-labelledby="exampleModalLabel" aria-hidden="true">'
                            , '    <div class="modal-dialog">'
                            , '        <div class="modal-content">'
                            , '        <div class="modal-header">'
                            //, '            <h5 class="modal-title" id="exampleModalLabel">' + data.status == 'ok' ? 'Info' : 'Error' + '</h5>'
                            , '            <h5 class="modal-title" id="exampleModalLabel">Info</h5>'
                            , '            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>'
                            , '        </div>'
                            , '        <div class="modal-body">'
                            //, data.status == 'ok' ? data.metaAddress : '주소를 읽어올 수 없습니다.'
                            , '주소를 읽어올 수 없습니다.'
                            , '        </div>'
                            , '        <div class="modal-footer">'
                            , '            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>'
                            , '            <button type="button" class="btn btn-primary">신고하기</button>'
                            , '        </div>'
                            , '        </div>'
                            , '    </div>'
                            , '</div>'
                        ].join(''),
                        */

                        
                        
                        content: 
                        [
                            '<div class="iw_inner">',
                            '   <h3>' + (data.status == 'ok' ? 'Info' : 'Error') + '</h3>',
                            '   <p>'+ (data.status == 'ok' ? data.metaAddress : '주소를 읽어올 수 없습니다.') + '<br />',
                            '   <b>'+ data.detail +'</b><br />',
                            '   <div class="buttons">',
                            '       <button class="save">저장</button>',
                            //'       <button class="cancel">취소</button>',
                            '   </div>',
                            '   </p>',
                            '</div>'
                        ].join('')
                        
                });

                if (infowindow.getMap()) {
                    infowindow.close();
                } else {
                    infowindow.open(map.value, marker);
                }   
            }
        }

        // 컴포넌트에서 반환할 것들을 객체로 정의합니다.
        return {
            mapElement,
            level2Text
        };
    },
};
</script>

<template>
    <div class="col-md-12" ref="mapElement" id="map" style="flex: 1;width: 100%; height: 100vh;"></div>
</template>