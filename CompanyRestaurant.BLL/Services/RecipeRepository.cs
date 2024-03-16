using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        private readonly CompanyRestaurantContext _context;
        public RecipeRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        // Recipe'nin toplam maliyetini hesaplayan metod
        public async Task<decimal> CalculateRecipeCost(int recipeId)
        {
            var recipe = await _context.Recipes
                                        .Include(r => r.RecipeMaterials)
                                        .ThenInclude(rm => rm.Material)
                                        .FirstOrDefaultAsync(r => r.ID == recipeId);

            if (recipe == null)
            {
                throw new ArgumentException("Recipe not found");
            }

            decimal totalCost = recipe.RecipeMaterials.Sum(rm => rm.Material.Price * rm.Quantity);

            return totalCost;
        }

        public Task<RecipeDetailViewModel> GetRecipeWithMaterials(int recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
