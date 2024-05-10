using Domain.PermissionAggregate;
using Domain.PermissionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistence.Configurations
{
    public class PermissionConfigurations : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            ConfigurePermissionTable(builder);
        }

        private void ConfigurePermissionTable(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");
            builder.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => PermissionId.Create(value));
        }
    }
}
