using examapi.Models;
using examapi.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace examapi.Services
{
    public class studentServises : IStudent
    {
        private examSystemContext _db;

        public studentServises(examSystemContext db)
        {
            _db = db;
        }

        public async Task<Student> addSTD(Student student)
        {
            Student std = _db.Student.FirstOrDefault(o => o.Email == student.Email);
            if (std != null)
            {
                return null;
            }
            if (student == null)
            {
                return null;
            }
            else
            {
                _db.Student.Add(student);
                //_db.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _db.SaveChangesAsync();
                return student;
            }
        }

        public async Task<List<Student>> getAll()
        {
            List<Student> stdlist = await _db.Student.Where(a => a.Role != "admin").ToListAsync();

            return stdlist;
        }

        public async Task<Student> getbyuserAndPass(string email, string pass)
        {
            if (email != null && pass != null)
            {
                return await _db.Student.FirstOrDefaultAsync(o => o.Email == email && o.Password == pass);
            }
            return null;
        }
        public async Task<Student> getbyEmail(string email)
        {
            return await _db.Student.FirstOrDefaultAsync(o => o.Email == email);
        }
    }
}
