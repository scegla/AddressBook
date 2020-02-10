using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBooth.Models
{
    public class ContactSearch
    {
        
        public int Id { get; set; }
        
        public string PhoneNum { get; set; }
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
    }
}