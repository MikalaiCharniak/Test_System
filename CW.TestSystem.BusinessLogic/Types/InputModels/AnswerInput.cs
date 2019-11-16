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
            descriptor.Field(x => x.Id).
                       Type<IdType>().
                       Description("Unique answer ID; Should be use only for updating.");
            descriptor.Ignore(x => x.QuestionId);
            descriptor.Ignore(x => x.Question);
        }
    }
}