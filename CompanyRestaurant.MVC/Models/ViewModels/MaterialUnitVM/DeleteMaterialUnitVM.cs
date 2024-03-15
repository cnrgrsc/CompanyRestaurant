using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.MaterialUnitVM
{
    public class DeleteMaterialUnitVM
    {
        public DeleteMaterialUnitVM()
        {
            Status=DataStatus.Deleted;
        }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
    }
}
