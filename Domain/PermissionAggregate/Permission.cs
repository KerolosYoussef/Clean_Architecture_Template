using Domain.Common.Models;
using Domain.PermissionAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PermissionAggregate
{
    public sealed class Permission : AggregateRoot<PermissionId>
    {
        public string Module { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        private Permission(string module, string name)
        {
            Id = PermissionId.CreateUnique();
            Module = module;
            Name = name;
        }

        public static Permission Create(string module, string name)
        {
            return new Permission(module, name);
        }
    }
}
