namespace allspice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _ingredientsRepository;
    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository ingredientsRepository, RecipesService recipesService)
    {
        _ingredientsRepository = ingredientsRepository;
        _recipesService = recipesService;
    }

    internal Ingredient CreateIngredients(Ingredient ingredientData, string userId)
    {
        Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);
        if (userId != recipe.CreatorId)
        {
            throw new Exception($"invalid ingredient id: {recipe.Id}");
        }

        Ingredient ingredient = _ingredientsRepository.CreateIngredients(ingredientData);

        return ingredient;
    }

    private Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient ingredient = _ingredientsRepository.GetIngredientById(ingredientId);
        if (ingredient == null)
        {
            throw new Exception("invalid ingredient id");
        }
        return ingredient;
    }

    internal List<Ingredient> GetAllIngredientByRecipeId(int recipeId)
    {
        List<Ingredient> ingredient = _ingredientsRepository.GetAllIngredientByRecipeId(recipeId);
        return ingredient;
    }

    internal void DeleteIngredient(int ingredientId, string userId)
    {
        Ingredient ingredient = GetIngredientById(ingredientId);
        Recipe recipe = _recipesService.GetRecipeById(ingredient.RecipeId);
        if (ingredient.RecipeId == ingredient.Id)
        {
            throw new Exception();
        }

        if (recipe.CreatorId != userId)
        {
            throw new Exception();
        }
        _ingredientsRepository.DeleteIngredient(ingredientId);
    }
}
