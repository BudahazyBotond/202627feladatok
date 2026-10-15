<script setup>
import Card from '@components/Card.vue';
import UserIcon from '@components/icons/UserIcon.vue';
import LoginIcon from '@components/icons/LoginIcon.vue';
import Button from '@components/Button.vue';
</script>

<template>
    <Card class="shadow md:shadow-none">
        <div class="flex flex-col p-8">
            <h2 class="text-xl font-bold mb-2">Das ÖBB Konto</h2>
            <p>Anmelden und alle Vorteile genießen!</p>
            <div class="flex justify-center flex-wrap mt-4">
                <Button type="button" variant="empty">
                    Konto erstellen <UserIcon class="size-8 inline"/>
                </Button>
                <Button type="button" variant="empty">
                    Jetzt anmelden <LoginIcon class="size-8 inline"/>
                </Button>
            </div>
        </div>
    </Card>
</template>