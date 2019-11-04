using AutoMapper;
using CW.TestSystem.BusinessLogic.Types.InputModels;
using CW.TestSystem.Model.CoreEntities;

namespace CW.TestSystem.BusinessLogic.Infrastructure.Mapping
{
    public class InputModelsProfile : Profile
    {
        public InputModelsProfile()
        {
            CreateMap<TestInput, Test>();
            CreateMap<QuestionInput, Question>();
            CreateMap<AnswerInput, Answer>();
        }
    }
}
