<script setup>

const menus = [
    { key: 'home', value: 'Home', url:'/home', },
    { key: 'Intro', value: 'Intro', url:'/intro', },
    { key: 'Hello', value: 'Hello', url:'/hello', },
]

// click event handler
const onClick = () => {
    document.body.classList.toggle('sb-sidenav-toggled');
}

</script>

<template>
    <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
        <!-- Navbar Brand-->
        <a class="navbar-brand ps-3" href="index.html">Living Map</a>
        <!-- Sidebar Toggle-->
        <button class="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" @click.prevent="onClick"><i
                class="fas fa-bars" ></i></button>
        <!-- <a class="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" @click.prevent="onClick"><i
                class="fas fa-bars"></i></a> -->
        
        <ul class="navbar-nav">
            <li class="nav-item" v-for="menu_object in menus" :key="menu_object.key" >
                <router-link :to="menu_object.url" class="nav-link" >{{menu_object.value}}</router-link>
            </li>
        </ul>     

        <!-- Navbar Search-->
        <form class="d-none d-md-inline-block form-inline ms-auto me-0 me-md-3 my-2 my-md-0">
            <div class="input-group">
                <input class="form-control" type="text" placeholder="Search for..." aria-label="Search for..."
                    aria-describedby="btnNavbarSearch" />
                <button class="btn btn-primary" id="btnNavbarSearch" type="button"><i class="fas fa-search"></i></button>
            </div>
        </form>
        <!-- Navbar-->
        <ul class="navbar-nav ms-auto ms-md-0 me-3 me-lg-4">
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown"
                    aria-expanded="false"><i class="fas fa-user fa-fw"></i></a>
                <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                    <li><a class="dropdown-item" href="#!">Settings</a></li>
                    <li><a class="dropdown-item" href="#!">Activity Log</a></li>
                    <li>
                        <hr class="dropdown-divider" />
                    </li>
                    <li><a class="dropdown-item" href="#!">Logout</a></li>
                </ul>
            </li>
        </ul>
    </nav>
</template>