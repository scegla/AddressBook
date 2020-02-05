using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBooth.Models
{
    public class ContactSearch
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer number")]
        [RegularExpression(@"^[0-9]*$")]
        public int Id { get; set; }
        [Required(ErrorMessage = "error message.")]
        [RegularExpression(@"^[0-9]*$")]
        public string PhoneNum { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9 ]*$")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9 ]*$")]
        public string LastName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9 ]*$")]
        public string Address { get; set; }
    }
}