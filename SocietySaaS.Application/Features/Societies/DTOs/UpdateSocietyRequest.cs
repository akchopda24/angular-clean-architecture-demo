using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Societies.DTOs
{
    public class UpdateSocietyRequest
    {
        public string? RegistrationNumber { get; set; }

        public string? GSTNumber { get; set; }

        public string? Address { get; set; }
    }
}
