<script setup>
import { AppState } from '@/AppState.js';
import CategoryLink from '@/components/CategoryLink.vue';
import RecipeCard from '@/components/globals/RecipeCard.vue';
import Login from '@/components/Login.vue';
import Navbar from '@/components/Navbar.vue';
import { recipesService } from '@/services/RecipesService.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const recipes = computed(() => AppState.recipes)


onMounted(() => {
  getRecipes();
})
async function getRecipes() {
  try {
    await recipesService.getRecipes();
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>

<template>
  <div class="container-fluid bg-hero m-3 rounded position-relative">
    <div class="navbar">
      <Navbar />
    </div>
    <h1 class="text-center text-light">All Spice</h1>

    <div class="container link d-flex justify-content-center align-items-center">
      <CategoryLink />
    </div>
  </div>


  <div class="container">
    <section class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4">
        <RecipeCard :recipeProp="recipe" />
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss">
.bg-hero {
  background-image: url(https://images.unsplash.com/photo-1498837167922-ddd27525d352?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  min-height: 50dvh;
  background-position: center;
  background-size: cover;
  box-shadow: 2px 1px 1px;
}

.navbar {
  position: absolute;
  top: 0;
  right: 0;
}

.link {
  position: absolute;
  bottom: 0;
}
</style>
