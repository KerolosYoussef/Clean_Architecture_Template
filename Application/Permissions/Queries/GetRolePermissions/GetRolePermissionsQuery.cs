using Application.Common.DTOs;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Queries.GetRolePermissions
{
    public record GetRolePermissionsQuery(string RoleId) : IRequest<ErrorOr<PermissionsDto>>;
}
