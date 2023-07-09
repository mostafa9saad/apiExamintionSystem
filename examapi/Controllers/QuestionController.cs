using AutoMapper;
using examapi.DTO.answerDTOs;
using examapi.DTO.QuestionDTOs;
using examapi.Models;
using examapi.Services.interfaces;
using examapi.Services.question;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace examapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class QuestionController : ControllerBase
    {
        private IQuestions _services;
        private readonly IMapper _mapper;
        public QuestionController(IQuestions services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getALLQues(int id)
        {
            List<Questions> list = await _services.getAllQues(id);
            List<QuestionsForTestDTOs> qes = new List<QuestionsForTestDTOs>();
            foreach (Questions test in list)
            {
                List<AnswerDTOs> a = new List<AnswerDTOs>();
                foreach (Answers answers in test.Answers)
                {
                    AnswerDTOs answer = new AnswerDTOs()
                    {
                        answer = answers.Answer,
                        isTrue = bool.Parse(answers.IsTrue),

                    };
                    a.Add(answer);
                }
                QuestionsForTestDTOs oneque = new QuestionsForTestDTOs()
                {
                    Body = test.Body,
                    type = test.Type,
                    Answers = a,
                };
                qes.Add(oneque);

            }
            return Ok(qes);
        }
        [HttpPost]
        public async Task<ActionResult> AddQues(QuesPost Ques)
        {


            var newQues = _mapper.Map<Questions>(Ques);
            Questions questions = await _services.AddQues(newQues);
            return Created("", questions);
        }
    }
}
