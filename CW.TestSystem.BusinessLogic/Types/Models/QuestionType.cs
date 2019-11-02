using System.Linq;
using CW.TestSystem.BusinessLogic.Infrastructure.Extensions;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace CW.TestSystem.BusinessLogic.Types.Models
{
    public class QuestionType : ObjectType<Question>
    {
        protected override void Configure(IObjectTypeDescriptor<Question> descriptor)
        {
            descriptor.Field(x => x.Id).
                       Type<NonNullType<IdType>>().
                       Description("Unique Guid id of Test");
            descriptor.Field(x => x.Text).
                       Type<NonNullType<StringType>>().
                       Description("Represent text view of text");
            descriptor.Field(x => x.CreateDate).
                       Type<NonNullType<DateTimeType>>().
                       Description("Question create date");
            descriptor.Field(x => x.Answers).
                       Type<ListType<AnswerType>>().
                       Resolver(async ctx =>
                       {
                           var dbContext = ctx.Service<TestSystemDbContext>();
                           var answers = dbContext.Answers.Where(x => x.QuestionId == ctx.GetGuidId());
                           return await answers.ToListAsync();
                       });
            descriptor.Field(x => x.Tests).
                       Type<ListType<TestType>>().
                       Description("Set of test, which inlcude this question").
                       Resolver(async ctx =>
                       {
                           var dbContext = ctx.Service<TestSystemDbContext>();
                           var tests = dbContext.Questions.Include(x => x.Tests).ThenInclude(x => x.Test).
                           Where(x => x.Id == ctx.GetGuidId()).SelectMany(x => x.Tests).
                           Select(x => x.Test);
                           return await tests.ToListAsync();
                       });
            descriptor.Field(x => x.Tags).
                       Type<ListType<TagType>>().
                       Description("Set of tags for current question").
                       Resolver(async ctx =>
                       {
                           var dbContext = ctx.Service<TestSystemDbContext>();
                           var tags = dbContext.Questions.Include(x => x.Tags).ThenInclude(x => x.Tag).
                           Where(x => x.Id == ctx.GetGuidId()).SelectMany(x => x.Tags).
                           Select(x => x.Tag);
                           return await tags.ToListAsync();
                       });
        }
    }
}