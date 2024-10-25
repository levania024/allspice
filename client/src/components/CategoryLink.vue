<script setup>

</script>


<template>
    <div class="bg-light shadow rounded">
        <div>
            <router-link :to="{ name: 'Home' }" class="btn text-success lighten-30 selectable">
                Home
            </router-link>

            <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable">
                My Recipe
            </router-link>

            <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable">
                Favorites
            </router-link>
        </div>
    </div>
</template>


<style lang="scss" scoped></style>