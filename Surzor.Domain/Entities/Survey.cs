using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Surzor.Domain.Common;

namespace Surzor.Domain.Entities
{
    public class Survey : BaseEntity
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
