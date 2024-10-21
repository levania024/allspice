import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";
import { Recipe } from "@/models/Recipe.js";

class RecipesService{
 async getRecipes() {
    const response = await api.get("api/recipes")
    logger.log('get all recipes', response.data)
    const newRecipe = response.data.map(recipeData => new Recipe(recipeData))
    AppState.recipes = newRecipe
  }
}
export const recipesService = new RecipesService();