using examapi.Models;
using examapi.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace examapi.Services.test
{
    public class TestServcise : Itest
    {
        private examSystemContext _db;
        public TestServcise(examSystemContext db)
        {
            _db = db;

        }

        public async Task<Test> createTest(Test test)
        {
            _db.Test.Add(test);
            await _db.SaveChangesAsync();
            return test;
        }

        public async Task<List<Test>> getAll()
        {
            return await _db.Test.ToListAsync();
        }
        public async Task<List<Test>> getAllTestQues(int id)
        {
            return await _db.Test.Where(o => o.Id == id).Include(o => o.Questions).ThenInclude(a => a.Answers).ToListAsync();
        }
    }
}
