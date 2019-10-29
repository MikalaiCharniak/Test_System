using CW.TestSystem.BusinessLogic.Operations;
using HotChocolate.Types;
using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors.Definitions;

namespace CW.TestSystem.BusinessLogic.Types.Operations
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override ObjectTypeDefinition CreateDefinition(IInitializationContext context)
        {
            return base.CreateDefinition(context);
        }
    }
}
