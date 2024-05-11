using System.ComponentModel.DataAnnotations;

namespace FriendsTown.WebApi.Models
{
    public class AddNewsInput
    {
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; }
        public string Reference { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = 
            "Description must have between 10 and 100 characters")]
        public string Description { get; set; }
    }
}
