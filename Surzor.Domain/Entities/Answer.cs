using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Surzor.Domain.Common;
namespace Surzor.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string Value { get; set; }
        public Guid OptionId { get; set; }
        public Option Option { get; set; }

        public Guid ResponderId { get; set; }
        public Responder Responder { get; set; }

    }
}
