<script setup>
import TrainCard from '@components/TrainCard.vue';
import BaseLayout from '@layouts/BaseLayout.vue'
import { api } from '@utils/http.mjs';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const train = ref({});

onMounted(async ()=>{
  const result = await api.get(`/api/trains/${route.params.id}`);
  train.value = await result.data;
  console.log(train.value.data.id);
});
</script>

<template>
  <BaseLayout>
  </BaseLayout>
</template>

<route lang="yaml">
name: trains.show
meta:
  title: Reisedetails
</route>
