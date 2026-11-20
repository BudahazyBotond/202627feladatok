<script setup>
import BaseLayout from '@layouts/BaseLayout.vue';
import { useErrorToast } from '@/composables/useErrorToast';
import { api } from '@utils/http.mjs';
import { onMounted } from 'vue';
import CharacterForm from '@components/CharacterForm.vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const errorToast = useErrorToast();
function createCharacter(data){
    const res = api.post(`/characters`,data);
    return res.status;
}

function handleSubmit(data){
    createCharacter(data);
    router.push({name:"characters.index"})
}



</script>

<template>
    <BaseLayout>
        <h1 class="text-4xl font-bold font-poppins mb-4">Új karakter létrehozása</h1>
        <CharacterForm @submit="handleSubmit"></CharacterForm>
    </BaseLayout>
</template>

<route lang="yaml">
name: characters.create
meta:
    title: Új karakter
</route>