using System.Linq;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.BusinessLogic.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CW.TestSystem.BusinessLogic.Types.Models
{
    public class TagType : ObjectType<Tag>
    {
        protected override void Configure(IObjectTypeDescriptor<Tag> descriptor)
        {
            descriptor.Field(x => x.Id).
                       Type<NonNullType<IdType>>().
                       Description("Unique Guid id of Tag");
            descriptor.Field(x => x.Title).
                       Type<NonNullType<StringType>>().
                       Description("Title of tag");
            descriptor.Field(x => x.Questions).
                       Type<ListType<QuestionType>>().
                       Description("Set of question, which contain this tag").
                       Resolver(async ctx =>
                       {
                           var dbContext = ctx.Service<TestSystemDbContext>();
                           var questions = dbContext.Questions.Include(x => x.Tags).ThenInclude(x => x.Tag).
                           Where(x => x.Tags.All(x => x.TagId == ctx.GetGuidId()));
                           return await questions.ToListAsync();
                       });

            descriptor.Field(x => x.Tests).
                       Type<ListType<TestType>>().
                       Description("Set of question, which contain this test").
                       Resolver(async ctx =>
                       {
                           var dbContext = ctx.Service<TestSystemDbContext>();
                           var tests = dbContext.Tests.Include(x => x.Tags).ThenInclude(x => x.Tag).
                           Where(x => x.Tags.All(x => x.TagId == ctx.GetGuidId()));
                           return await tests.ToListAsync();
                       });
        }
    }
}