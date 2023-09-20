<script setup>

const props = defineProps({
    SearchedValue: String
});
const emit = defineEmits(["ChangeValue"])

const Value = ref(props.SearchedValue)

watch(Value, () => {

    emit('ChangeValue', Value.value)
})

watch(props, () => {
    Value.value = props.SearchedValue
})

const display = ref(false)
const displayHandler = () => {
    display.value = !display.value;
}

</script>

<template>
    <button class="lg:hidden col-start-5" @click="displayHandler">||| </button>
    <ul v-if="display" class="lg:hidden">
        <li>
            <form class="flex col-span-1">
                <input type="text" v-model="Value" />
                <button>Search</button>
            </form>
        </li>
        <li>
            <ol class="flex flex-col justify-center">
                <router-link :to="{ name: 'home' }">
                    <li>Home</li>
                </router-link>
                <router-link :to="{ name: 'docs' }">
                    <li>Docs</li>
                </router-link>
                <li>Profile</li>
                <li>Companies</li>
            </ol>
        </li>
    </ul>
</template>

<style scoped>
ul {
    position: absolute;
    top: 4.5rem;
    right: 5px;
    width: auto;
    height: auto;
    color: black;
    text-align: center;

    animation: menu 1s;
}

ul>li {
    box-shadow: 0px 0px 3px 2px gray;
    margin: 10px;
    padding: 4px;
    border-radius: 4px;
    background-color: white;
}

@keyframes menu {
    from {
        transform: translate(0px, 10px);
    }

    to {
        transform: translate(0px, 0);
    }
}
</style>