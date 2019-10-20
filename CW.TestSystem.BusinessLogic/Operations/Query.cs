using CW.TestSystem.GraphQLTypes.ObjectTypes;
using CW.TestSystem.Model.CoreEntities;
using System;


namespace CW.TestSystem.BusinessLogic.Operations
{
    public class Query
    {
        public Test GetRandomNewTest() => new Test() { Id = Guid.NewGuid(), Title = "Test Title", Description = "Wow" };
    }
}
