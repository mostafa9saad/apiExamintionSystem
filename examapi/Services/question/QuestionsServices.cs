using examapi.Models;
using examapi.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace examapi.Services.question
{
    public class QuestionsServices : IQuestions
    {
        private examSystemContext _db;
        public QuestionsServices(examSystemContext db)
        {
            _db = db;

        }

        public async Task<Questions> AddQues(Questions questions)
        {
            if (questions != null)
            {

                await _db.Questions.AddAsync(questions);
                await _db.SaveChangesAsync();
            }
            return questions;
        }

        public async Task<List<Questions>> getAllQues(int id)
        {
            return await _db.Questions.Where(o => o.TestId == id).Include(a => a.Answers).ToListAsync();

        }
    }
}
