<script setup>
    import Main from '@/layouts/Main.vue'
    import AuthenticationHandler from '@/components/AuthenticationHandler/AuthenticationHandler.vue'
</script>

<template>
    <Main>
        <template #main>
            <AuthenticationHandler :login="false"/>
        </template>
    </Main>
</template>

<route lang="yaml">
    name: authentication
</route>