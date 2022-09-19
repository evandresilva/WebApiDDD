using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDDD.Domain.Entities;

namespace WebApiDDD.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please insert the name").WithErrorCode("E100")
                .NotNull().WithMessage("Please insert the name").WithErrorCode("E1001");
        }
    }
}
