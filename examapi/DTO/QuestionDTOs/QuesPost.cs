using examapi.DTO.answerDTOs;

namespace examapi.DTO.QuestionDTOs
{
    public class QuesPost
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string type { get; set; }
        public int TestId { get; set; }
        public List<AnswerPost> Answers { get; set; }
    }
}
