using CW.TestSystem.BusinessLogic.Operations;
using HotChocolate.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors.Definitions;

namespace CW.TestSystem.GraphQLTypes.OperationTypes
{
    public class QueryType : ObjectType<Query>
    {
        protected override ObjectTypeDefinition CreateDefinition(IInitializationContext context)
        {
            return base.CreateDefinition(context);
        }
    }
}
