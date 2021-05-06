using System.Collections.Generic;
using Surzor.Domain.Common;

namespace Surzor.Domain.Entities
{
    public class Responder : BaseEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
