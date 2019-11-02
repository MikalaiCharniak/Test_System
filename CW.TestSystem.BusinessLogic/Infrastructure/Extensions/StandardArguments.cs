using HotChocolate.Resolvers;
using System;

namespace CW.TestSystem.BusinessLogic.Infrastructure.Extensions
{
    public static class StandardArguments
    {
        public static Guid GetGuidId(this IResolverContext resolverContext)
        {
            return resolverContext.Variables.GetVariable<Guid>("id");
        }
    }
}
