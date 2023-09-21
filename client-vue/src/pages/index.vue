<script setup lang="ts">
import { useStore } from '@/store';
import Main from '@/layouts/Main.vue';
import Welcome from '@/components/homeContent/Welcome.vue';
useHead({
	title: 'Vitailse | Opinionated vite starter template',
});

</script>

<template>
	<Main>
	<template #main>
		<Welcome />
		
		
	</template>
	</Main>
</template>

<route lang="yaml">
	name: home
</route>
