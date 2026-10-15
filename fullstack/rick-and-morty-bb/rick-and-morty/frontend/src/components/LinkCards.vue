<script setup>
const {character} = defineProps({
    character:{
        type: Object,
        required: true
    }
})
</script>
<template>
    <div>
        <img :src="character.image" alt="">
        <RouterLink class="bg-blue-500 text-white rounded py-2 px-4 mx-2" 
        :to="{name: `characters.show`, params:{id:character.id}}">{{ character.name }}</RouterLink>
    </div>
</template>
<style scope></style>