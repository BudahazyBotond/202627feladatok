<script setup>
import BaseHeader from '@components/layout/BaseHeader.vue'
</script>

<template>
  <BaseHeader />
  <main class="container mx-auto max-w-340 px-4 mb-4">
    <slot />
  </main>
</template>
