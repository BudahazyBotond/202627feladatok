<script setup>
import CharacterCard from '@components/CharacterCard.vue';
import BaseLayout from '@layouts/BaseLayout.vue';
import { api } from '@utils/http.mjs';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();

const character = ref([]);

onMounted(async ()=>{
  const result = await api.get(`character/${route.params.id}`);
  //console.log(result.data.results);
  character.value = result.data;
});

console.log(character.value)
</script>
<template>
  <BaseLayout>
    <CharacterCard :character></CharacterCard>
  </BaseLayout>
</template>
<style scoped></style>
<route lang="yaml">
name: characters.show
meta:
  title: Karakterek
</route>