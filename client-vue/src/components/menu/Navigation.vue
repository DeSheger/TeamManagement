<script setup>
</script>

<template>
        <ol class="lg:flex col-span-3 flex flex-row justify-center lg:gap-x-8 xl:gap-x-10 hidden">
            <router-link :to="{name: 'home'}"><li>Home</li></router-link>
            <router-link :to="{name: 'docs'}"><li>Docs</li></router-link>
            <li>Profile</li>
            <li>Companies</li>
        </ol>
</template>

<style scoped>
ol {
    font-weight: bold;
}

ol>li {
    cursor: pointer;
}

ol>li:hover {
    color: gray;
}
</style>