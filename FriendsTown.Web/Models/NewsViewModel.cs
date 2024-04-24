using System.ComponentModel.DataAnnotations;

namespace FriendsTown.Web.Models
{
    public class NewsViewModel
    {
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date, ErrorMessage = "Incorrect Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(30, ErrorMessage = "City name allows a maximum of 30 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(30, ErrorMessage = "Street allows a maximum of 5o characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; }

        public string Reference { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
