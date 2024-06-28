using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories;

namespace Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        
        }

       
    
}
