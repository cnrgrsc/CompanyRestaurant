using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.TableVM
{
    public class UpdateTableVM
    {
        public UpdateTableVM()
        {
            Status = DataStatus.Updated;
        }
        public int Id { get; set; }
        public int TableNo { get; set; }
        public bool RezStatus { get; set; }
        public int PersonCapacity { get; set; }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}
