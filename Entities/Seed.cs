using Entities.Enum;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class Seed
    {
        public static async Task SeedData(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = GetUsers();

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Ydnay123.");
                    await userManager.AddToRoleAsync(user, RoleEnum.Administrador.ToString());
                }
            }
        }
        private static List<User> GetUsers() => new List<User>
        {
            new User()
            {
                Name = "Admin",
                UserName = "Admin",
                Email = "skullcandy961205@gmail.com",
                Activo = true,
                Biography = "Administrador web",
                PhoneNumber = "+5358474416"
            }

        };
    }
}
