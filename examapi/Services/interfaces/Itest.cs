using examapi.Models;

namespace examapi.Services.interfaces
{
    public interface Itest
    {
        public Task<List<Test>> getAll();
        public Task<Test> createTest(Test test);
        public Task<List<Test>> getAllTestQues(int id);
    }
}
