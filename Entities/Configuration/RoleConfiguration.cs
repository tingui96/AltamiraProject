using Entities.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Entities.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = RoleEnum.Viewer.ToString(),
                },
                new IdentityRole
                {
                    Name = RoleEnum.Artist.ToString(),
                },
                new IdentityRole
                {
                    Name = RoleEnum.Administrador.ToString()
                });
        }
    }
}
