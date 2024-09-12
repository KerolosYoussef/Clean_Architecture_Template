using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        public static Error RoleNotFound => Error.NotFound(
            code: "Roles.NotFound",
            description: "Role not found"
        );
    }
}
