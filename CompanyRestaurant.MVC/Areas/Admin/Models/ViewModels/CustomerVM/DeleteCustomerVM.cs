using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.CustomerVM
{
    public class DeleteCustomerVM
    {
        public DeleteCustomerVM()
        {
            Status = DataStatus.Deleted;
        }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
