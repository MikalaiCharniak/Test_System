﻿using System;
using CW.TestSystem.Model.CoreEntities;

namespace CW.TestSystem.Model.RelationValueObjects
{
    public class TestQuestion
    {
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
