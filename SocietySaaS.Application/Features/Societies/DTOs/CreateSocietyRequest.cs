using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Societies.DTOs
{
    public class CreateSocietyRequest
    {
        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? RegistrationNumber { get; set; }

        public string? GSTNumber { get; set; }
    }
}
