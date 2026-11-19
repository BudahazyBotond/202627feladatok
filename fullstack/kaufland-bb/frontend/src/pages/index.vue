<script setup>
import Navbar from '@components/Navbar.vue';
import ProductCard from '@components/ProductCard.vue';
import { api } from '@utils/http.mjs';
import { computed, onMounted, ref } from 'vue';

const categories = {
    "non-perishables": "Trvanlivé potraviny",
    "soda syrup": "Sirup do nápojov",
    "chocolate": "Čokoláda",
    "cheese": "Syr",
    "sausage": "Klobása",
    "coffee": "Káva"
};
const engCategories = [
    "non-perishables",
    "soda syrup",
    "chocolate",
    "cheese",
    "sausage",
    "coffee"
];
const products = ref([]);
const search = ref({
    name:"",
    category:""
});
const filteredProducts = computed(()=>{
    return products.value.filter(p=>
        (search.value.name == "" || p.name.toLowerCase().includes(search.value.name.toLowerCase())) &&
        (search.value.category == "" || p.category == search.value.category)
    );
});

async function getProducts(){
    const res = await api.get(`/products`);
    products.value = res.data.data;
}
onMounted(()=>{getProducts()});

</script>
<template>
 <main class="w-11/12 mx-auto max-w-7xl my-6">
    <h2 class="text-3xl py-4">Najpredávanejšie produkty v kategórii Potraviny</h2>
    <div class="grid gap-4 sm:grid-cols-2">
        <input v-model="search.name" type="text" default="" name="name" id="name" placeholder="Hľadať" aria-label="Hľadať" class="py-1 px-2 border rounded">
        <select v-model="search.category" name="category" id="category" aria-label="Kategória" class="appearance-none py-1 px-2 border rounded">
            <option value="">Všetky kategória</option>
            <option v-for="cat in engCategories" :value="cat">{{ categories[cat] }}</option>
        </select>
    </div>
    <div class="grid gap-4 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-6">
        <p v-if="filteredProducts.length == 0" class="col-span-full text-center">Nenašli sa žiadne produkty<!-- Termék nem található --></p>
        <ProductCard v-for="product in filteredProducts" :product/>
    </div>
</main>
</template>
<route lang="yaml">
name: index
meta:
    title: Objavte našu ponuku a nakupujte za nízke ceny
</route>
