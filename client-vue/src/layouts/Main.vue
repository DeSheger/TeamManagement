<script setup>
import Menu from '@/components/menu/Menu.vue'
import Content from '@/layouts/Content.vue'
</script>

<template>
    <main>
        <Menu />
        <Content>
        <slot name="main">
            <!-- page content -->
        </slot>
        </Content>
    </main>
</template>

<style scoped>
    main{
        min-height: 100vh;
    }
</style>