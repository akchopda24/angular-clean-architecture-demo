using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
