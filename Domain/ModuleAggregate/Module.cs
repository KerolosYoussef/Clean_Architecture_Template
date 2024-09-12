using Domain.Common.Models;
using Domain.ModuleAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModuleAggregate
{
    public sealed class Module : AggregateRoot<ModuleId>
    {
        public string Name { get; set; }

        private Module(string name)
        {
            Name = name;
        }

        public static Module Create(string name)
        {
            return new Module(name);
        }
    }
}
