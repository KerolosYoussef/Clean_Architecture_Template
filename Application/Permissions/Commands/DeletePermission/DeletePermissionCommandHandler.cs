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

namespace Application.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, ErrorOr<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<bool>> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            // get permission
            var permissionSpec = PermissionSpecifications.GetPermissionByIdSpec(request.Id);
            var permission = await _unitOfWork.Repository<Permission>().FirstOrDefaultAsync(permissionSpec);

            if (permission is null)
                return Errors.PermissionNotFound;

            _unitOfWork.Repository<Permission>().Delete(permission);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
