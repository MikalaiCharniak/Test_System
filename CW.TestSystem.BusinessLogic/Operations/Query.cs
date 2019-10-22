using CW.TestSystem.Model.CoreEntities;
using CW.TestSystem.DataProvider.DbInfrastracture;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CW.TestSystem.BusinessLogic.Operations
{
    public class Query
    {
        private readonly TestSystemDbContext _context;
        public Query(TestSystemDbContext context)
        {
            _context = context;
        }

        public Test GetTest(Guid id)
        {
            var test  =_context.Tests.SingleOrDefault(x => x.Id == id);
            return test;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _context.Tags;        
        }

        public IEnumerable<Test> GetAllTest()
        {
            return _context.Tests;
        }
    }
}
