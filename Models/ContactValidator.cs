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

            RuleFor(c => c).NotNull();

            RuleFor(customer => customer.Id).NotNull();
            RuleFor(customer => customer.FirstName).NotNull();
            RuleFor(customer => customer.LastName).NotNull();
            RuleFor(customer => customer.Address).NotNull();
            RuleFor(customer => customer.PhoneNum).NotNull();

            RuleFor(customer => customer.Id).NotEqual(0);
            RuleFor(customer => customer.FirstName).NotEqual("");
            RuleFor(customer => customer.LastName).NotEqual("");
            RuleFor(customer => customer.Address).NotEqual("");
            RuleFor(customer => customer.PhoneNum).NotEqual("");

            RuleFor(c => c.Id).Must(x => x > Int32.MinValue && x < Int32.MaxValue);
            RuleFor(c => c.FirstName).Matches("^[a-zA-Z0-9 čšž]*$");
            RuleFor(c => c.LastName).Matches("^[a-zA-Z0-9 čšž]*$");
            RuleFor(c => c.Address).Matches("^[a-zA-Z0-9 čšž]*$");

            RuleFor(x => x.PhoneNum).NotEqual("").When(x => !x.PhoneNum.IsNullOrWhiteSpace());
            RuleFor(c => c.PhoneNum).NotEqual("").Matches("^[0-9]*$").When(c => !c.PhoneNum.IsNullOrWhiteSpace());
            int i;
            RuleFor(c => c.PhoneNum).NotEqual("").Length(9, 9).Must(x => int.TryParse(x, out i)).When(c => !c.PhoneNum.IsNullOrWhiteSpace()); 
            RuleFor(c => c.PhoneNum).NotEqual("").Must(x => x.ToString().Length == 9).When(c => !c.PhoneNum.IsNullOrWhiteSpace()); //PhoneNum is 9 digits length
        }
    }
}