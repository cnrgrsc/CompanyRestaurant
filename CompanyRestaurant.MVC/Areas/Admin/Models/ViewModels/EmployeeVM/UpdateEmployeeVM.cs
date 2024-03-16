using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.EmployeeVM
{
    public class UpdateEmployeeVM
    {
        public UpdateEmployeeVM()
        {
            Status = DataStatus.Updated;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public long TC { get; set; }
        public string Phone { get; set; }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }



    }
}
