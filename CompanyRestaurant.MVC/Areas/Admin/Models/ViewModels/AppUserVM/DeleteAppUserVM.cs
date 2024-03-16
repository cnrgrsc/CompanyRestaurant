using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.AppUserVM
{
    public class DeleteAppUserVM
    {
        public DeleteAppUserVM()
        {
            Status = DataStatus.Deleted;
        }

        public int Id { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        public DataStatus Status { get; set; }
    }
}
