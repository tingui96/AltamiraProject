using CryptoHelper;
using Entities.Enum;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    UserName = "Admin",
                    Email = "skullcandy961205@gmail.com",
                    Password = Crypto.HashPassword("Ydnay123."),
                    Activo = true,
                    Biography = "Administrador web",
                    Phone = "+5358474416",
                    RoleId = 1 ,
                    });
        }
    }
}
