namespace allspice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;

    private Recipe JoinCreatorToRecipe(Recipe recipe, Profile profile)
    {
        recipe.Creator = profile;
        return recipe;
    }

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipes(title,instructions, img, category,creatorId)
        VALUES(@Title,@Instructions, @Img, @Category,@CreatorId);
        SELECT recipes.*, accounts.* 
        FROM recipes 
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = LAST_INSERT_ID();";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, JoinCreatorToRecipe, recipeData).FirstOrDefault();
        return recipe;
    }

    internal List<Recipe> GetRecipe()
    {
        string sql = @"
        SELECT recipes.*, accounts.* 
        FROM recipes 
        JOIN accounts ON recipes.creatorId = accounts.id;";

        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, JoinCreatorToRecipe).ToList();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT recipes.*, accounts.* 
        FROM recipes 
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @recipeId;";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, JoinCreatorToRecipe, new { recipeId }).FirstOrDefault();
        return recipe;
    }

    internal void UpdateRecipe(Recipe recipe)
    {
        string sql = @"
        UPDATE recipes 
        SET
        title = @Title,
        instructions = @Instructions
    
        WHERE id = @Id LIMIT 1;";

        int affectedRows = _db.Execute(sql, recipe);

        if (affectedRows == 0)
        {
            throw new Exception("No recipes were updated");
        }
        if (affectedRows > 1)
        {
            throw new Exception("all recipes were updated");
        }
    }

    internal void DeleteRecipe(int recipeId)
    {
        string sql = @"
        DELETE FROM recipes     
        WHERE id = @recipeId LIMIT 1;";

        int affectedRows = _db.Execute(sql, new { recipeId });

        if (affectedRows == 0)
        {
            throw new Exception("No recipes were delete");
        }
        if (affectedRows > 1)
        {
            throw new Exception("all recipes were delete");
        }
    }
}