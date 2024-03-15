using CompanyRestaurant.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ViewModels.CategoryVM
{
    public class CreateCategoryVM
    {

        [Required(ErrorMessage = "Kategori adı boş geçilemez!")]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //public bool IsActive { get; set; }

    }
}
