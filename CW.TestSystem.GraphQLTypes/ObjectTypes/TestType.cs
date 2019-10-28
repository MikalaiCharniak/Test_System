using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW.TestSystem.GraphQLTypes.ObjectTypes
{
    public class TestType : ObjectType<Test>
    {
        protected override void Configure(IObjectTypeDescriptor<Test> descriptor)
        {
            descriptor.Include<TestResolvers>();

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
                       Description("Set of test questions").
                       Resolver(ctx =>
                       {
                           var dbContext = ctx.Service<TestSystemDbContext>();
                           dbContext.Tests.Where(x => x.Id == Guid.NewGuid());
                           var questions = dbContext.Tests.Include(x => x.Questions).ThenInclude(x => x.Question).
                           SingleOrDefault(x => x.Id == ctx.Variables.GetVariable<Guid>("id")).Questions.
                           Select(x => x.Question).
                           ToList();
                           return questions;
                       });
            descriptor.Field(x => x.Tags).
                       Type<ListType<TagType>>().
                       Name("Tags").
                       Description("Set of specific tags, which can " +
                       "describe test, like difficult, theme and etc. way").
                       Resolver(context => context.Service<TestSystemDbContext>().Tags.ToList());
            descriptor.Field(x => x.Results).
                       Type<ListType<ResultType>>().
                       Name("Results").
                       Description("Set of user's results of this test");
        }


        [GraphQLResolverOf(typeof(Test))]
        public class TestResolvers
        {
            private IEnumerable<Question> GetTestQuestions([Service]TestSystemDbContext dbContext,
            IResolverContext resolverContext)
            {

                var questions = dbContext.Tests.Find(resolverContext.Variables.GetVariable<Guid>("id")).
                                          Questions.Select(x => x.Question);
                return questions;
            }
        }
    }
}