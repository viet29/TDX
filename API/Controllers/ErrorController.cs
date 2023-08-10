using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly DataContext _context;

        public ErrorController(DataContext context)
        {
            this._context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<String> GetSecret()
        {
            return "secret";
        }

        [HttpGet("notfound")]
        public ActionResult<User> GetNotFound()
        {
            var u = _context.Users.Find(-1);

            if (u == null)
                return NotFound();
           
            return u;
        }

        [HttpGet("servererror")]
        public ActionResult<string> GetServerError()
        {
                var u = _context.Users.Find(-1);
                return u.ToString();
        }

        [HttpGet("badrequest")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Not gud request");
        }
    }
}
