<script setup>
import Footer from '@/components/Footer/Footer.vue'
</script>

<template>
    <div id="content" class="flex bg-stone-900 text-white flex-col">
        <slot name="main">
            No Content
        </slot>
        <Footer />
    </div>
</template>

<style scoped>
div {
    min-height: 100vh;
    height: auto;
    padding-bottom: 16px;
}
</style>