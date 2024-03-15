using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.BLL.Services
{
    public class RecipeMaterialRepository : BaseRepository<RecipeMaterial>, IRecipeMaterialRepository
    {
        public RecipeMaterialRepository(CompanyRestaurantContext context) : base(context)
        {
        }
    }
}
