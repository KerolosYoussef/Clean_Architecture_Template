using Application.Common.Interfaces.Presistance;
using Domain.Common.Errors;
using Domain.PermissionAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Queries.GetSinglePermission
{
    public class GetSinglePermissionQueryHandler : IRequestHandler<GetSinglePermissionQuery, ErrorOr<Permission>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSinglePermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Permission>> Handle(GetSinglePermissionQuery request, CancellationToken cancellationToken)
        {
            // get single permission from database.
            var permission = await _unitOfWork.Repository<Permission>().FirstOrDefaultAsync(request.PermissionSpecification);

            // return the permission if found, if not return not found error.
            return permission is null
                ? Errors.PermissionNotFound
                : permission;
        }
    }
}
