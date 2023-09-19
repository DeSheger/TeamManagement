<script setup>
const searchValue = ref("")
const display = ref(false)
const displayHandler = () => {
    display.value = !display.value;
}

</script>

<template>
    <nav class="grid grid-cols-5 gap-2 bg-cyan-800 
    text-white h-16 items-center">
        <h1 class="col-span-2 lg:col-span-1">TeamManagement</h1>
        <ol class="lg:flex col-span-3 flex flex-row justify-center lg:gap-x-8 xl:gap-x-10 hidden">
            <li>Home</li>
            <li>Docs</li>
            <li>Profile</li>
            <li>Companies</li>
        </ol>
        <form class="lg:flex col-span-1 hidden">
            <input type="text" v-model="searchValue" />
            <button>Search</button>
        </form>

        <button class="lg:hidden col-start-5" @click="displayHandler">||| </button>
        <ul v-if="display" class="lg:hidden">
            <li>
                <form class="flex col-span-1">
                    <input type="text" v-model="searchValue" />
                    <button>Search</button>
                </form>
            </li>
            <li>
                <ol class="flex flex-col justify-center">
                    <li>Home</li>
                    <li>Docs</li>
                    <li>Profile</li>
                    <li>Companies</li>
                </ol>
            </li>
        </ul>
    </nav>
</template>

<style scoped>
nav {
    box-shadow: 0px 3px 3px gray;
}

h1 {
    font-weight: bold;
    font-size: larger;
    padding: 0 10px;
}

ol {
    font-weight: bold;
}

ol>li {
    cursor: pointer;
}

ol>li:hover {
    color: gray;
}

form {}

form>input {
    width: 140px;
    margin: 0 5px;
    height: 1.8rem;
    color: black;
    border-radius: 4px;
}

form>button {

    margin: 0 5px;
    font-weight: bold;

}

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
    from {transform: translate(0px,10px);}
    to {transform: translate(0px,0);}
}
</style>