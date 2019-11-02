using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.Models
{
    public class AnswerType : ObjectType<Answer>
    {
        protected override void Configure(IObjectTypeDescriptor<Answer> descriptor)
        {
            descriptor.Field(x => x.Id).
                Type<NonNullType<IdType>>().
                Description("Unique Guid Id of Answer");
            descriptor.Field(x => x.Text).
                Type<NonNullType<StringType>>().
                Description("Text of answer");
            descriptor.Field(x => x.Correct).
                Type<NonNullType<BooleanType>>().
                Description("Is answer correct? Bool type for this. true - correct/ false - incorrect");
            descriptor.Field(x => x.QuestionId).
                Type<NonNullType<IdType>>().
                Description("Unique Guid Id of question, which contain this answer");
        }
    }
}