<script setup>
import { RouterLink } from 'vue-router';

const props = defineProps({
    episodes:{
        type:Object,
        required:true
    }   
});
</script>
<template>
    <table class="w-full shadow-2xl">
        <thead class="bg-purple-800 text-white">
            <th class="text-left p-2">Epizód</th>
            <th class="text-left p-2">Cím</th>
            <th class="text-left p-2">Első vetítés</th>
        </thead>
        <tbody>
            <tr v-for="ep in episodes" class="odd:bg-purple-800/15">
                <td class="p-2">
                    <RouterLink :to="{name:'episodes.show', params:{id:ep.id}}">{{ ep.episode }}</RouterLink>
                </td>
                <td class="p-2">
                    {{ ep.name }}
                </td>
                <td class="p-2">
                    {{ ep.air_date }}
                </td>
            </tr>
        </tbody>
    </table>
</template>
<style scoped></style>