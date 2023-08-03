using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class IdentityDataContext : IdentityDbContext<Admin, IdentityRole, string>
    {
        public IdentityDataContext(DbContextOptions options) : base(options) 
        { 
            
        }
    }
}
