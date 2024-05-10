using Domain.PermissionAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands.EditPermission
{
    public class EditPermissionCommand : IRequest<ErrorOr<Permission>> 
    {
        public Guid Id;
        public readonly string Name;
        public readonly string Module;

        public EditPermissionCommand(Guid id, string name, string module)
        {
            Id = id;
            Name = name;
            Module = module;
        }

        public void AssignId(Guid id) => Id = id;
    }
}
