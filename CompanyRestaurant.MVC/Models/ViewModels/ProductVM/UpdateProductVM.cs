using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.ProductVM
{
    public class UpdateProductVM
    {
        public UpdateProductVM()
        {
            Status = DataStatus.Updated;
        }
        public DataStatus Status { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public IFormFile ProductImage { get; set; }

        // public virtual Category Category { get; set; }
        // public virtual List<ProductMaterial> ProductMaterials { get; set; }
        // public virtual List<ProductOrder> ProductOrders { get; set; }
    }
}
