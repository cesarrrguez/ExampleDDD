using System.ComponentModel.DataAnnotations;

namespace ExampleDDD.Application.ViewModels
{
    public class UserAddressViewModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "The street is required")]
        public string Street { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "The city is required")]
        public string City { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "The state is required")]
        public string State { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "The country is required")]
        public string Country { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "The zip code is required")]
        public string ZipCode { get; set; }
    }
}
