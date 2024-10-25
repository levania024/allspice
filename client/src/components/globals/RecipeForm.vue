<script setup>
import { recipesService } from '@/services/RecipesService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';

const categories = [
    'breakfast',
    'lunch',
    'dinner',
    'snack',
    'dessert'
]

const recipeData = ref({
    title: '',
    category: '',
    img: '',
    instructions: ''
})

async function createRecipe() {
    try {
        await recipesService.createRecipe(recipeData.value)
        Modal.getInstance('#recipe-modal').hide()
        recipeData.value = {
            title: '',
            category: '',
            img: '',
            instructions: ''
        }
    }
    catch (error) {
        Pop.error(error);
        logger.log(error)
    }
}
</script>

<template>
    <div class="card col-md-6 m-3">
        <div class="bg-success text-light">
            <h1 class="m-2">New Recipe</h1>
        </div>
        <div class="m-2">
            <form @submit.prevent="createRecipe()">
                <div class="d-flex justify-content-between">
                    <div class="mb-3">
                        <label for="Title" class="form-label">Title</label>
                        <input v-model="recipeData.title" type="Title" class="form-control" id="Title" required>
                    </div>
                    <div class="mb-3">
                        <label for="category" class="form-label">Category</label>
                        <div class="">
                            <select v-model="recipeData.category" class="form-select text-capitalize" name="category" id="category" aria-label="Select Category" required>
                                <option selected disabled value="">Select Category</option>
                                <option v-for="category in categories" :key="category" :value="category" class="text-capitalize">{{ category }}
                                </option>
                            </select>
                        </div>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="Image" class="form-label">Image</label>
                    <input v-model="recipeData.img" type="url" class="form-control" id="Image" required>
                </div>

                <div class="mb-3">
                    <label for="Instructions" class="form-label">Instructions</label>
                    <textarea v-model="recipeData.instructions" type="password" class="form-control"
                        id="Instruction" required>
                    </textarea>
                </div>
                
                <div class="text-end mb-3">
                    <button type="submit" class="btn btn-outline me-3">Cancel</button>
                    <button type="submit" class="btn btn-primary">Submit</button>
                </div>
            </form>
        </div>
    </div>
</template>


<style lang="scss" scoped></style>