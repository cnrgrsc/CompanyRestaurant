using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.AppRoleVM
{
    public class CreateAppRoleVM
    {
        [Required(ErrorMessage = "Rol adı boş geçilemez!")]
        [Display(Name = "Rol Adı")]
        public string RoleName { get; set; }
    }
}
