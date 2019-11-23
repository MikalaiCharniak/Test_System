using CW.TestSystem.BusinessLogic.Infrastructure.RelationModels;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.InputModels.RelationInputs
{
    public class TagTestInput : InputObjectType<TagTestRelation>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TagTestRelation> descriptor)
        {
            descriptor.Name("TagTest");
        }
    }
}
