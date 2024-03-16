using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.MaterialPriceVM
{
    public class DeleteMaterialPriceVM
    {
        public DeleteMaterialPriceVM()
        {
            Status = DataStatus.Deleted;
        }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
