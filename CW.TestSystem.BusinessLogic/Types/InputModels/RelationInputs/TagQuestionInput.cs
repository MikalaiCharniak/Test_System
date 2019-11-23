using CW.TestSystem.BusinessLogic.Infrastructure.RelationModels;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.InputModels.RelationInputs
{
    public class TagQuestionInput : InputObjectType<TagQuestionRelation>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TagQuestionRelation> descriptor)
        {
            descriptor.Name("TagQuestion");
        }
    }
}