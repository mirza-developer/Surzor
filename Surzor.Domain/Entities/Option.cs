using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Surzor.Domain.Common;

namespace Surzor.Domain.Entities
{
    public class Option : BaseEntity
    {
        public OptionType OptionType { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public bool IsTrue { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
