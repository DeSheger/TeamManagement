<script setup>
    const props = defineProps({
        img: String,
        text: String,
        header: String,
        left: Boolean
    }
    )
</script>

<template>
    <div v-if="props.left" class="flex flex-col lg:flex-row h-auto bg-stone-900 items-center py-4">
        <div class="w-10/12 lg:w-1/2 flex justify-center items-center lg:hidden">
            <img class="w-max lg:w-3/4" :src="props.img" />
        </div>
        <p class="w-full lg:w-1/2">
            <h2>{{ props.header }}</h2>
            {{ props.text }}
        </p>
        <div class="w-10/12 lg:w-1/2 justify-center items-center hidden lg:flex">
            <img class="w-max lg:w-3/4" :src="props.img" />
        </div>
    </div>

    <div v-else class="flex flex-col lg:flex-row h-auto bg-stone-900 items-center py-4">
        <div class="w-10/12 lg:w-1/2 flex justify-center items-center">
            <img class="w-max lg:w-3/4" :src="props.img" />
        </div>
        <p class="w-full lg:w-1/2">
            <h2>{{ props.header }}</h2>
            {{ props.text }}
        </p>
    </div>
</template>

<style scoped>
img {
    border-radius: 10px;
    box-shadow: 0px 0px 3px 3px #0f766e;
}

h2 {
    font-size: 22px;
    padding: 12px 0;
    font-weight: bolder;
    color: #0f766e;
}

p {
    padding: 16px 16px;
    text-align: center;
    text-shadow: 1px 1px  #0f766e;
}
</style>