using CW.TestSystem.BusinessLogic.Infrastructure.RelationModels;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.InputModels.RelationInputs
{
    public class TestQuestionInput : InputObjectType<TestQuestionRelation>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TestQuestionRelation> descriptor)
        {
            descriptor.Name("TestQuestion");
        }
    }
}