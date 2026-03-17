using FluentValidation;
using SocietySaaS.Application.Features.Societies.Commands.CreateSociety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Validators
{
    public class CreateSocietyCommandValidator : AbstractValidator<CreateSocietyCommand>
    {
        public CreateSocietyCommandValidator()
        {
            RuleFor(x => x.Request.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Request.Address)
                .MaximumLength(500);

            RuleFor(x => x.Request.RegistrationNumber)
                .MaximumLength(100);

            RuleFor(x => x.Request.GSTNumber)
                .MaximumLength(50);
        }
    }
}
