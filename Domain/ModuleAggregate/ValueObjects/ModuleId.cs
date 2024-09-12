using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModuleAggregate.ValueObjects
{
    public sealed class ModuleId : ValueObject
    {
        public Guid Value { get; private set; }
        private ModuleId(Guid value)
        {
            Value = value;
        }
        public static ModuleId CreateUnique()
        {
            return new ModuleId(Guid.NewGuid());
        }
        public static ModuleId Create(Guid value)
        {
            return new ModuleId(value);
        }
        private ModuleId()
        {

        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
