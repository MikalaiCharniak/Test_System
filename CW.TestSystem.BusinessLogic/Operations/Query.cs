using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CW.TestSystem.BusinessLogic.Operations
{
    public class Query
    {
        public async Task<Test> GetTestAsync([Service] TestSystemDbContext context, Guid id)
        {
            return await context.Tests.FindAsync(id);
        }

        public async Task<IEnumerable<Test>> GetTestsAsync([Service] TestSystemDbContext context)
        {
            return await context.Tests.ToListAsync();
        }
           
        public async Task<Question> GetQuestionAsync([Service] TestSystemDbContext context, Guid id)
        {
            return await context.Questions.FindAsync(id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync([Service] TestSystemDbContext context)
        {
            return await context.Questions.ToListAsync();
        }

        public async Task<Tag> GetTagAsync([Service] TestSystemDbContext context, Guid id)
        {
            return await context.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync([Service] TestSystemDbContext context)
        {
            return await context.Tags.ToListAsync();
        }
        public async Task<Result> GetResultAsync([Service] TestSystemDbContext context, Guid id)
        {
            return await context.Results.FindAsync(id);
        }
        public async Task<IEnumerable<Result>> GetResultsAsync([Service] TestSystemDbContext context)
        {
            return await context.Results.ToListAsync();
        }
    }
}
