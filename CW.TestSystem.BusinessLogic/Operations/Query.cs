using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using CW.TestSystem.Model.CoreEntities;
using CW.TestSystem.DataProvider.DbInfrastracture;

namespace CW.TestSystem.BusinessLogic.Operations
{
    public class Query
    {
        public async Task<Test> GetTestAsync([Service] TestSystemDbContext context, Guid id) =>
               await context.Tests.SingleOrDefaultAsync(x => x.Id == id);
        public async Task<Tag> GetTagAsync([Service] TestSystemDbContext context, Guid id) =>
               await context.Tags.FindAsync(id);
        public async Task<Result> GetResultAsync([Service] TestSystemDbContext context, Guid id) =>
               await context.Results.FindAsync(id);
        public async Task<User> GetUserAsync([Service] TestSystemDbContext context, Guid id) =>
               await context.Users.FindAsync(id);
        public async Task<Question> GetQuestionAsync([Service] TestSystemDbContext context, Guid id) =>
               await context.Questions.FindAsync(id);
    }
}
