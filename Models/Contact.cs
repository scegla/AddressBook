using System.ComponentModel.DataAnnotations;
using System.Web.Http.Results;

namespace PhoneBooth.Models
{
    public class Contact
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer number")]
        public int Id { get; set; }

        [RegularExpression(@"^[0-9]*$")]
        [Required]
        public string PhoneNum { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9 ]*$")]
        [Required]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9 ]*$")]
        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9 ]*$")]
        [Required]
        public string Address { get; set; }
    }
}