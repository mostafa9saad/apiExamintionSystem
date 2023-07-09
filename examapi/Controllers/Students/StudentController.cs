using examapi.DTO;
using examapi.DTO.studentDTOs;
using examapi.Models;
using examapi.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace examapi.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private IStudent _std;

        public StudentController(IStudent std)
        {
            this._std = std;
        }

        [HttpPost]
        public async Task<ActionResult> register(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (student == null)
            {
                return BadRequest();
            }
            Student s = await _std.addSTD(student);
            if (s == null)
            {
                return BadRequest("this email is aready exist");
            }

            List<Claim> userdate = new List<Claim>();
            userdate.Add(new Claim("id", student.Id.ToString()));
            userdate.Add(new Claim("Email", student.Email));

            userdate.Add(new Claim("fName", s.Fname));
            userdate.Add(new Claim("lName", s.Lname));
            userdate.Add(new Claim("role", student.Role));

            string Key = "hi iam mostafa ahmed mahmoud saad";
            var secertyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

            var singcer = new SigningCredentials(secertyKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: userdate,
                signingCredentials: singcer,
                expires: DateTime.Now.AddDays(1)
                );
            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            LoginDTO l = new LoginDTO()
            {
                TOKEN = stringToken,

            };

            return Ok(l);

        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> getAllStd()
        {
            List<Student> list = await _std.getAll();
            List<showStdDTO> listshow = new List<showStdDTO>();
            foreach (Student student in list)
            {

                showStdDTO show = new showStdDTO()
                {
                    Id = student.Id,
                    fName = student.Fname,
                    lName = student.Lname,
                    Email = student.Email,
                    role = student.Role,

                };
                listshow.Add(show);
            }


            return Ok(listshow);



        }
    }
}
