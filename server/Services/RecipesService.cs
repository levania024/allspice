


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
}
