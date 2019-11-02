using CW.TestSystem.Model.CoreEntities;
using CW.TestSystem.BusinessLogic.Infrastructure.Extensions;
using HotChocolate.Types;
using CW.TestSystem.DataProvider.DbInfrastracture;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CW.TestSystem.BusinessLogic.Types.Models
{
    public class ResultType : ObjectType<Result>
    {
        protected override void Configure(IObjectTypeDescriptor<Result> descriptor)
        {
            descriptor.Field(x => x.Id).
                Type<NonNullType<IdType>>().
                Description("Unique Guid Id of Result");
            descriptor.Field(x => x.CreateDate).
                Type<NonNullType<DateTimeType>>().
                Description("Date of pass test (and create this result)");
            descriptor.Field(x => x.User).
                Type<NonNullType<UserType>>().
                Description("Represent user, which pass test and get this result").
                Resolver(async ctx =>
                {
                    var dbContext = ctx.Service<TestSystemDbContext>();
                    var user = dbContext.Results.Include(x => x.User).
                    Where(x => x.Id == ctx.GetGuidId()).Select(x => x.User);
                    return await user.FirstOrDefaultAsync();
                });
            descriptor.Field(x => x.Test).
                Type<NonNullType<TestType>>().
                Description("Test, which was passed for getting this result").
                Resolver(async ctx =>
                {
                    var dbContext = ctx.Service<TestSystemDbContext>();
                    var user = dbContext.Results.Include(x => x.Test).
                    Where(x => x.Id == ctx.GetGuidId()).Select(x => x.Test);
                    return await user.FirstOrDefaultAsync();
                });
        }
    }
}