<script setup lang="ts">
import { useStore } from '@/store';
import Main from '@/layouts/Main.vue'
useHead({
	title: 'Vitailse | Opinionated vite starter template',
});

const store = useStore();
const { t } = useI18n();
</script>

<template>
	<Main>
	<template #main>

		
		
	</template>
	</Main>
</template>

<route lang="yaml">
	name: home
</route>
