using CW.TestSystem.BusinessLogic.Types.Models;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.InputModels
{
    public class QuestionInput : InputObjectType<Question>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Question> descriptor)
        {
            descriptor.Field(x => x.Text).
                       Type<NonNullType<StringType>>().
                       Description("Text of question");
            descriptor.Field(x => x.Answers).
                       Type<NonNullType<ListType<AnswerInput>>>().
                       Description("Set of answers for creating question. " +
                       "Question cannot be created without answers");
            descriptor.Ignore(x => x.CreateDate);
            descriptor.Ignore(x => x.Id);
            descriptor.Ignore(x => x.Tests);
            descriptor.Ignore(x => x.Tags);
        }
    }
}
