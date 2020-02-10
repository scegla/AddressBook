using System;
using FluentValidation;
using Microsoft.Ajax.Utilities;

namespace PhoneBooth.Models
{
    public class ContactSearchValidator : AbstractValidator<ContactSearch>
    {
        public ContactSearchValidator()
        {
            // First set the cascade mode
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(c => c).NotNull();

            RuleFor(c => c.Id).Must(x => x > Int32.MinValue && x < Int32.MaxValue);
            RuleFor(c => c.FirstName).Matches("^[a-zA-Z0-9 čšž]*$");
            RuleFor(c => c.LastName).Matches("^[a-zA-Z0-9 čšž]*$");
            RuleFor(c => c.Address).Matches("^[a-zA-Z0-9 čšž]*$");

            RuleFor(c => c.PhoneNum).NotEqual("").Matches("^[0-9]*$").When(c => !c.PhoneNum.IsNullOrWhiteSpace());
        }
    }
}