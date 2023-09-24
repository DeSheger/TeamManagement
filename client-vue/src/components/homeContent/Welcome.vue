<template>
    <div class="w-full h-auto">
        <div id="welcome__content" class="flex flex-col bg-stone-900 items-center justify-center">
            <h1> TeamManagement</h1>
            <h2> Start organise your company with TeamManagement Toolkit</h2>
            <ul class="flex flex-row justify-center">
                <li>Get Started</li>
                <router-link :to="{ name: 'authentication' }">
                    <li>Register Now</li>
                </router-link>
            </ul>
        </div>
    </div>
</template>

<style scoped>
#welcome__content {
    width: 100%;
    height: auto;
    min-height: 500px;
}

h1 {
    font-weight: bold;
    font-size: 33px;
    padding-bottom: 0 10px;
    text-align: center;
    padding: 16px 0;
    animation: menu 4s infinite;
}

h2 {
    font-size: 25px;
    text-align: center;
    padding: 16px 0
}

ul>a {
    padding: 4px;
    margin: 4px;
    color: #0f766e;
    border: 1px solid #0f766e;
}

ul>a:hover {
    border: 1px solid #04ffea;
    color: #04ffea;
    cursor: pointer;
}

@keyframes menu {
    0% {
        color: #0f766e;
    }

    50% {
        color: #04ffea;
    }

    100% {
        color: #0f766e;
    }
}
</style>