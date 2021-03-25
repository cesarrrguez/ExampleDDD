using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExampleDDD.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "The first name is required")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The age is required")]
        public int Age { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "The phone number is required")]
        public string PhoneNumber { get; set; }

        public List<UserAddressViewModel> Addresses { get; set; }
        public List<UserEmailViewModel> Emails { get; set; }
    }
}
