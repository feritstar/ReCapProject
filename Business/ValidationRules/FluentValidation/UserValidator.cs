using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.EmailAddress).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u => u.EmailAddress).MinimumLength(13);
            RuleFor(u => u.EmailAddress).Must(EndWithAddress);
            RuleFor(u => u.Password).MinimumLength(8);
        }

        private bool EndWithAddress(string arg)
        {
            return arg.EndsWith(".com");
        }
    }
}
