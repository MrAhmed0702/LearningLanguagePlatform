using System.ComponentModel.DataAnnotations;

namespace LearningLanguagePlatform.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Select the language which you want to learn.")]
        public string SelectLanguage { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password doesn't match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
