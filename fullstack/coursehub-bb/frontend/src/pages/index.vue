<script setup>
import Box from '@components/Box.vue';
import CourseCard from '@components/CourseCard.vue';
import BaseLayout from '@layouts/BaseLayout.vue'
import { api } from '@utils/http.mjs';
import { onMounted, ref } from 'vue';
const courses = ref([]);
const loading = ref(true);

async function loadCourses(){
  const response = await api.get(`/api/courses`);
  courses.value = response.data.data;
  loading.value = false;
}

onMounted(()=>{loadCourses()});
</script>

<template>
  <p v-if="loading">Page loading...</p>
  <Box v-else-if="courses.length == 0" type="warning">No course found.</Box>
  <div v-else class="courses">
   <CourseCard v-for="course in courses" :key="course.id" :course></CourseCard> 
  </div>
</template>

<route lang="yaml">
name: index
meta:
  title: Főoldal
</route>