using examapi.Models;

namespace examapi.Services.interfaces
{
    public interface IQuestions
    {
        public Task<List<Questions>> getAllQues(int id);
        public Task<Questions> AddQues(Questions questions);
    }
}
