<script setup>
import { ref } from 'vue';
import { RouterLink } from 'vue-router';
const props = defineProps({
    character:{
        type:Object,
        required:true
    }
});
</script>

<template>
    <div class="card border-purple-600 bg-purple-100 p-2 rounded-lg shadow-2xl">
        <img class="w-full rounded-lg" :src="character.image" :alt="character.name">
        <h2 class="font-semibold text-xl text-center my-2">{{ character.name }}</h2>
        <RouterLink class="button px-4 py-2 inline-block rounded-full bg-purple-800 text-white" 
        :to="{name: `characters.show`, params:{id:character.id}}">Részletek</RouterLink>
    </div>
</template>

<style scoped></style>
