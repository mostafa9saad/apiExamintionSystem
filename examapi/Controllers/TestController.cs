using examapi.DTO;
using examapi.Models;
using examapi.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace examapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private Itest _test;
        public TestController(Itest test)
        {
            _test = test;
        }
        [HttpGet]
        public async Task<ActionResult> getAllTest()
        {
            List<Test> tests = await _test.getAll();
            List<testDTO> listtest = new List<testDTO>();
            foreach (var item in tests)
            {
                testDTO showtests = new testDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    image = item.Img
                };
                listtest.Add(showtests);

            }

            return Ok(listtest);
        }
        [HttpPost]
        public async Task<ActionResult> createTest(Test test)
        {
            await _test.createTest(test);
            return Created("", test);
        }

    }
}
