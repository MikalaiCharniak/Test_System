using CW.TestSystem.BusinessLogic.Operations;
using HotChocolate.Types;
using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors.Definitions;

namespace CW.TestSystem.BusinessLogic.Types.Operations
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(x => x.CreateTestAsync(default, default, default)).
                       Description("Create new test with few already existing questions");
        }
    }
}
