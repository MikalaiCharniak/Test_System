using CW.TestSystem.Model.RelationValueObjects;
using System;
using System.Collections.Generic;

namespace CW.TestSystem.BusinessLogic.Infrastructure.RelationModels
{
    public class TagTestRelation
    {
        public TagTestRelation()
        {
            TestsTags = new HashSet<TestTag>();
        }

        public Guid TestId { get; set; }
        public Guid TagId { get; set; }
        public ICollection<TestTag> TestsTags { get; set; }
    }
}
