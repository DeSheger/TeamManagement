<script setup>
import Menu from '@/components/menu/Menu.vue'
</script>

<template>
    <main>
        <Menu />
        <slot name="main">
            <!-- page content -->
        </slot>
    </main>
</template>