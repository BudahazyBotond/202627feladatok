<script setup>
import BaseLayout from '@layouts/BaseLayout.vue';
import { useErrorToast } from '@/composables/useErrorToast';
import { api } from '@utils/http.mjs';
import { onMounted } from 'vue';
import CharacterForm from '@components/CharacterForm.vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const errorToast = useErrorToast();
async function createCharacter(data){
    const res = await api.post(`/characters`,data);
    return res.status === 201;
}

function handleSubmit(data){
    createCharacter(data)
        .then((e)=>{
            if(e){
                router.push({name:"characters.index"});
            }
            else error();
        })
            
        
}

function error(){
    errorToast.showError("Nem sikerült létrehozni a karaktert!")
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