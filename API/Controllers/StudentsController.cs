using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StudentsController : BaseApiController
    {

        private readonly DataContext _context;

        public StudentsController(DataContext context)
        {
            this._context = context;
        }

        //[HttpGet]
        //public async Task<IEnumerable<Student>> GetStudents()
        //{
        //    var students = new List<Student>()
        //    {

        //    };
        //}
    }
}
