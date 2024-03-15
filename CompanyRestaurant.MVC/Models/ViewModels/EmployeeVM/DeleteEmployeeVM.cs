using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.EmployeeVM
{
    public class DeleteEmployeeVM
    {
        public DeleteEmployeeVM()
        {
            Status=DataStatus.Deleted;
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
