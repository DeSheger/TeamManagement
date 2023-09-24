<script setup>
import Menu from '@/components/menu/Menu.vue'
import Content from '@/layouts/Content.vue'
</script>

<template>
    <main>
        <div id="main" class="flex flex-col bg-stone-900">
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
main {
    min-height: 100vh;
    height: auto;
}
div {
    min-height: 100vh;
    height: auto;
}
</style>