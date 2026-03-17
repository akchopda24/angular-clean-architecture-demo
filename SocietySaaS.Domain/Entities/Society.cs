using SocietySaaS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Domain.Entities
{
    public class Society : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? RegistrationNumber { get; set; }

        public string? GSTNumber { get; set; }

    }
}
