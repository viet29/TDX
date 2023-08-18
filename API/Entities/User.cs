using API.Extensions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("User")]
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; } 
        public DateOnly DOB { get; set; }
        public string Gender { get; set; }
        public string Province { get; set; }
        public string School { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set;} = DateTime.Now;

        public Photo AvatarImg { get; set; }

        public ICollection<Article> Articles { get; set; }

        public  ICollection<UserRole> UserRoles { get; set; }
    }
}
