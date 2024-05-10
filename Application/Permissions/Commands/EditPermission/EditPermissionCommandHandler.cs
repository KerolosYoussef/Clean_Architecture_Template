using Application.Common.Interfaces.Presistance;
using Application.Speicifications;
using Domain.Common.Errors;
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
    public class EditPermissionCommandHandler : IRequestHandler<EditPermissionCommand, ErrorOr<Permission>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditPermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Permission>> Handle(EditPermissionCommand request, CancellationToken cancellationToken)
        {
            // get permission
            var permissionSpec = PermissionSpecifications.GetPermissionByIdSpec(request.Id);
            var permission = await _unitOfWork.Repository<Permission>().FirstOrDefaultAsync(permissionSpec);

            // check if permission not exists
            if (permission is null)
                return Errors.PermissionNotFound;

            // update permissions
            permission.Name = request.Name;
            permission.Module = request.Module;

            // presist permission to database
            _unitOfWork.Repository<Permission>().Update(permission);
            await _unitOfWork.SaveChangesAsync();

            return permission;
        }
    }
}
