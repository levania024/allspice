namespace allspice.Repositories;

public class IngredientsRepository
{

    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    private Recipe JoinCreatorToIngredients(Ingredients ingredients, Profile profile)
    {
        ingredients.Creator = profile;
        return ingredients;
    }

}
