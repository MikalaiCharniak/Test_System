using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Types;

namespace CW.TestSystem.BusinessLogic.Types.InputModels
{
    public class TagInput : InputObjectType<Tag>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Tag> descriptor)
        {
            descriptor.Field(x => x.Id).
                       Type<IdType>().
                       Description("Unique Tag Id. Should be use only for updating ");
            descriptor.Field(x => x.Title).
                       Type<StringType>().
                       Description("Title, which describe current tag");
        }
    }
}
