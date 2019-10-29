using CW.TestSystem.Model.CoreEntities;
using HotChocolate.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors.Definitions;

namespace CW.TestSystem.BusinessLogic.Types.Models
{
    public class QuestionType : ObjectType<Question>
    {
        protected override ObjectTypeDefinition CreateDefinition(IInitializationContext context)
        {
            return base.CreateDefinition(context);
        }
    }
}
