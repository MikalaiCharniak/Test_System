using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate;
using System;

namespace CW.TestSystem.BusinessLogic.Operations
{
    public class Query
    {
        public Test GetTest([Service] TestSystemDbContext context,Guid id)
        {
            return context.Tests.Find(id);
        }
    }
}
