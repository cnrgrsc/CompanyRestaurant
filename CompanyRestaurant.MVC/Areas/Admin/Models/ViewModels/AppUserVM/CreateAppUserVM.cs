using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.AppUserVM
{
    public class CreateAppUserVM
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-posta boş geçilemez!")]
        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Roller")]
        public List<string> Roles { get; set; } = new List<string>();
    }
}
