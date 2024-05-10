using Domain.PermissionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Helpers
{
    public partial class OrderByHelpers
    {
        public class Permissions
        {
            public static Expression<Func<Permission, object>>? GetByOrderType(string order)
            {
                order = order.ToLower();
                return order switch
                {
                    "id" => (p => p.Id),
                    "name" => (p => p.Name),
                    "module" => (p => p.Module),
                    _ => (p => p.Id),
                };
            }
        }
    }
}
