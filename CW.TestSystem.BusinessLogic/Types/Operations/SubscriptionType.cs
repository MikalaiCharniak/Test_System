using HotChocolate.Types;
using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors.Definitions;

namespace CW.TestSystem.BusinessLogic.Types.Operations
{
    public class SubscriptionType : ObjectType
    {
        protected override ObjectTypeDefinition CreateDefinition(IInitializationContext context)
        {
            return base.CreateDefinition(context);
        }
    }
}
