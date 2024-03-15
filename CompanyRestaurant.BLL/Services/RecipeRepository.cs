using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<decimal> CalculateTotalCost(int recipeId)
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

    }
}
