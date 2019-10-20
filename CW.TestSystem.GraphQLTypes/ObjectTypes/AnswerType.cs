using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;

namespace CW.TestSystem.GraphQLTypes.ObjectTypes
{
    public class AnswerType : ObjectType<Answer>
    {
        protected override void Configure(IObjectTypeDescriptor<Answer> descriptor)
        {
            descriptor.Field(x => x.Id).
                      Type<NonNullType<IdType>>().
                      Name("Id").
                      Description("Guid unique id for specific Answer");
        }
    }
}
