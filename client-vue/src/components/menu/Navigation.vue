<script setup>
</script>

<template>
    <ol class="lg:flex col-span-3 flex flex-row justify-center lg:gap-x-8 xl:gap-x-10 hidden">
        <router-link :to="{ name: 'home' }">
            <li>Home</li>
        </router-link>
        <router-link :to="{ name: 'docs' }">
            <li>Docs</li>
        </router-link>
        <router-link :to="{ name: 'home' }">
            <li>Profile</li>
        </router-link>
        <router-link :to="{ name: 'docs' }">
            <li>Companies</li>
        </router-link>
    </ol>
</template>

<style scoped>
ol {
    box-sizing: content-box;
}

ol>a {
    box-sizing: content-box;
    cursor: pointer;
    padding: 5px 0;
    border-bottom: 1px solid #1c1917;
}

ol>a:hover {
    animation: menuHover 1s;
    text-decoration: none;
    color: #0f766e;
    border-bottom: 1px solid #0f766e;
}

@keyframes menuHover {
    from {
        color: white;
        border-bottom: 1px solid #1c1917;
    }

    to {
        text-decoration: none;
        color: #0f766e;
        border-bottom: 1px solid #0f766e;
    }
}</style>