<script setup>
import Box from '@components/Box.vue';
import CourseCard from '@components/CourseCard.vue';
import BaseLayout from '@layouts/BaseLayout.vue'
import { ucfirst } from '@utils/helper';
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

const levels = ["beginner", "intermediate", "advanced"];
const search = ref({
  name: "",
  level: "",
});
</script>

<template>
  <form action="" class="grid md:grid-cols-2 gap-4 max-w-2xl mx-auto space-y-5 mt-6">

      <div class="flex flex-col space-y-1">
          <label for="name" class="text-sm font-medium text-gray-700">
              Name
          </label>
          <input v-model="search.name" type="text" name="name" id="name" placeholder="Enter course name" class="w-full rounded-lg border border-gray-300 px-3 py-2 text-gray-900
              placeholder-gray-400
              focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30
              focus:outline-none transition" />
      </div>

      <div class="flex flex-col space-y-1">
          <label for="level" class="text-sm font-medium text-gray-700">
              Level
          </label>
          <select v-model="search.level" name="level" id="level" class="w-full rounded-lg border border-gray-300 px-3 py-2 text-gray-900
              bg-white appearance-none
              focus:border-orange-500 focus:ring-2 focus:ring-orange-500/30
              focus:outline-none transition">
              <option value="">All level</option>
              <option v-for="level in levels" :value="level">{{ ucfirst(level) }}</option>

          </select>
      </div>

  </form>
{{ search }}
  <p v-if="loading">Page loading...</p>
  <Box v-else-if="courses.length == 0" type="warning">No course found.</Box>
  <div v-else class="courses grid gap-4 md:grid-cols-4">
   <CourseCard v-for="course in courses" :key="course.id" :course></CourseCard> 
  </div>
</template>

<route lang="yaml">
name: index
meta:
  title: Főoldal
</route>