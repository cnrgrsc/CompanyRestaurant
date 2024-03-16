using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.TableVM
{
    public class DeleteTableVM
    {
        public DeleteTableVM()
        {
            Status = DataStatus.Deleted;
        }
        public int Id { get; set; }
        public int TableNo { get; set; }
        public bool RezStatus { get; set; }
        public int PersonCapacity { get; set; }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}
