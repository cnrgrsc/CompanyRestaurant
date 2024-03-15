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
    public class UnitStockRepository : BaseRepository<UnitStock>, IUnitStockRepoistory
    {
        private readonly CompanyRestaurantContext _context;
        public UnitStockRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }


        public async Task UpdateStockForMaterial(int materialId, int quantityChange)
        {
            var unitStock = await _context.UnitStocks.FirstOrDefaultAsync(us => us.MaterialID == materialId);
            if (unitStock != null)
            {
                unitStock.Stock += quantityChange; // Stok miktarını güncelle
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("UnitStock not found");
            }
        }

        public Task UpdateStockForProduct(int productId, int quantityChange)
        {
            throw new NotImplementedException();
        }
    }
}
