<script setup>
import CharacterCard from '@components/CharacterCard.vue';
import Title from '@components/Title.vue';
import BaseLayout from '@layouts/BaseLayout.vue'
import { api } from '@utils/http.mjs';
import { computed, onMounted, ref } from 'vue';


const characters = ref([]);
onMounted(async ()=>{
  const result = await api.get(`character`);
  characters.value = result.data.results;
});

const name = ref("");
const genders = ["Male","Female","Genderless","Unknown"];
const gender = ref("");
const statuses={
  alive:"Élő",
  dead:"Halott",
  unknown:"Ismeretlen"
};
const status = ref("");

const filteredCharacters = computed(()=>{
  return characters.value.filter(c=>c.name.toLowerCase().includes(name.value.toLowerCase()) && c.gender.toLowerCase().includes(gender.value.toLowerCase()) && c.status.toLowerCase().includes(status.value.toLowerCase()));
});


</script>

<template>
  <BaseLayout>
    <Title>Rick & Morty karakterek</Title>
    {{ gender }}
    <form class="flex my-4 gap-4" @submit.prevent="">
        <label for="name" class="mx-2">Név</label>
        <input v-model="name" type="text" id="name" placeholder="Név" class="border border-blue800 px-4 py-2 mb-2">
        <label for="gender" class="mx-2">Nem</label>
        <select v-model="gender" name="gender" id="gender">
          <option value="">Mind</option>
          <option v-for="gend in genders" :value="gend">{{ gend }}</option>
        </select>
        <label for="status" class="mx-2">Státusz</label>
        <select v-model="status" name="status" id="status">
          <option value="">Mind</option>
          <option v-for="(stat,key) in statuses" :value="key">{{ stat }}</option>
        </select>
      </form>
    <div class="character grid grid-cols-1 md:grid-cols-4 gap-6">
      <CharacterCard v-for="character in filteredCharacters" :key="character.id" :character></CharacterCard>
    </div>
  </BaseLayout>
</template>

<route lang="yaml">
name: characters.index
meta:
  title: Karakterek
</route>