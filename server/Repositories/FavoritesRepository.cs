namespace allspice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO favorites(recipeId, accountId)
        VALUES(@RecipeId, @AccountId);

        SELECT favorites.*,recipes.*, accounts.* 
        FROM favorites 
        JOIN recipes ON favorites.recipeId = recipes.id
        JOIN accounts ON favorites.accountId = accounts.id
        WHERE favorites.id = LAST_INSERT_ID();";

        FavoriteRecipe favorite = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>(sql, (favorite, recipe, profile) =>
        {
            recipe.AccountId = favorite.AccountId;
            recipe.FavoriteId = favorite.Id;
            recipe.Creator = profile;
            return recipe;

        }, favoriteData).FirstOrDefault();
        return favorite;
    }

    internal void DeleteIngredient(int favoriteFavoriteId)
    {
       string sql = "DELETE FROM favorites WHERE id = @favoriteFavoriteId LIMIT 1;";
        int affectedRows = _db.Execute(sql, new { favoriteFavoriteId });

        if (affectedRows == 0)
        {
            throw new Exception("No ingredient were delete");
        }
        if (affectedRows > 1)
        {
            throw new Exception("all ingredient were delete");
        }
    }

    internal List<FavoriteRecipe> GetFavoriteByAccountId(string userId)
    {
        string sql = @"
        SELECT 
        favorites.*,
        recipes.*, 
        accounts.* 
        FROM favorites 
        JOIN recipes ON favorites.recipeId = recipes.id
        JOIN accounts ON favorites.accountId = accounts.id
        WHERE favorites.accountId = @userId;";

        List<FavoriteRecipe> favorite = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>(sql, (favorite, recipe, profile) =>
        {
            recipe.AccountId = favorite.AccountId;
            recipe.FavoriteId = favorite.Id;
            recipe.Creator = profile;
            return recipe;

        }, new { userId }).ToList();
        return favorite;
    }

    internal Favorite GetFavoriteById(int favoriteFavoriteId)
    {
        string sql = @"SELECT * FROM favorites WHERE id = @favoriteFavoriteId;";

        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteFavoriteId }).FirstOrDefault();
        return favorite;
    }
}
