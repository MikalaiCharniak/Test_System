using System;
using CW.TestSystem.Model.CoreEntities;

namespace CW.TestSystem.Model.RelationValueObjects
{
    public class QuestionTag
    {
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
