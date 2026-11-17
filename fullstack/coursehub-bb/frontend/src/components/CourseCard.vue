<script setup>
import { ucfirst } from '@utils/helper.js';
import Bubble from './Bubble.vue';
import { RouterLink } from 'vue-router';

const {course} = defineProps({
    course: {
        type: Object,
        required: true
    }
});
</script>
<template>
    <div class="group overflow-hidden rounded-2xl border border-gray-200 bg-white
            shadow-sm transition-all duration-4  hover:shadow-lg hover:border-orange-200">

        <img :src="course.image" :alt="course.name" class="h-48 w-full object-cover" />

        <div class="p-5">

            <div class="flex justify-between">
                <h2 class="text-lg font-bold text-gray-900">
                    {{ course.name }}

                    <br>

                    <span class="mb-5 text-sm text-gray-500 text-end">
                        By {{ course.author }}
                    </span>
                </h2>

                <div class="mb-3 flex items-center justify-around flex-col gap-2">
                    <Bubble>{{ course.level }}</Bubble>
                    <Bubble>{{ course.lessons?.lenght }} lessons</Bubble>
                </div>

            </div>


            <div class="flex items-center justify-between border-t border-gray-100 pt-4">

                <RouterLink :to="{name: 'courses.show', params: {id:course.id}}" class="block rounded-lg bg-orange-700 px-4 py-2.5 text-center
                text-sm font-medium text-white transition hover:bg-gray-700">
                    View course
                </RouterLink>

                <span class="text-xl font-bold text-gray-900">
                    {{ Number(course.price).toFixed(2) }}
                </span>
            </div>



        </div>
    </div>
</template>