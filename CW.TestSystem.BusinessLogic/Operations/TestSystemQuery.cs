using System;
using CW.TestSystem.BusinessLogic.Types;
using CW.TestSystem.DataProvider.DbInfrastracture;
using GraphQL.Types;

namespace CW.TestSystem.BusinessLogic.Operations
{
    public class TestSystemQuery : ObjectGraphType <object>
    {
        public TestSystemQuery(TestSystemDbContext db)
        {
            Name = "Query";
            Field<TestType>().Description("Get Test by specific Guid Id")
                             .Name("Test")
                             .ResolveAsync(async context => await db.Tests.FindAsync(context.GetArgument<Guid>("id")));
        }
    }
}