<script setup>
import Menu from '@/components/menu/Menu.vue'
import Content from '@/layouts/Content.vue'
</script>

<template>
    <main>
        <div class="flex flex-col">
            <Menu />
            <Content>
                <template #main>
                    <slot name="main">
                        <!-- page content -->
                    </slot>
                </template>
            </Content>
        </div>
    </main>
</template>

<style scoped>
div {
    height: 100vh;
}
</style>