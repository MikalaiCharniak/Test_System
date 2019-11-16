using HotChocolate;
using Microsoft.EntityFrameworkCore;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using System.Threading.Tasks;
using System;

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

        public async Task<Test> UpdateTestAsync([Service] TestSystemDbContext context, Test updateTest)
        {
            var test = context.Tests.Update(updateTest);
            await context.SaveChangesAsync();
            return test.Entity;
        }

        public async Task<bool> DeleteTestAsync([Service] TestSystemDbContext context, Guid id)
        {
            var state =  context.Tests.Remove(await context.Tests.FindAsync(id)).State;
            await context.SaveChangesAsync();
            var result = state == EntityState.Deleted ? true : false;
            return result;
        }
    }
}