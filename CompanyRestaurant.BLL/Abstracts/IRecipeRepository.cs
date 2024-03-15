﻿using CompanyRestaurant.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IRecipeRepository:IRepository<Recipe>
    {
        Task<decimal> CalculateTotalCost(int recipeId);
    }
}
