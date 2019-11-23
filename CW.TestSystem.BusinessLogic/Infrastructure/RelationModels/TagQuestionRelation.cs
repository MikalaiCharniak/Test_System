using CW.TestSystem.Model.RelationValueObjects;
using System;
using System.Collections.Generic;

namespace CW.TestSystem.BusinessLogic.Infrastructure.RelationModels
{
    public class TagQuestionRelation
    {
        public TagQuestionRelation()
        {
            QuestionsTags = new HashSet<QuestionTag>();
        }

        public Guid TagId { get; set; }
        public Guid QuestionId { get; set; }
        public ICollection<QuestionTag> QuestionsTags { get; set; }
    }
}
