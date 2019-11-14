using CW.TestSystem.BusinessLogic.Operations;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.Operations
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(x => x.CreateTestAsync(default, default)).
                       Description("Create new test with few already existing questions");
            descriptor.Field(x => x.CreateQuestionAsync(default, default)).
                       Description("Create new question. New question must include list of answers");
        }
    }
}
