using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.MaterialUnitVM
{
    public class UpdateMaterialUnitVM
    {
        public UpdateMaterialUnitVM()
        {
            Status = DataStatus.Updated;
        }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
    }
}
