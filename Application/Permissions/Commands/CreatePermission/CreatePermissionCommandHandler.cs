using Application.Common.Interfaces.Presistance;
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
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, ErrorOr<Permission>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Permission>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            // create new permission
            var permission = Permission.Create(request.Module, request.Name);

            // check if this module is not exists
            // TODO

            // presist permission
            var result = await _unitOfWork.Repository<Permission>().AddAsync(permission);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
