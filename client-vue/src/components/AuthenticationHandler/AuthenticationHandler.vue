<script setup>
import { useAuthenticationData } from '@/store/Authentication/AuthenticationDataStore';
const store = useAuthenticationData();

const {setName, setSurname, setEmail, setPassword} = store;

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
    <form v-if="loginHandler" class="w-full flex items-center justify-center flex-col">
        <input type="text" placeholder="Type Email"  
        @input="(e) => setEmail(e.target.value)" :value="store.email" />
        <input type="password" placeholder="Type Password" :value="store.password" 
        @input="(e) => setPassword(e.target.value)"/>
        <button>Log In</button>
        <button @click.prevent="switchHandler">Or Register</button>
    </form>

    <form v-else class="w-full flex justify-center items-center flex-col ">
        <input type="text" placeholder="Type Name" />
        <input type="text" placeholder="Type Surrname" />
        <input type="text" placeholder="Type Email" :value="store.email"/>
        <input type="password" placeholder="Type Password" :value="store.password"/>
        <button>Register</button>
        <button @click.prevent="switchHandler">Or Register</button>
    </form>

</template>

<style scoped>
    form {
        height: 600px;
    }

    input {
        margin: 8px 8px;
        border-radius: 4px;
        color: black;
    }

    button {
        color: white;
    }
</style>