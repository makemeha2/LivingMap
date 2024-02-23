
<script setup>
import { ref } from 'vue'
import { googleSdkLoaded  } from 'vue3-google-login'
import useAxios from '../modules/axios.js';

const { axiosGet, axiosPost } = useAxios();

const userDetails = ref(null);

const googleLogin = () => {
    googleSdkLoaded(google => {
        google.accounts.oauth2.initCodeClient({
            client_id: import.meta.env.VITE_APP_GOOGLE_CLIENT_ID,
            scope: "email profile openid",
                redirect_uri: `${import.meta.env.VITE_CALLBACK_URL}/login`,
                callback: response => {
                    if (response.code) {
                        sendCodeToBackend(response.code);
                    }
                }
        }).requestCode();
    });
}

const sendCodeToBackend = (callbackCode) => {
    try {
        const headers = {
            'Content-Type': 'application/json'
        };
        const response = axiosPost('/api/oauth/google/userInfo', callbackCode,
            (response) => {
                console.log('response', response);
            },
            (fail) => {
                console.log('error', error);    
            }
        );
    } catch (error) {
        console.log('error', error);
    }
}

</script>

<template>
    <main>
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-5">
                    <div class="card shadow-lg border-0 rounded-lg mt-5">
                        <div class="card-header">
                            <h3 class="text-center font-weight-light my-4">Login</h3>
                        </div>
                        <div class="card-body">
                            <form>
                                <div class="form-floating mb-3">
                                    <input class="form-control" id="inputEmail" type="email"
                                        placeholder="name@example.com" />
                                    <label for="inputEmail">Email address</label>
                                </div>
                                <div class="form-floating mb-3">
                                    <input class="form-control" id="inputPassword" type="password" placeholder="Password" />
                                    <label for="inputPassword">Password</label>
                                </div>
                                <div class="form-check mb-3">
                                    <input class="form-check-input" id="inputRememberPassword" type="checkbox" value="" />
                                    <label class="form-check-label" for="inputRememberPassword">Remember Password</label>
                                </div>
                                <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                    <a class="small" href="password.html">Forgot Password?</a>
                                    <a class="btn btn-primary" href="index.html">Login</a>
                                </div>
                            </form>
                        </div>
                        <div class="card-footer text-center py-3">
                            <div class="small"><a href="register.html">Need an account? Sign up!</a></div>
                        </div>
                        <div class="card-footer text-center py-3">
                            <a href="#" @click="googleLogin">
                                <img src="/src/assets/img/login_icon_google.png" width="40" alt="google Login" />
                            </a> &nbsp;
                            <a href="#" class="login-icon" ><img src="/src/assets/img/login_icon_naver.png" width="40" alt="naver Login" /></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</template>



<style scoped>
    .login-icon {
        cursor: pointer;
    }
/* Add your custom styles here */</style>
