<script setup>
import Button from '@components/Button.vue';
const { title, price, reservationOnly } = defineProps({
    title: {
        type: String,
        required: true
    },
    price: {
        type: Number,
        required: true,
    },
    reservationOnly: {
        type: Boolean,
        required: false,
        default: false,
    }
});
</script>

<template>
    <div class="bg-white p-4 outline-primary border shadow flex flex-col grow">
        <h3 class="text-lg text-center">{{ title }}</h3>
        <p class="text-sm text-center mb-2 uppercase">{{ reservationOnly ? '(kein Ticket)' : 'Eine fahrt FLEX' }}</p>
        <p class="text-2xl text-center font-bold my-2">{{ price.toLocaleString("de-AT", { style: "currency", currency: "EUR" }) }}</p>
        <ul class="grow ml-3 list-none mb-4">
            <li class="before:content-['ⓘ'] before:mr-3">Nicht stornierbar</li>
            <li class="before:content-['ⓘ'] before:mr-3" v-if="reservationOnly">Gilt nur in Kombination mit einem Ticket in der gewählten Reiseklasse.</li>
            <li class="before:content-['✓'] before:mr-3" v-else>Freie Wahl der möglichen Verkehrsmittel</li>
        </ul>
        <Button class="block mx-auto">Angebot wählen</Button>
    </div>
</template>