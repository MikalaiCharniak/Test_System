using CW.TestSystem.Model.RelationValueObjects;
using System;
using System.Collections.Generic;

namespace CW.TestSystem.BusinessLogic.Infrastructure.RelationModels
{
    public class TestQuestionRelation
    {
        public TestQuestionRelation()
        {
            TestsQuestions = new HashSet<TestQuestion>();
        }
        public Guid TestId { get; set; }
        public Guid QuestionId { get; set; }
        public ICollection<TestQuestion> TestsQuestions { get; set; }
    }
}
