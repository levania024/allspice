<script setup>

</script>


<template>
    <div class="bg-light shadow rounded">
        <div class="text-center">
            <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase">
                About
            </router-link>

            <router-link :to="{ name: 'Home' }" class="btn text-success lighten-30 selectable text-uppercase">
                Home
            </router-link>
        </div>
    </div>
</template>


<style lang="scss" scoped>

</style>