using System.ComponentModel.DataAnnotations;
using System.Web.Http.Results;

namespace PhoneBooth.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string PhoneNum { get; set; }
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Address { get; set; }
    }
}