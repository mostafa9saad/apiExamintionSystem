using examapi.DTO.answerDTOs;

namespace examapi.DTO.QuestionDTOs
{
    public class QuestionsForTestDTOs
    {
        public string Body { get; set; }
        public string type { get; set; }
        public List<AnswerDTOs> Answers { get; set; }


    }
}
