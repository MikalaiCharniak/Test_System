using AutoMapper;
using CW.TestSystem.BusinessLogic.Types.InputModels;
using CW.TestSystem.Model.CoreEntities;

namespace CW.TestSystem.BusinessLogic.Infrastructure.Mapping
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<TestInput, Test>();
        }
    }
}