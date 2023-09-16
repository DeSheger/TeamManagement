<script setup>
    useHead({
        title: "Main"
    });
</script>

<template>
    <div>Hello main</div>
    <router-link :to="{ name: 'home' }">Home</router-link>
</template>

<route lang="yaml">
    name: main
</route>