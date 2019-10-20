using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors.Definitions;

namespace CW.TestSystem.GraphQLTypes.ObjectTypes
{
    public class TagType : ObjectType<Tag>
    {
        protected override ObjectTypeDefinition CreateDefinition(IInitializationContext context)
        {
            return base.CreateDefinition(context);
        }
    }
}
