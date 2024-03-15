using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.CustomerVM
{
    public class UpdateCustomerVM
    {
        public UpdateCustomerVM()
        {
            Status = DataStatus.Updated;
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
