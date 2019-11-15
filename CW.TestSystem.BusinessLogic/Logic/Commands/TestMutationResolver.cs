using HotChocolate;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using System.Threading.Tasks;

namespace CW.TestSystem.BusinessLogic.Logic.Commands
{
    public class TestMutationResolver
    {
        public async Task<Test> CreateTestAsync([Service] TestSystemDbContext context, Test testInput)
        {
            var test = await context.Tests.AddAsync(testInput);
            await context.SaveChangesAsync();
            return test.Entity;
        }
    }
}