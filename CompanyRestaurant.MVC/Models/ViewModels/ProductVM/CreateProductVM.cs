using CompanyRestaurant.Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ViewModels.ProductVM
{
    public class CreateProductVM
    {

        [Required(ErrorMessage = "Ürün adı boş geçilemez!")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Ürün fiyatı boş geçilemez!")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Kategori seçimi yapılmalıdır!")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Ürün resmi boş geçilemez!")]
        public IFormFile ProductImage { get; set; }

        //public virtual Category Category { get; set; }
        //public virtual List<ProductMaterial> ProductMaterials { get; set; }
        //public virtual List<ProductOrder> ProductOrders { get; set; }
    }
}
