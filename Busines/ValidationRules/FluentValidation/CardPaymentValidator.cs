using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.ValidationRules.FluentValidation
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {

            //RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.CreditCardNumber).NotEmpty();
            RuleFor(c => c.CreditCardNumber).Length(16);
            RuleFor(c => c.CardholderFirstNameLastName).NotEmpty();
            RuleFor(c => c.CardValidationValue).NotEmpty();
            RuleFor(c => c.CardValidationValue).Length(3);
            RuleFor(c => c.ValidThru).NotEmpty();
        }
    }
}
