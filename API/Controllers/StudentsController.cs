using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public StudentsController() : base() {
            
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = new List<Student>()
            {
                
            };
        }
    }
}
