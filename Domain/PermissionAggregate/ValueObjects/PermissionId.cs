using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PermissionAggregate.ValueObjects
{
    public sealed class PermissionId : ValueObject
    {
        public Guid Value { get; private set; }
        private PermissionId(Guid value)
        {
            Value = value;
        }
        public static PermissionId CreateUnique()
        {
            return new PermissionId(Guid.NewGuid());
        }
        public static PermissionId Create(Guid value)
        {
            return new PermissionId(value);
        }
        private PermissionId()
        {

        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
