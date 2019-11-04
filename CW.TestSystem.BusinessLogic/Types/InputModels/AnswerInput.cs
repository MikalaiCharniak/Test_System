using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.InputModels
{
    public class AnswerInput : InputObjectType<Answer>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Answer> descriptor)
        {
            descriptor.Field(x => x.Text).
                       Type<NonNullType<StringType>>().
                       Description("Text of answer");
            descriptor.Field(x => x.Correct).
                       Type<NonNullType<BooleanType>>().
                       Description("Correct answer or no (true or false)");
        }
    }
}
