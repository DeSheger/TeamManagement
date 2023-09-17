<script setup>

</script>

<template>
    <nav class="grid grid-cols-5 gap-2 bg-cyan-900 
    text-white justify-center items-center h-16 lg:bg-black">
        <h1>TeamManagement</h1>
        <ul class="col-start-2 col-end-4 flex flex-direction-row justify-around">
            <li>Home</li>
            <li>Profile</li>
            <li>Docs</li>
            <li>Companies</li>
        </ul>
        <form class="col-start-4 col-end-5 flex flex-direction-row justify-around">
            <input type="text" /> 
            <button>Search</button>
        </form>
        <div>
            Log In / Register
        </div>
    </nav>
</template>

<style scoped>
    h1 {
        font-size: x-large;
        width: 100%;
        text-align: center;
    }

    input {
        width: auto;
    }

    ul {
        width: 100%;
        
    }

    div {
        text-align: center;
    }
</style>