using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;

namespace CW.TestSystem.GraphQLTypes.ObjectTypes
{
    public class ResultType : ObjectType<Result>
    {
        protected override void Configure(IObjectTypeDescriptor<Result> descriptor)
        {
            descriptor.Field(x => x.Id).
                       Type<NonNullType<IdType>>().
                       Name("Id").
                       Description("Guid unique id for specific Result");
        }
    }
}
