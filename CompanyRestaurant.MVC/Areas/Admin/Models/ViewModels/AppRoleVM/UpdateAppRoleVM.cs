using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.AppRoleVM
{
    public class UpdateAppRoleVM
    {
        public UpdateAppRoleVM()
        {
            Status = DataStatus.Updated;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Rol adı boş geçilemez!")]
        [Display(Name = "Rol Adı")]
        public string RoleName { get; set; }

        public DataStatus Status { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}
