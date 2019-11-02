using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CW.TestSystem.BusinessLogic.Operations
{
    public class Query
    {
        public async Task<Test> GetTestAsync([Service] TestSystemDbContext context,Guid id)
        {
            return await context.Tests.FindAsync(id);
        }
        public async Task<Question> GetQuestionAsync([Service] TestSystemDbContext context, Guid id)
        {
            return await context.Questions.FindAsync(id);
        }

        public async Task<Tag> GetTagAsync([Service] TestSystemDbContext context, Guid id)
        {
            return await context.Tags.FindAsync(id);
        }
        public async Task<Result> GetResultAsync([Service] TestSystemDbContext context, Guid id)
        {
            return await context.Results.FindAsync(id);
        }
    }
}
