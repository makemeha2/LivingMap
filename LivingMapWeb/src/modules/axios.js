import axios from 'axios';
import { ref } from 'vue';

export default function () {

    const headersConfig = {
        'Content-Type': 'application/json'
    };
    
    const commuicating = ref(false)

    const BASE_URL = 'https://localhost:7141';

    const creatURL = (url) => {
        return url.startsWith('http') ? url : BASE_URL + url
    }

    const checkResult = (resp, onSuccess, onFailed) => {
        commuicating.value = false
        if (resp.status === 200) {
            if (onSuccess) {
                onSuccess(resp.data)
            }
        } else {
            if (onFailed) {
                onFailed(resp.data)
            }
        }
    }

    const axiosGet = async (url, onSuccess = null, onFailed = null) => {
        commuicating.value = true
        axios.get(creatURL(url)).then((resp) => {
            checkResult(resp, onSuccess, onFailed)
        })
    }

    const axiosPost = async (url, data, onSuccess = null, onFailed = null) => {
        commuicating.value = true
        //console.log(headers);
        axios.post(creatURL(url), data, { headers: { 'Content-Type': 'application/json' } }).then((resp) => {
            checkResult(resp, onSuccess, onFailed)
        })
    }

    const axiosPut = async (url, data, onSuccess = null, onFailed = null) => {
        commuicating.value = true
        axios.put(creatURL(url), data, { headers: { 'Content-Type': 'application/json' } }).then((resp) => {
            checkResult(resp, onSuccess, onFailed)
        })
    }

    return {
        commuicating,
        axiosGet,
        axiosPost,
        axiosPut,
    }
}