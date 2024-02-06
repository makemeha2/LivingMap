<script setup>
import { computed, provide } from 'vue';
import Container from './components/Container.vue'
import Header from './components/Header.vue'
import { useRoute } from 'vue-router'

const route = useRoute();

const isShowLeft = computed(() => {
  return route.path === '/' || route.path === '/home' ? true : false;
});

const menus = [
    { key: 'home', value: 'Home', url:'/home', },
    { key: 'Intro', value: 'Intro', url:'/intro', },
    { key: 'Hello', value: 'Hello', url:'/hello', },
]

provide('menus', menus)

</script>

<template>
  <body :class="{ 'sb-sidenav-toggled' : !isShowLeft }">
    <p>{{ route.path }}</p>
    <Header />
    <Container />
  </body>
</template>

<style scoped>
.map {
  width: 1000px;
  height: 600px;
}
</style>
