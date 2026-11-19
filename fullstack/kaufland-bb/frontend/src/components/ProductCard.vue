<script setup>
import { computed } from 'vue';
import Price from './Price.vue';

const {product} = defineProps({
    product:{
        type: Object,
        required: true
    }
});

const categories = {
    "non-perishables": "Trvanlivé potraviny",
    "soda syrup": "Sirup do nápojov",
    "chocolate": "Čokoláda",
    "cheese": "Syr",
    "sausage": "Klobása",
    "coffee": "Káva"
};

const categoryText = computed(() => {
    return categories[product.category];
});
</script>
<template>
    <div class="border rounded-xl p-4 flex flex-col">
        <img :src="'/images/'+product.image" :alt="product.name" class="w-full aspect-square object-contain mb-4">
        <h3 class="font-bold text-xl text-ellipsis wrap-break-word break-all overflow-hidden line-clamp-3 mb-1 grow">{{product.name}}</h3>
        <p class="mb-2">{{ categoryText }}</p>
        <p class="text-lg font-black mb-2"><Price :price="product.price" :discount="product.discount"></Price></p>
        <RouterLink :to="{name:'products.show',params:{id:product.id}}" class="bg-primary py-2 px-4 font-bold text-white w-full text-center rounded-full">Viac informácií</RouterLink>
    </div>
</template>