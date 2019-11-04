using AutoMapper;
using CW.TestSystem.BusinessLogic.Types.InputModels;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate;
using System.Threading.Tasks;

namespace CW.TestSystem.BusinessLogic.Operations
{
    public class Mutation
    {
        public async Task<Test> CreateTestAsync([Service] TestSystemDbContext context,
            [Service]Mapper mapper, TestInput testInput)
        {
            var test = await context.Tests.AddAsync(mapper.Map<Test>(testInput));
            await context.SaveChangesAsync();
            return test.Entity;
        }
    }
}
