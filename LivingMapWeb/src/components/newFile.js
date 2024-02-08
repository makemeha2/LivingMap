import { ref, onMounted, inject } from 'vue';
import { useRoute } from 'vue-router';
import { axiosGet } from '../modules/axios.js';

export default (await import('vue')).defineComponent({
setup(props) {
// ref를 사용하여 지도를 담을 변수를 생성합니다.
const mapElement = ref(null);
const errorMessage = ref(null);
const naverMapService = inject('naverMapService');
//const defaultCoords = { "latitude" : "37.5259136", "longitude" : "126.9858304" };
const defaultCoords = { "latitude": "37.576651347", "longitude": "126.922727676" };
const route = useRoute();
const level2Text = ref('');

//console.log(route, route.path, route.params.div);
onMounted(() => {

if (navigator.geolocation) {
navigator.geolocation.getCurrentPosition(
position => {
//initializeMap(position.coords.latitude, position.coords.longitude);
initializeMap(defaultCoords.latitude, defaultCoords.longitude);
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

const initializeMap = (latitude, longitude) => {

var mapOptions = {
center: new naver.maps.LatLng(latitude, longitude),
zoom: 15
};

var map = new naver.maps.Map(`${mapElement.value.id}`, mapOptions);

// 중요 코드
naver.maps.Event.addListener(map, 'click', function (e) {
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
level2Text.value = response.v2.results[0].region.area2.name;

axiosGet(`/https://localhost:7141/api/Map/${route.params.div}?level2=${level2Text.value}`,
(response) => {
console.log(response);
},
(error) => {
console.log(error);
}
);
});
};



// 컴포넌트에서 반환할 것들을 객체로 정의합니다.
return {
mapElement,
level2Text
};
},
});
