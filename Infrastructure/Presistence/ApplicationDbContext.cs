using Domain.UserAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.Entity<User>()
                .Property(u => u.Id)
                .HasMaxLength(36);

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(36);
                entity.Property(m => m.LoginProvider).HasMaxLength(36);
                entity.Property(m => m.ProviderKey).HasMaxLength(36);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(36);
                entity.Property(m => m.LoginProvider).HasMaxLength(36);
                entity.Property(m => m.Name).HasMaxLength(36);
            });

            base.OnModelCreating(builder);
        }
    }
}
