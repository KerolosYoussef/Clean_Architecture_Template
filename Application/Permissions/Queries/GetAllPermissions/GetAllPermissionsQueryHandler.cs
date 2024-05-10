using Application.Common.Interfaces.Presistance;
using Application.Specifications;
using Application.Speicifications;
using Domain.PermissionAggregate;
using ErrorOr;
using MediatR;
using Domain.Common.Helpers;
using Application.Common;

namespace Application.Permissions.Queries.GetAllPermissions
{
    public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, ErrorOr<Pagination<Permission>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPermissionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Pagination<Permission>>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            // get permissions specification
            var permissionSpecification = PermissionSpecifications.GetPermissionsSpecs(request.PermissionParams);

            // get total items of this criteria
            var totalItems = await _unitOfWork.Repository<Permission>().CountAsync(permissionSpecification);

            // apply paging and sorting
            permissionSpecification = ApplyPagingAndSorting(permissionSpecification, totalItems, request);

            // get permissions from database
            var permissions = (await _unitOfWork.Repository<Permission>().ListAsync(permissionSpecification)).AsReadOnly();

            // return paginated permissions
            return new Pagination<Permission>(request.PermissionParams.PageIndex, request.PermissionParams.PageSize, totalItems, permissions);
        }

        private BaseSpecification<Permission> ApplyPagingAndSorting(BaseSpecification<Permission> permissionSpecification, int totalItems, GetAllPermissionsQuery request)
        {
            if (request.PermissionParams.PageIndex != -1)
            {
                var skip = request.PermissionParams.PageSize * (request.PermissionParams.PageIndex);
                var take = request.PermissionParams.PageSize;
                permissionSpecification.ApplyPaging(skip, take);
            }
            else
            {
                permissionSpecification.ApplyPaging(0, totalItems);
            }

            if (request.PermissionParams.OrderBy is not null && request.PermissionParams.OrderByType == "ASC")
            {
                permissionSpecification.ApplyOrderBy(OrderByHelpers.Permissions.GetByOrderType(request.PermissionParams.OrderBy));
            }
            else if(request.PermissionParams.OrderBy is not null && request.PermissionParams.OrderByType == "DSC")
            {
                permissionSpecification.ApplyOrderByDescending(OrderByHelpers.Permissions.GetByOrderType(request.PermissionParams.OrderBy));
            }
            return permissionSpecification;
        }
    }
}
