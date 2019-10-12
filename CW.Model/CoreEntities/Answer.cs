using System;

namespace CW.Model.CoreEntities
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
