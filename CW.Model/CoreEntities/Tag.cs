using System;
using System.Collections.Generic;
using CW.Model.RelationValueObjects;

namespace CW.Model.CoreEntities
{
    public class Tag
    {
        public Tag()
        {
            Tests = new HashSet<TestTag>();
            Questions = new HashSet<QuestionTag>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<TestTag> Tests { get; private set; }
        public ICollection<QuestionTag> Questions { get; private set; }
    }
}
