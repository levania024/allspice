namespace allspice.Services;

public class RecipesService
{
    private readonly RecipesRepository _recipesRepository;

    public RecipesService(RecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _recipesRepository.CreateRecipe(recipeData);
        return recipe;
    }

    internal void DeleteRecipe(int recipeId, string userId)
    {
        Recipe recipe = _recipesRepository.GetRecipeById(recipeId);

        if (recipe.CreatorId != userId)
        {
            throw new Exception("Can not delete, not the owner");
        }

        _recipesRepository.DeleteRecipe(recipeId);

    }

    internal List<Recipe> GetRecipe()
    {
        List<Recipe> recipes = _recipesRepository.GetRecipe();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _recipesRepository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception("invalide recipe Id");
        }
        return recipe;
    }

    internal Recipe UpdateRecipe(int recipeId, string userId, Recipe recipeData)
    {
        Recipe recipe = GetRecipeById(recipeId);
        if (recipe.CreatorId != userId)
        {
            throw new Exception("Can Not Update, not the Creator");
        }

        recipe.Title = recipeData.Title ?? recipe.Title;
        recipe.Instructions = recipeData.Instructions ?? recipe.Instructions;

        _recipesRepository.UpdateRecipe(recipe);
        return recipe;
    }
}
