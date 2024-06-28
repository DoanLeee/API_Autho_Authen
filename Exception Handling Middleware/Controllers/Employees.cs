using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exception_Handling_Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employees : ControllerBase
    {
        [HttpGet("")]
        public async  Task<IActionResult> GetAll()
        {
            throw  new  Exception("Test Exception");
                return Ok(new[] { 1, 2, 3 });   
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById()
        {
            throw new NotImplementedException("This mrthod is not implement");
           
        }
    }
}
