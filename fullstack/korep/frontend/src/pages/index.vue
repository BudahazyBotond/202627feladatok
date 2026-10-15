<script setup>
import BaseLayout from '@layouts/BaseLayout.vue'
import Title from '@components/Title.vue'
import { RouterLink, useRoute } from 'vue-router';

</script>

<template>
  <BaseLayout>
    <Title> Főoldal </Title>
    <RouterLink class="button"
    :to="{name:'characters.index'}"> Karakterek </RouterLink>

    <RouterLink class="button"
    :to="{name:'episodes.index'}"> Epizódok </RouterLink>
  </BaseLayout>
</template>

<route lang="yaml">
name: index
meta:
  title: Főoldal
</route>
