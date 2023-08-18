using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRoles(UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);
            if (users == null) return;

            var roles = new List<Role>
            {
                new Role{Name = "Admin"},
                new Role{Name = "Manager"},
                new Role{Name = "Teacher"},
                new Role{Name = "Student"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Abc123456789");
                await userManager.AddToRoleAsync(user, "Student");
            }

            var admin = new User
            {
                UserName = "viet29",
                Email = "quocviet.pham291@gmail.com",
                Gender = "Nam",
                PhoneNumber = "0975196379",
                Province = "Hà Nội"
            };

            await userManager.CreateAsync(admin, "Viet246810");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Manager" });
        }

        //public static async Task ClearConnections(DataContext context)
        //{
        //    context.Connections.RemoveRange(context.Connections);
        //    await context.SaveChangesAsync();
        //}
    }
}
