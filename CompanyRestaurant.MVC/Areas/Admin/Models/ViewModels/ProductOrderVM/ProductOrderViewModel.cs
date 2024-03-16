﻿using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.ProductOrderVM
{
    public class ProductOrderViewModel
    {
        public int ProductId { get; set; }
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; } // Ürünün adı
        public int Quantity { get; set; } // Sipariş edilen miktar
    }
}
