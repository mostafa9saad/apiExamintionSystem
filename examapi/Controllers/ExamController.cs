using examapi.DTO.ExamsDTOs;
using examapi.Models;
using examapi.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace examapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExamController : ControllerBase
    {
        private IExam _exam;
        public ExamController(IExam exam)
        {
            _exam = exam;
        }
        [HttpGet]
        public async Task<ActionResult> getAll()
        {
            List<Exam> exams = await _exam.getAllExam();
            List<ExamDTO> viewExam = new List<ExamDTO>();

            foreach (var item in exams)
            {
                ExamDTO one = new ExamDTO()
                {
                    fName = item.Std.Fname,
                    lName = item.Std.Lname,
                    Email = item.Std.Email,
                    testName = item.Test.Name,
                    degree = item.Degree,

                };
                viewExam.Add(one);
            }

            return Ok(viewExam);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getExamsById(int id)
        {
            List<Exam> exams = await _exam.getExamsByID(id);
            List<ExamDTO> viewExam = new List<ExamDTO>();

            foreach (var item in exams)
            {
                ExamDTO one = new ExamDTO()
                {
                    fName = item.Std.Fname,
                    lName = item.Std.Lname,
                    Email = item.Std.Email,
                    testName = item.Test.Name,
                    degree = item.Degree,

                };
                viewExam.Add(one);
            }

            return Ok(viewExam);
        }
        [HttpPost]
        public async Task<ActionResult> addExam(Exam exam)
        {
            await _exam.AddExams(exam);
            return Created("", exam);
        }
        [HttpPut]
        public async Task<ActionResult> update(Exam exam)
        {
            await _exam.updateExam(exam);
            return NoContent();
        }
    }
}
