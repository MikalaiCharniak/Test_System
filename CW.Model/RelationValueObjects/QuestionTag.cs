using CW.Model.CoreEntities;
using System;

namespace CW.Model.RelationValueObjects
{
    public class QuestionTag
    {
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
