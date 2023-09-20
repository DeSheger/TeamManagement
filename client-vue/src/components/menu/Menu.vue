<script setup>
import Navigation from '@/components/menu/Navigation.vue';
import Logo from '@/components/menu/Logo.vue';
import Search from '@/components/menu/Search.vue';
import Smmenu from '@/components/menu/Smmenu.vue';

const SearchedValue = ref("");

watch(SearchedValue, () => {
    console.log(SearchedValue.value)
})

</script>

<template>
    <nav class="grid grid-cols-5 gap-2 bg-cyan-800 
    text-white h-16 items-center">
        <Logo />
        <Navigation />
        <Search :SearchedValue="SearchedValue" @ChangeValue="(newValue) => SearchedValue = newValue"/>

        <Smmenu :SearchedValue="SearchedValue" @ChangeValue="(newValue) => SearchedValue = newValue"/>
    </nav>
</template>

<style scoped>
nav {
    box-shadow: 0px 3px 3px gray;
}
</style>