<script setup>
import { decodeCredential } from 'vue3-google-login'

const callback = (response) => {
  // This callback will be triggered when the user selects or login to
  // his Google account from the popup
  const userData = decodeCredential(response.credential)
  console.log("Handle the userData", userData)
  console.log("Handle the userData.email", userData.email)
}
</script>

<template>
  <GoogleLogin :callback="callback"/>
</template>