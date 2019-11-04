using AutoMapper;
using CW.TestSystem.BusinessLogic.Types.InputModels;
using CW.TestSystem.Model.CoreEntities;

namespace CW.TestSystem.BusinessLogic.Infrastructure.Mapping
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionInput, Question>();
        }
    }
}
