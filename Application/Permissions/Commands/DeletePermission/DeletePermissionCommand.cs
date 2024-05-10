using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands.DeletePermission
{
    public record DeletePermissionCommand(Guid Id) : IRequest<ErrorOr<bool>>
    {
    }
}
