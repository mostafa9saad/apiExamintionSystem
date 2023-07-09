using examapi.DTO;
using examapi.Models;
using examapi.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace examapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private IStudent std;

        public AcountController(IStudent std)
        {
            this.std = std;
        }
        [HttpPost]
        public async Task<ActionResult> login(userLoginDTO user)
        {
            Student s = await std.getbyuserAndPass(user.Email, user.Password);
            if (s == null)
            {
                return Unauthorized();
            }


            List<Claim> userdate = new List<Claim>();
            userdate.Add(new Claim("id", s.Id.ToString()));
            userdate.Add(new Claim("Email", user.Email));
            userdate.Add(new Claim("fName", s.Fname));
            userdate.Add(new Claim("lName", s.Lname));
            userdate.Add(new Claim("role", s.Role));



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
    }
}
