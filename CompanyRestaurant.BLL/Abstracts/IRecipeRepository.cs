using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<decimal> CalculateRecipeCost(int recipeId);
        Task<RecipeDetailViewModel> GetRecipeWithMaterials(int recipeId);
    }
}
