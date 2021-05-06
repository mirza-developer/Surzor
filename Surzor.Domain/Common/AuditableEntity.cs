using System;

namespace Surzor.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime CreateDateTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? LastModifyDateTime { get; set; }
        public Guid? LastModifiedBy { get; set; }
    }
}
