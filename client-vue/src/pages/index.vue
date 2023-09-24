<script setup lang="ts">
import Main from '@/layouts/Main.vue';
import Welcome from '@/components/homeContent/Welcome.vue';
import Card from '@/components/homeContent/Card.vue';
useHead({
	title: 'Vitailse | Opinionated vite starter template',
});

</script>

<template>
	<Main>
		<template #main>
			<Welcome />
			<Card :left="true"
				:text="'The process of creating a company involves multiple components, from establishing the business structure to setting up financial systems and operational workflows. By incorporating APIs into these processes, entrepreneurs can experience a more streamlined and automated approach to managing their ventures.'"
				:img="'https://cdn.pixabay.com/photo/2020/07/08/04/12/work-5382501_1280.jpg'" 
				:header="'Create Company'"/>
			<Card :left="false"
				:text="'The process of creating a company involves multiple components, from establishing the business structure to setting up financial systems and operational workflows. By incorporating APIs into these processes, entrepreneurs can experience a more streamlined and automated approach to managing their ventures.'"
				:img="'https://cdn.pixabay.com/photo/2017/07/31/11/21/people-2557396_1280.jpg'" 
				:header="'Create Groups'"/>
			<Card :left="true"
				:text="'The process of creating a company involves multiple components, from establishing the business structure to setting up financial systems and operational workflows. By incorporating APIs into these processes, entrepreneurs can experience a more streamlined and automated approach to managing their ventures.'"
				:img="'https://cdn.pixabay.com/photo/2015/05/13/01/59/business-764929_1280.jpg'" 
				:header="'Create Activities'"/>
		</template>
	</Main>
</template>

<route lang="yaml">
	name: home
</route>
