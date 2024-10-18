namespace allspice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _ingredientsRepository;

    public IngredientsService(IngredientsRepository ingredientsRepository)
    {
        _ingredientsRepository = ingredientsRepository;
    }

    internal Ingredient CreateIngredients(Ingredient ingredientData)
    {
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

    internal void DeleteIngredient(int ingredientId, string id)
    {
        GetIngredientById(ingredientId);
        _ingredientsRepository.DeleteIngredient(ingredientId);
    }
}
