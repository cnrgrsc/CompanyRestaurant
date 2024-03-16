﻿using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.ProductVM
{
    public class ProductViewModel
    {
        public int Id { get; set; } // Ürünün benzersiz kimliği

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } // Ürün adı

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; } // Ürün fiyatı

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Display(Name = "Stok Miktarı")]
        public int UnitInStock { get; set; } // Stoktaki birim miktarı

        [Display(Name = "Ürün Açıklaması")]
        public string Description { get; set; } // Ürün açıklaması

        [Display(Name = "Kategori ID")]
        public int? CategoryId { get; set; } // Ürünün ait olduğu kategori ID'si (Opsiyonel)

        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; } // Kategori adı

        [Display(Name = "Ürün Resmi URL")]
        public string ImageUrl { get; set; } // Ürün resminin URL'si

        // Opsiyonel olarak, ürünün ait olduğu reçete bilgisi de eklenebilir
        public int? RecipeId { get; set; }
        [Display(Name = "Reçete Adı")]
        public string RecipeName { get; set; } // İlişkilendirilmiş reçetenin adı
    }
}
