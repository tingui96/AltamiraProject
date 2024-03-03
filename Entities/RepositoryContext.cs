using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var currentDate = DateTime.UtcNow;

            var currentChanges = ChangeTracker.Entries<Entity>();
            var currentChangedList = currentChanges.ToList();

            foreach (var entry in currentChangedList)
            {
                var entity = entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = currentDate;
                        entry.Entity.ModifiedAt = currentDate;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = currentDate;
                        entry.Entity.CreatedAt = entry.OriginalValues.GetValue<DateTime>("CreatedAt");
                        break;

                    case EntityState.Detached:
                        break;

                    case EntityState.Deleted:
                        break;

                    case EntityState.Unchanged:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
