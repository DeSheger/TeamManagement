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


</script>

<template>
    <form class="lg:flex col-span-1 hidden">
        <input type="text" v-model="Value" />
        <button>Search</button>
    </form>
</template>

<style scoped>
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
</style>