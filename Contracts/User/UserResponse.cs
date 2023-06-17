using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.User
{
    public record UserResponse(string Id, string UserName, string Email, string DisplayName, string[] Roles)
    {
    }
}
