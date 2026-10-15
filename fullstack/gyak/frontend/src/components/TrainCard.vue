<script setup>
import { computed } from 'vue';

const { train } = defineProps({
    train: {
        type: Object,
        required: true,
    }
});

const duration = computed(() => {
    const toSeconds = (time) => {
        const [hours, minutes] = time.split(':').map(Number);
        return (hours * 3600) + (minutes * 60);
    };
    let departureTimeInSeconds = toSeconds(train.departure_time);
    let arrivalTimeInSeconds = toSeconds(train.arrival_time);
    if (arrivalTimeInSeconds < departureTimeInSeconds) {
        arrivalTimeInSeconds += 24 * 3600;
    }
    let difference = arrivalTimeInSeconds - departureTimeInSeconds;
    const hours = Math.floor(difference / 3600);
    const minutes = Math.floor(difference % 3600 / 60);
    return {hours, minutes}
})

const classes = {
    regional: ['text-primary border-primary'],
    intercity: ['text-[#2168f6] border-[#2168f6]'],
    railjet: ['text-[#ab0020] border-[#ab0020]'],
    nightjet: ['text-[#1e007d] border-[#1e007d]'],
}

const trainClasses = computed(() => {
    switch (train.train_number.split(' ')[0]) {
        case "RJ":
        case "RJX":
            return classes.railjet;
        case "NJ":
        case "EN":
            return classes.nightjet;
        case "IC":
        case "IR":
        case "EC":
        case "ICE":
        case "D":
            return classes.intercity;
        default:
            return classes.regional;
    }
})
</script>

<template>
<div class="bg-white p-12 grid md:grid-cols-subgrid gap-y-4 gap-x-8 border shadow">
    <div>
        <h3 class="font-bold text-xl flex flex-col md:flex-row items-start md:items-center gap4 mb-4">{{ train.departure_time.substring(0,5) }} - {{ train.arrival_time.substring(0,5) }} <span class="font-normal text-base md:border-l border-gray-500 md:ml-4 md:pl-4">Dauer {{ duration.hours }} h {{ duration.minutes }} min</span></h3>
        <p :class="[trainClasses, 'text-center border-b-4']">{{ train.train_number }}</p>
        <div class="flex justify-between gap-4">
            <p>{{ train.origin }}</p>
            <p>{{ train.destination }}</p>
        </div>
    </div>
    <RouterLink :to="{name: 'trains.show', params: {id: train.id}}" class="bg-primary text-white hover:bg-white hover:text-primary hover:outline outline-primary px-4 py-3 cursor-pointer self-center text-center">ab {{ train.second_class_price.toLocaleString("de-AT", { style: "currency", currency: "EUR" }) }}</RouterLink>
</div>
</template>
