using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        [HttpGet("")]       
        
        public IActionResult GetEmployee([FromKeyedServices("employee")]IEmployee employee)
        {
            return Ok(employee.GetMessage());
        }
        [HttpGet("temp")]
        public IActionResult GetTempEmployee([FromKeyedServices("tempemployee")] IEmployee temployee)
        { 
            return Ok(temployee.GetMessage());
        }
    }
}
