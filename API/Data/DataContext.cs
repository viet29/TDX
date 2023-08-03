using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        DbSet<Student> students { get; set; }
        DbSet<Admin> admins { get; set; }
        DbSet<Article> articles { get; set; }

    }
}
