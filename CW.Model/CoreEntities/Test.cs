using System;
using System.Collections.Generic;
using CW.TestSystem.Model.RelationValueObjects;

namespace CW.TestSystem.Model.CoreEntities
{
    public class Test
    {
        public Test()
        {
            Questions = new HashSet<TestQuestion>();
            Tags = new HashSet<TestTag>();
            Results = new HashSet<Result>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }        
        public DateTime CreateDate { get; set; }
        public ICollection<TestQuestion> Questions { get; private set; }
        public ICollection<TestTag> Tags { get; private set; }
        public ICollection<Result> Results { get; private set; }
    }
}
