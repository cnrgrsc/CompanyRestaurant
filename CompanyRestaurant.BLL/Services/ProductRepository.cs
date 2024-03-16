using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        private readonly CompanyRestaurantContext _context;
        public ProductRepository(CompanyRestaurantContext context):base(context)
        {
            _context = context;
        }
        public async Task SellProduct(int productId, int quantity, decimal price)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ID == productId);
            if (product == null)
            {
                throw new Exception("Ürün bulunamadı.");
            }

            if (product.UnitInStock < quantity)
            {
                throw new Exception("Yeterli stok bulunmamaktadır.");
            }

            // Stok miktarını azalt
            product.UnitInStock -= quantity;
            await _context.SaveChangesAsync();

            // Yeni bir sipariş oluştur (Örnek olarak, daha fazla detay gerekebilir)
            var newOrder = new Order
            {
                // Sipariş detayları
                Price = quantity * price,
                // Diğer gerekli alanlar ve ilişkiler
            };

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
        }
    }
}
