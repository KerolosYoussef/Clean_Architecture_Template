using Application.Common;
using Application.Common.Interfaces.Sepcification;
using Application.Permissions.Common;
using Domain.PermissionAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Queries.GetAllPermissions
{
    public record GetAllPermissionsQuery(PermissionParams PermissionParams) : IRequest<ErrorOr<Pagination<Permission>>>
    {
    }
}
