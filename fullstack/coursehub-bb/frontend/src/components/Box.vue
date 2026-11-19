<script setup>
import { computed } from 'vue';

const {type} = defineProps({
    type: String, 
    required: true
});

const classes = computed(()=>{
    let classes = "px-6 py-6 text-base font-semibold rounded-sm w-full text-center";
    if ("info" == type){
        classes += "bg-sky-200 border border-blue-700 text-blue-700";
    }
    else if("warning" == type){
        classes += "bg-orange-200 border border-orange-700 text-orange-700";
    }
    return classes;
})
</script>

<template>
    <div :class="classes"><slot></slot></div>
</template>
