<script setup>
import { Recipe } from '@/models/Recipe.js';

defineProps({ recipeProp: { type: Recipe, require: true } })

</script>


<template>
    <div class="position-relative m-3">
        <img class="rounded-2 recipe-img" :src="recipeProp.img" :alt="recipeProp.creator.name">
        <div class="recipe-info text-light rounded m-2 p-1">
            <h4>{{ recipeProp.title }}</h4>
            <p>{{ recipeProp.instructions }}</p>
        </div>
        <p class="recipe-category m-3 rounded-4 text-light">{{ recipeProp.category }}</p>
            <i class="mdi mdi-heart-outline icon mx-2 rounded"></i>
    </div>
</template>


<style lang="scss" scoped>
.recipe-img {
    height: 40dvh;
    width: 40dvh;
    object-fit: cover;
    object-position: center;
}

.recipe-info {
    background-color: #848280b2;
    position: absolute;
    bottom: 0;
    right: 0;
    box-shadow: 1px 1px 2px;
}

.recipe-category {
    background-color: #848280b2;
    font-size: 1.2rem;
    position: absolute;
    text-align: center;
    width: 10dvh;
    top: 0;
    box-shadow: 1px 1px 2px;
}

.icon {
    background-color: #848280b2;
    position: absolute;
    font-size: 2rem;
    top: 0;
    right: 0;
    text-align: center;
    height: 4dvh;
    width: 4dvh;
    box-shadow: 1px 1px 2px;
}
</style>