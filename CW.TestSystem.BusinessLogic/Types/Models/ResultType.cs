using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;
using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors.Definitions;

namespace CW.TestSystem.BusinessLogic.Types.Models
{
    public class ResultType : ObjectType<Result>
    {
        protected override ObjectTypeDefinition CreateDefinition(IInitializationContext context)
        {
            return base.CreateDefinition(context);
        }
    }
}
