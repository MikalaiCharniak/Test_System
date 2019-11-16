using HotChocolate;
using Microsoft.EntityFrameworkCore;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using System.Threading.Tasks;
using System;

namespace CW.TestSystem.BusinessLogic.Logic.Commands
{
    public class TagMutationResolver
    {
        public async Task<Tag> CreateTagAsync([Service] TestSystemDbContext context, Tag inputTag)
        {
            var tag = await context.Tags.AddAsync(inputTag);
            await context.SaveChangesAsync();
            return tag.Entity;
        }

        public async Task<Tag> UpdateTagAsync([Service] TestSystemDbContext context, Tag updateTag)
        {
            var tag = context.Tags.Update(updateTag);
            await context.SaveChangesAsync();
            return tag.Entity;
        }
        
        public async Task<bool> DeleteTagAsync([Service] TestSystemDbContext context, Guid id)
        {
            var state = context.Tags.Remove(await context.Tags.FindAsync(id)).State;
            await context.SaveChangesAsync();
            return state == EntityState.Deleted ? true : false; 
        }
    }
}
