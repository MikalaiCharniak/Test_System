using CW.TestSystem.Model.CoreEntities;
using CW.TestSystem.BusinessLogic.Infrastructure.Extensions;
using HotChocolate.Types;
using CW.TestSystem.DataProvider.DbInfrastracture;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CW.TestSystem.BusinessLogic.Types.Models
{
    public class TestType : ObjectType<Test>
    {
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
                           var _dbContext = ctx.Service<TestSystemDbContext>();
                           var questions = _dbContext.Tests.Include(x => x.Questions).ThenInclude(x => x.Question).
                           Where(x => x.Id == ctx.GetGuidId()).SelectMany(x => x.Questions).
                           Select(x => x.Question);
                           return questions.ToList();
                       });
            descriptor.Field(x => x.Tags).
                       Type<ListType<TagType>>().
                       Description("Set of tags for Test").
                       Resolver(ctx =>
                       {
                           var _dbContext = ctx.Service<TestSystemDbContext>();
                           var tags = _dbContext.Tests.Include(x => x.Tags).ThenInclude(x => x.Tag).
                           Where(x => x.Id == ctx.GetGuidId()).SelectMany(x => x.Tags).
                           Select(x => x.Tag);
                           return tags;
                       });
        }
    }
}