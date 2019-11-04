using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.InputModels
{
    public class TestInput : InputObjectType<Test>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Test> descriptor)
        {
            descriptor.Field(x => x.Title).
                       Type<NonNullType<StringType>>().
                       Description("Title of test. Can not be null or empty");
            descriptor.Field(x => x.Description).
                       Type<NonNullType<StringType>>().
                       Description("Test must have short or long description");
            descriptor.Field(x => x.Questions).
                       Type<NonNullType<ListType<QuestionInput>>>().
                       Description("Test cannot be created without any questions!");
        }
    }
}
