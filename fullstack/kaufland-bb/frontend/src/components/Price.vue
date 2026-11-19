<script setup>
import { int } from 'zod';


const {price, discount} = defineProps({
    price:{
        type: Number,
        required: true
    },
    discount:{
        type: Number,
        required: false,
        default: 0
    }
})
const discountedPrice = Math.round((price - price*discount)*100)/100;

</script>

<template>
    <span>
        {{ discountedPrice }} €
    </span>
</template>