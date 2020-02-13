using System;
using FluentValidation;
using Microsoft.Ajax.Utilities;

namespace PhoneBooth.Models
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            // First set the cascade mode
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(c => c).NotNull().WithMessage("Model cant be null"); 

            RuleFor(customer => customer.Id).NotNull().WithMessage("Id is required");
            RuleFor(customer => customer.FirstName).NotNull().WithMessage("FirstName is required"); 
            RuleFor(customer => customer.LastName).NotNull().WithMessage("LastName is required"); 
            RuleFor(customer => customer.Address).NotNull().WithMessage("Address is required"); 
            RuleFor(customer => customer.PhoneNum).NotNull().WithMessage("PhoneNum is required"); 

            RuleFor(customer => customer.Id).NotEqual(0).WithMessage("Id is required"); 
            RuleFor(customer => customer.FirstName).NotEqual("").WithMessage("FirstName is required"); 
            RuleFor(customer => customer.LastName).NotEqual("").WithMessage("LastName is required"); 
            RuleFor(customer => customer.Address).NotEqual("").WithMessage("Address is required"); 
            RuleFor(customer => customer.PhoneNum).NotEqual("").WithMessage("PhoneNum is required"); 

            RuleFor(c => c.Id).Must(x => x > Int32.MinValue && x < Int32.MaxValue).WithMessage("Id must be int type"); 
            RuleFor(c => c.FirstName).Matches("^[a-zA-Z0-9 čšž]*$").WithMessage("FirstName only letters and digits allowed");
            RuleFor(c => c.LastName).Matches("^[a-zA-Z0-9 čšž]*$").WithMessage("LastName only letters and digits allowed"); 
            RuleFor(c => c.Address).Matches("^[a-zA-Z0-9 čšž]*$").WithMessage("Address only letters and digits allowed"); 

            RuleFor(x => x.PhoneNum).NotEqual("").When(x => !x.PhoneNum.IsNullOrWhiteSpace()).WithMessage("PhoneNum cant be null or empty");
            RuleFor(c => c.PhoneNum).NotEqual("").Matches("^[0-9]*$").When(c => !c.PhoneNum.IsNullOrWhiteSpace()).WithMessage("PhoneNum must be a number");
            int i;
            RuleFor(c => c.PhoneNum).NotEqual("").Length(9, 9).Must(x => int.TryParse(x, out i)).When(c => !c.PhoneNum.IsNullOrWhiteSpace()).WithMessage("PhoneNum must be 9 digits length"); 
            RuleFor(c => c.PhoneNum).NotEqual("").Must(x => x.ToString().Length == 9).When(c => !c.PhoneNum.IsNullOrWhiteSpace()).WithMessage("PhoneNum must be 9 digits length"); //PhoneNum is 9 digits length
        }
    }
}