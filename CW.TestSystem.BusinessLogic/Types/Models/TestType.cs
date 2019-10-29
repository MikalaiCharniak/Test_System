using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;
using CW.TestSystem.DataProvider.DbInfrastracture;
using HotChocolate;

namespace CW.TestSystem.BusinessLogic.Types.Models
{
    public class TestType : ObjectType<Test>
    {

        private TestSystemDbContext _dbContext;
        protected override void Configure(IObjectTypeDescriptor<Test> descriptor)
        {
            descriptor.Field(x => x.Id).
                       Type<NonNullType<IdType>>().
                       Description("Unique Guid id of Test");
            descriptor.Field(x => x.Title).
                       Type<StringType>().
                       Description("Title of Test. Describe the main theme of Test");
            descriptor.Field(x => x.Description).
                       Type<StringType>().
                       Description("Description of Test");
            descriptor.Field(x => x.CreateDate).
                       Type<DateType>().
                       Description("Test create date");
            descriptor.Field(x => x.Questions).
                       Type<NonNullType<ListType<QuestionType>>>().
                       Description("Set of questions for Test").
                       Resolver(ctx =>
                       {
                           _dbContext ??= ctx.Service<TestSystemDbContext>();
                           var questions = _dbContext.Questions;
                           return questions;
                       });
            descriptor.Field(x => x.Tags).
                       Type<ListType<TagType>>().
                       Description("Set of tags for Test").
                       Resolver(ctx =>
                       {
                           _dbContext ??= ctx.Service<TestSystemDbContext>();
                           var tags = _dbContext.Tags;
                           return tags;
                       });
        }
    }
}
