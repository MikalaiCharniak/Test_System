using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;


namespace CW.TestSystem.GraphQLTypes.ObjectTypes
{
    public class TestType : ObjectType<Test>
    {
        protected override void Configure(IObjectTypeDescriptor<Test> descriptor)
        {
            descriptor.Field(x => x.Id).
                       Type<NonNullType<IdType>>().
                       Name("Id").
                       Description("Guid unique id for specific Test");
            descriptor.Field(x => x.Title).
                       Type<NonNullType<StringType>>().
                       Name("Title").
                       Description("Title of test. Can repeat");
            descriptor.Field(x => x.Description).
                       Type<StringType>().
                       Name("Description").
                       Description("Text which describe test");
            descriptor.Field(x => x.CreateDate).
                       Type<DateType>().
                       Name("CreateDate").
                       Description("Date, when test has been created");
            descriptor.Field(x => x.Questions).
                       Type<ListType<QuestionType>>().
                       Name("Questions").
                       Description("Set of test questions");
            descriptor.Field(x => x.Tags).
                       Type<ListType<TagType>>().
                       Name("Tags").
                       Description("Set of specific tags, which can " +
                       "describe test, like difficult, theme and etc. way");
            descriptor.Field(x => x.Results).
                       Type<ListType<ResultType>>().
                       Name("Results").
                       Description("Set of user's results of this test");
        }
    }
}