
import { relative } from 'path';
<template>
    <div class="w-full h-full">
        <div id="welcome__content" class="flex flex-col h-max bg-stone-900">
            <h1> TeamManagement</h1>
                    <h2> Start organise your company with TeamManagement Toolkit</h2>
                    <ul class="flex flex-row justify-center">
                        <li>Get Started</li>
                        <li>Register Now</li>
                    </ul>
        </div>
        <p></p>
    </div>
</template>

<style scoped>
#welcome__content {
    width: 100%;
    position: relative;
    top:25%;
    min-height:300px;
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

ul > li {
    padding: 4px;
    margin: 4px;
    color: #0f766e;
    border: 1px solid #0f766e;
}

ul > li:hover {
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