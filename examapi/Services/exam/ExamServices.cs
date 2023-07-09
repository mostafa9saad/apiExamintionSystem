using examapi.DTO.ExamsDTOs;
using examapi.Models;
using examapi.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace examapi.Services.exam
{
    public class ExamServices : IExam
    {
        private examSystemContext _db;
        public ExamServices(examSystemContext db)
        {
            _db = db;

        }
        public async Task<List<Exam>> getAllExam()
        {
            return await _db.Exam.Include(a => a.Test).Include(o => o.Std).ToListAsync();
        }

        public async Task<Exam> AddExams(Exam exam)
        {
            if (exam != null)
            {
                _db.Exam.Add(exam);
                await _db.SaveChangesAsync();

            }
            return exam;
        }
        public async Task<List<Exam>> getExamsByID(int id)
        {
            return await _db.Exam.Where(s => s.StdId == id).Include(a => a.Test).Include(o => o.Std).ToListAsync();
        }

        public async Task<Exam> updateExam(Exam exam)
        {
            if (exam == null)
            {
                return null;
            }
            else
            {
                _db.Entry(exam).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _db.SaveChangesAsync();
                return exam;
            }
        }
    }
}
