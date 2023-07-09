using AutoMapper;
using examapi.DTO.answerDTOs;
using examapi.DTO.QuestionDTOs;
using examapi.Models;

namespace examapi.Services
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<QuesPost, Questions>();
            CreateMap<AnswerPost, Answers>();
        }
    }
}
