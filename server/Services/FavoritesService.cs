namespace allspice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _favoritesRepository;

    public FavoritesService(FavoritesRepository favoritesRepository)
    {
        _favoritesRepository = favoritesRepository;
    }

    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        FavoriteRecipe favorite = _favoritesRepository.CreateFavorite(favoriteData);
        return favorite;
    }

    internal void DeleteFavorite(int favoriteFavoriteId, string userId)
    {
       Favorite favorite = _favoritesRepository.GetFavoriteById(favoriteFavoriteId);

         if(favorite.AccountId != userId){
            throw new Exception("Can not delete, not the owner");
        }
    
        _favoritesRepository.DeleteIngredient(favoriteFavoriteId);
    }

     private Favorite GetFavoriteById(int favoriteFavoriteId)
    {
        Favorite favorite = _favoritesRepository.GetFavoriteById(favoriteFavoriteId);
        if (favorite == null)
        {
            throw new Exception("invalid ingredient id");
        }
        return favorite;
    }

    internal List<FavoriteRecipe> GetFavoriteByAccountId(string userId)
    {
        List<FavoriteRecipe> favorite = _favoritesRepository.GetFavoriteByAccountId(userId);
        return favorite;
    }
}
