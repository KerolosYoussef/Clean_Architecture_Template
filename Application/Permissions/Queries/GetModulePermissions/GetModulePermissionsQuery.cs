using Domain.PermissionAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Queries.GetModulePermissions
{
    public record GetModulePermissionsQuery(string Module) : IRequest<ErrorOr<List<string>>> {} 
}
