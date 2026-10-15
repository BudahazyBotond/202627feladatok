<script setup>
import EpisodesTable from '@components/EpisodesTable.vue';
import BaseLayout from '@layouts/BaseLayout.vue'
import { api } from '@utils/http.mjs';
import { onMounted, ref, computed } from 'vue';

const episodes = ref([]);
onMounted(async ()=>{
  const result = await api.get(`episode`);
  episodes.value = result.data.results;
});

</script>

<template>
  <BaseLayout>
    <EpisodesTable :episodes/>
  </BaseLayout>
</template>

<route lang="yaml">
name: episodes.index
meta:
  title: Részek
</route>