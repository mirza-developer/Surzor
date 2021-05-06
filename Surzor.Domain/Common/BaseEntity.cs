using System;

namespace Surzor.Domain.Common
{
    public class BaseEntity : AuditableEntity
    {
        public Guid Id { get; set; }
    }
}
