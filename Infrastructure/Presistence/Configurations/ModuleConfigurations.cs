using Domain.ModuleAggregate;
using Domain.ModuleAggregate.ValueObjects;
using Domain.PermissionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistence.Configurations
{
    public class ModuleConfigurations : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            ConfigurePermissionTable(builder);
        }

        private void ConfigurePermissionTable(EntityTypeBuilder<Module> builder)
        {
            builder.ToTable("Modules");
            builder.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ModuleId.Create(value));
        }
    }
}
