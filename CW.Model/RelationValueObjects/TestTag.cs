using CW.Model.CoreEntities;
using System;

namespace CW.Model.RelationValueObjects
{
    public class TestTag
    {
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
