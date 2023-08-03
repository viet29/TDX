using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Student : IdentityUser
    {
        public string Fullname { get; set; } 

        public DateTime DOB { get; set; }

        public string Description { get; set; }

        

    }
}
