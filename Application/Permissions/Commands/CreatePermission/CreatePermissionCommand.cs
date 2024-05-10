using Domain.PermissionAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands.CreatePermission
{
    public record CreatePermissionCommand(string Name, string Module) : IRequest<ErrorOr<Permission>> {}
}
