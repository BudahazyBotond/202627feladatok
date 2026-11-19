<script setup>
import KauflandIcon from '@components/icons/KauflandIcon.vue';
import Index from '@pages/index.vue';
</script>

<template>
<nav class="flex gap-2 p-2">
    <div class="flex gap-2">
        <RouterLink :to="{name:'index', params:{}}">
            <KauflandIcon class="fill-primary w-16" />
        </RouterLink>
        <RouterLink :to="{name:'index', params:{}}">
            <h1 class="w-16 h-16 bg-primary text-xs font-bold text-white flex items-end p-0.5">
                Online<br>trhovisko
            </h1>
        </RouterLink>
        
    </div>
</nav>
</template>