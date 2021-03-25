using System.ComponentModel.DataAnnotations;

namespace ExampleDDD.Application.ViewModels
{
    public class UserEmailViewModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "The email is required")]
        public string EmailAddress { get; set; }
    }
}
