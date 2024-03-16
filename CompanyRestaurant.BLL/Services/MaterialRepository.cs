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
    public class MaterialRepository:BaseRepository<Material>,IMaterialRepository
    {
        private readonly CompanyRestaurantContext _context;
        public MaterialRepository(CompanyRestaurantContext context):base(context)
        {
            _context = context;
        }

        public async Task AddMaterialStock(int materialId, decimal quantity)
        {
            var material = await _context.Materials.FirstOrDefaultAsync(m => m.ID == materialId);
            if (material == null)
            {
                throw new Exception("Material not found.");
            }

            material.UnitInStock += (short)quantity;
            await _context.SaveChangesAsync();
        }

        public async Task ReduceMaterialStock(int materialId, decimal quantity)
        {
            var material = await _context.Materials.FirstOrDefaultAsync(m => m.ID == materialId);
            if (material == null)
            {
                throw new Exception("Material not found.");
            }

            if (material.UnitInStock < quantity)
            {
                throw new Exception("Insufficient stock.");
            }

            material.UnitInStock -= (short)quantity;
            await _context.SaveChangesAsync();
        }
    }
}
