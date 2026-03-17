using FluentValidation;
using SocietySaaS.Application.Features.Societies.Commands.UpdateSociety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Validators
{
    public class UpdateSocietyCommandValidator : AbstractValidator<UpdateSocietyCommand>
    {
        public UpdateSocietyCommandValidator()
        {
            RuleFor(x => x.Request.GSTNumber)
                .MaximumLength(20);

            RuleFor(x => x.Request.RegistrationNumber)
                .MaximumLength(50);
        }
    }
}
