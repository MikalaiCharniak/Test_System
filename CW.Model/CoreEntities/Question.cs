using System;
using System.Collections.Generic;
using CW.Model.RelationValueObjects;

namespace CW.Model.CoreEntities
{
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            Tags = new HashSet<QuestionTag>();
            Tests = new HashSet<TestQuestion>();
        }
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Answer> Answers { get; private set; }
        public ICollection<QuestionTag> Tags { get; private set; }
        public ICollection<TestQuestion> Tests { get; private set; }
    }
}
