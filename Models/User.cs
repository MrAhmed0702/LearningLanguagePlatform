using Humanizer;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace LearningLanguagePlatform.Models
{
    public class User : IdentityUser
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        [MaxLength(50)] 
        public string Name { get; set; }

       [Required]
        public string SelectedLanguage { get; set; }

        public string UserType { get; set; }

    }

}
