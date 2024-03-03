using Entities.Enum;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Entities.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = 1,
                    Name = RoleEnum.Administrador.ToString()
                },
                new Role
                {
                    Id = 2,
                    Name = RoleEnum.Artist.ToString(),
                },
                new Role
                {
                    Id = 3,
                    Name = RoleEnum.Viewer.ToString(),
                });
        }
    }
}
