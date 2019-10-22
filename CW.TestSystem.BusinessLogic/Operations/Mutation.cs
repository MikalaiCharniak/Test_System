using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using System.Threading.Tasks;

namespace CW.TestSystem.BusinessLogic.Operations
{
    public class Mutation
    {
        private readonly TestSystemDbContext _context;
        public Mutation(TestSystemDbContext context)
        {
            _context = context;
        }

        public async Task<Test> CreateTest(string title, string description)
        {
            var test = new Test() { Title = title, Description = description };
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<Tag> CreateTag(string title)
        {
            var tag = new Tag() { Title = title };
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
