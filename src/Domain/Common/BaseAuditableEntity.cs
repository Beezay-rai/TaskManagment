using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Common
{
    public abstract class BaseAuditableEntity :BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string? LastModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string? DeletedBy { get; set; }
    }
}
