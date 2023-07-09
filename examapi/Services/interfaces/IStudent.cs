using examapi.Models;

namespace examapi.Services.interfaces
{
    public interface IStudent
    {
        public Task<Student> addSTD(Student student);
        public Task<Student> getbyuserAndPass(string email, string pass);
        public Task<List<Student>> getAll();
    }
}
