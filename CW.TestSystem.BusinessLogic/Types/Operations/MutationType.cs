﻿using CW.TestSystem.BusinessLogic.Logic.Commands;
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
            descriptor.Field<TestMutationResolver>(x => x.CreateTestAsync(default, default)).
                Name("createTest").
                Type<TestType>().
                Argument("testInput", x => x.Type<TestInput>());
        }
    }
}