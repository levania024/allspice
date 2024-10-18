namespace allspice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredients(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredients(name,quantity, recipeId)
        VALUES(@Name,@Quantity, @RecipeId);

        SELECT ingredients.*, recipes.*
        FROM ingredients 
        JOIN recipes ON ingredients.recipeId = recipes.id
        WHERE ingredients.id = LAST_INSERT_ID();";

        Ingredient ingredient = _db.Query<Ingredient, Recipe, Ingredient>
        (sql, (ingredient, recipe) =>
        {
            ingredient.RecipeId = recipe.Id;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return ingredient;
    }

    internal void DeleteIngredient(int ingredientId)
    {
        string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";
        int affectedRows = _db.Execute(sql, new { ingredientId });

        if (affectedRows == 0)
        {
            throw new Exception("No ingredient were delete");
        }
        if (affectedRows > 1)
        {
            throw new Exception("all ingredient were delete");
        }
    }

    internal List<Ingredient> GetAllIngredientByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT ingredients.*, recipes.*
        FROM ingredients 
        JOIN recipes ON ingredients.recipeId = recipes.id
        WHERE ingredients.recipeId = @recipeId;";

        List<Ingredient> ingredient = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
        {
            ingredient.RecipeId = recipe.Id;
            return ingredient;
        }, new { recipeId }).ToList();
        return ingredient;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        string sql = @"SELECT * FROM ingredients WHERE id = @ingredientId;";

        Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
        return ingredient;
    }
}
