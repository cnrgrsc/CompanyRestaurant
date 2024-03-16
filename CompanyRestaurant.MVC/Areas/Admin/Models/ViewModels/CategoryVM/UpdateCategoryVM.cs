using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.CategoryVM
{
    public class UpdateCategoryVM
    {
        public UpdateCategoryVM()
        {
            Status = DataStatus.Updated;
        }
        public DataStatus Status { get; set; }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
