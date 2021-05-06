using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Surzor.Domain.Common;

namespace Surzor.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }

        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
