<script setup>
import Title from '@components/Title.vue';
import BaseLayout from '@layouts/BaseLayout.vue'
import { api } from '@utils/http.mjs';
import { onMounted, ref } from 'vue';
import { RouterLink, useRoute } from 'vue-router';
const route = useRoute();
const character = ref({});

onMounted(async () =>{
  const result = await api.get(`character/${route.params.id}`);
  character.value = result.data;
});

</script>

<template>
  <BaseLayout>
    <Title>{{ character?.name }}</Title>
    <div class="character grid grid-cols-1 md:grid-cols-2 gap-4 bg-purple-800 text-purple-100 w-2xl text-center">
      <img class="rounded-md w-full" :src="character?.image" :alt="character?.name">
      <div class="info flex flex-col justify-between">
        <ul>
          <li>{{ character?.species }}</li>
          <li>{{ character?.gender }}</li>
          <li>{{ character?.location?.name }}</li>
        </ul>
        <RouterLink class="button bg-white text-purple-800 mt-4 text-right" :to="{name:'characters.index'}">Vissza</RouterLink>
      </div>
    </div>
  </BaseLayout>
</template>

<route lang="yaml">
name: characters.show
meta:
  title: Karakter
</route>