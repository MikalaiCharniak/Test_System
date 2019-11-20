using HotChocolate.Types;
using CW.TestSystem.Model.RelationValueObjects;

namespace CW.TestSystem.BusinessLogic.Types.InputModels
{
    public class TestQuestionInput : InputObjectType<TestQuestion>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TestQuestion> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Ignore(x => x.TestId);
            descriptor.Ignore(x => x.Question);
            descriptor.Ignore(x => x.Test);
        }
    }
}
