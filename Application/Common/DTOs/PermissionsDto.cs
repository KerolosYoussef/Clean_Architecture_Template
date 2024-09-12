using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs
{
    public record PermissionsDto(string RoleId, string RoleName, List<CheckboxDto> RoleClaims);
}
