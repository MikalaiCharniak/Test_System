using CW.TestSystem.BusinessLogic.Logic.Commands;
using CW.TestSystem.BusinessLogic.Types.InputModels;
using CW.TestSystem.BusinessLogic.Types.Models;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.Operations
{
    public partial class MutationType : ObjectType
    {
        protected  override void Configure(IObjectTypeDescriptor descriptor)
        {
            #region QuestionType
            descriptor.Field<QuestionMutationResolver>(x => x.CreateQuestionAsync(default, default)).
                Name("createQuestion").
                Type<QuestionType>().
                Argument("questionInput", x => x.Type<QuestionInput>());
            descriptor.Field<QuestionMutationResolver>(x => x.UpdateQuestionAsync(default, default)).
                Name("updateQuestion").
                Type<QuestionType>().
                Argument("updateQuestion", x => x.Type<QuestionInput>());
            descriptor.Field<QuestionMutationResolver>(x => x.DeleteQuestionAsync(default, default)).
                Name("removeQuestion").
                Type<BooleanType>().
                Argument("id", x => x.Type<IdType>());
            #endregion

            #region TestType
            descriptor.Field<TestMutationResolver>(x => x.CreateTestAsync(default, default)).
                Name("createTest").
                Type<TestType>().
                Argument("testInput", x => x.Type<TestInput>());
            descriptor.Field<TestMutationResolver>(x => x.DeleteTestAsync(default, default)).
                Name("deleteTest").
                Type<TestType>().
                Argument("id", x => x.Type<IdType>());
            descriptor.Field<TestMutationResolver>(x => x.UpdateTestAsync(default, default)).
                Name("updateTest").
                Type<TestType>().
                Argument("updateTest", x => x.Type<TestInput>());
            #endregion

            #region Tag Type
            descriptor.Field<TagMutationResolver>(x => x.CreateTagAsync(default, default)).
                Name("createTag").
                Type<TagType>().
                Argument("inputTag", x => x.Type<TagInput>());
            descriptor.Field<TagMutationResolver>(x => x.DeleteTagAsync(default, default)).
                Name("removeTag").
                Type<BooleanType>().
                Argument("id", x => x.Type<IdType>());
            descriptor.Field<TagMutationResolver>(x => x.UpdateTagAsync(default, default)).
                Name("updateTag").
                Type<TagType>().
                Argument("updateTag", x => x.Type<TagInput>());
            #endregion
        }
    }
}