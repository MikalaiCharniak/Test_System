using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate;
using System.Threading.Tasks;

namespace CW.TestSystem.BusinessLogic.Operations
{
    public class Mutation
    {
        public async Task<Test> CreateTestAsync([Service] TestSystemDbContext context, Test testInput)
        {
            var test = await context.Tests.AddAsync(testInput);
            await context.SaveChangesAsync();
            return test.Entity;
        }

        public async Task<Question> CreateQuestionAsync([Service] TestSystemDbContext context,
             Question questionInput)
        {
            var question = await context.Questions.AddAsync(questionInput);
            await context.SaveChangesAsync();
            return question.Entity;
        }
    }
}
