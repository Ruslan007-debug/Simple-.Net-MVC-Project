using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyMVC.Models.ViewComponents
{
    public class LoginViewModel
    {
        [Display(Name = "Логін")]
        [Required]
        public string? UserName { get; set; }
        [Required]
        [UIHint("Password")]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
        [Display(Name = "Запам'ятати мене")]
        public bool RememberMe { get; set; }
    }
}
