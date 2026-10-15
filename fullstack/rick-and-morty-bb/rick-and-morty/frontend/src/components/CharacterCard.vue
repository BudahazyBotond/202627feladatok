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
        <p class="py-2 px-4 mx-2">{{ character.name }}</p>
        <p>Status: {{ character.status }}</p>
    </div>
</template>
<style scope></style>