using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class Admin : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string  Description { get; set; }
        public IdentityRole Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Article> Articles { get; set; }
    }
}
