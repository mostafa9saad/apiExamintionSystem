using examapi.DTO.ExamsDTOs;
using examapi.Models;

namespace examapi.Services.interfaces
{
    public interface IExam
    {
        public Task<List<Exam>> getAllExam();
        public Task<Exam> AddExams(Exam exam);
        public Task<Exam> updateExam(Exam exam);
        public Task<List<Exam>> getExamsByID(int id);
    }
}
