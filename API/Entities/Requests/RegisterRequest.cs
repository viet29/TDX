using System.ComponentModel.DataAnnotations;

namespace API.Entities.Requests
{
    public class RegisterRequest
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public DateOnly DOB { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Gender { get; set; }
    }
}
