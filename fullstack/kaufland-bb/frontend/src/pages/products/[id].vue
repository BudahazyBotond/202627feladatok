<script setup>
import Badge from '@components/Badge.vue';
import Navbar from '@components/Navbar.vue';
import Price from '@components/Price.vue';
import ProductCard from '@components/ProductCard.vue';
import { api } from '@utils/http.mjs';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const product = ref(Object);
const loading = ref(true);

async function getProduct(){
    const res = await api.get("/products/"+route.params.id);
    product.value = res.data.data;
    loading.value = false;
}
onMounted(()=>getProduct())
</script>
<template>
    <Navbar></Navbar>
    <main class="w-11/12 mx-auto max-w-7xl my-6">
        <p v-if="loading" class="text-center">Načítava sa...<!-- Betöltés... --></p>
        <div v-if="!loading" class="grid md:grid-cols-3 gap-4">
            <img :src="'/images/'+product.image" :alt="product.name" class="aspect-square object-contain p-4 border rounded-lg">
            <div class="md:col-span-2">
                <h2 class="text-3xl font-bold py-4">{{product.name}}</h2>
                <div class="p-4 rounded-lg border shadow">
                    <p v-if="product.discount"><span class="line-through">{{ product.price }} €</span> <Badge>-{{product.discount*100}}%</Badge><!-- Akció --></p>
                    <p class="text-3xl font-black mb-2"><span><Price :price="product.price" :discount="product.discount"/></span></p>
                    <p v-if="product.free_shipping == 1" class="font-bold text-lime-600 mb-4">Doprava zdarma<!-- Ingyenes kiszállítás --></p>
                    <button class="bg-primary py-2 px-4 font-bold text-white w-full text-center rounded-full cursor-pointer">Pridať do košíka</button>
                </div>
            </div>
        </div>
    </main>
</template>
<route lang="yaml">
name: products.show
meta:
    title: Produkt
</route>
