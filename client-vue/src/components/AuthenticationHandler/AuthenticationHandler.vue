
<script setup>
    const props = defineProps({
        login: Boolean 
    })
    const loginHandler = ref(props.login)
    console.log(props.login)

    const switchHandler = () => {
        loginHandler.value = !loginHandler.value
    }

</script>

<template>
    <form v-if="loginHandler" class="w-max flex justify-center flex-col">
        <input type="text" placeholder="Type Email" />
        <input type="password" placeholder="Type Password" />
        <button>Log In</button>
        <button @click.prevent="switchHandler">Or Register</button>
    </form>

    <form onsubmit="*" v-else class="w-max flex justify-center items-center flex-col ">
        <input type="text" placeholder="Type Name" />
        <input type="text" placeholder="Type Surrname" />
        <input type="text" placeholder="Type Email" />
        <input type="password" placeholder="Type Password" />
        <button>Register</button>
        <button @click.prevent="switchHandler">Or Register</button>
    </form>
    

</template>