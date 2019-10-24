using CW.TestSystem.BusinessLogic.Operations;
using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace CW.TestSystem.BusinessLogic.Definitions
{
    public class TestSystemSchema : Schema
    {
        public TestSystemSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<TestSystemQuery>();
        }
    }
}