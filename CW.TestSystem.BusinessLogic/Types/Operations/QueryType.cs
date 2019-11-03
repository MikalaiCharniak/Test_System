using CW.TestSystem.BusinessLogic.Operations;
using HotChocolate.Types;
using CW.TestSystem.BusinessLogic.Types.Models;
using HotChocolate.Types.Relay;

namespace CW.TestSystem.BusinessLogic.Types.Operations
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.GetTestsAsync(default)).
                Type<ListType<TestType>>().
                UsePaging<TestType>().
                UseFiltering().
                UseSorting().
                Description("Get tests with filtering");

            descriptor.Field(x => x.GetTagsAsync(default)).
                Type<ListType<TestType>>().UseFiltering().
                Description("Get tags with filtering");

            descriptor.Field(x => x.GetQuestionsAsync(default)).
                Type<ListType<TestType>>().UseFiltering().
                Description("Get questions with filtering");

            descriptor.Field(x => x.GetResultsAsync(default)).
                Type<ListType<TestType>>().UseFiltering().
                Description("Get results with filtering");
        }
    }
}
