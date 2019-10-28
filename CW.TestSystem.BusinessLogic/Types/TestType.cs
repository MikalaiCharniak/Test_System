using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using GraphQL.Types;

namespace CW.TestSystem.BusinessLogic.Types
{
    public class TestType : ObjectGraphType<Test>
    {
        public TestType(TestSystemDbContext context)
        {
            Name = "Test";

            Field(x => x.Id).Description("Unique Id (Guid) of special Test");
            Field(x => x.Title).Description("Test title");
            Field(x => x.Description).Description("Describe content of Test");
        }
    }
}
