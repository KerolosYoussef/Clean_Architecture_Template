using Application.Common.Interfaces.Presistance;
using Application.Specifications;
using Application.Speicifications;
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
    public class GetModulePermissionsQueryHandler : IRequestHandler<GetModulePermissionsQuery, ErrorOr<List<string>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetModulePermissionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<List<string>>> Handle(GetModulePermissionsQuery request, CancellationToken cancellationToken)
        {
            // Create permissions specs
            BaseSpecification<Permission> getPermissionsByModuleSpecs = PermissionSpecifications.GetModulePermissionSpec(request.Module);

            // Get permissions of this module from database
            var permissions = await _unitOfWork.Repository<Permission>().ListAsync(getPermissionsByModuleSpecs);

            // return response
            return permissions.Select(permission => $"Permissions.{permission.Module}.{permission.Name}").ToList();
        }
    }
}
