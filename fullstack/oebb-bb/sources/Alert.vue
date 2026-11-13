<script setup>
const { title, text } = defineProps({
    title: {
        type: String,
        required: true,
    },
    text: {
        type: String,
        required: false,
    }
})
</script>

<template>
<div class="p-4 bg-primary/10 border-2 border-primary">
    <h2 class="text-primary font-bold mb-2">{{ title }}</h2>
    <p v-if="text" class="text-primary">{{ text }}</p>
</div>
</template>