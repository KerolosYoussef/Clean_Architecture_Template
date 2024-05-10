using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Permission
{
    public record PermissionResponse(Guid Id, string Name, string Module)
    {

    }
}
