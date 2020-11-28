using System.ComponentModel.DataAnnotations;

namespace DemoExercise.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
