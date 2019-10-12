using System;

namespace CW.TestSystem.Model.CoreEntities
{
    public class Result
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
