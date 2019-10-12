using System;
using CW.TestSystem.Model.CoreEntities;

namespace CW.TestSystem.Model.RelationValueObjects
{
    public class TestTag
    {
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
