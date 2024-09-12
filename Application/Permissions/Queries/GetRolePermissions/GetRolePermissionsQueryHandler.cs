using Application.Common.DTOs;
using Application.Common.Interfaces.Presistance;
using Application.Modules.GetAllModules;
using Application.Permissions.Queries.GetModulePermissions;
using Domain.Common.Errors;
using Domain.PermissionAggregate;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Queries.GetRolePermissions
{
    public class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, ErrorOr<PermissionsDto>>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetRolePermissionsQueryHandler(IMediator mediator, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
        }

        public async Task<ErrorOr<PermissionsDto>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            // Get role from database
            var role = await _roleManager.FindByIdAsync(request.RoleId);

            if (role is null)
                return Errors.RoleNotFound;

            // Get role claims
            var roleClaims = await _roleManager.GetClaimsAsync(role);

            // Get All claims
            List<string> allClaims = await GeneratePermissionsClaims();

            // Get Al Permissions
            var allPermissions = allClaims.Select(p => new CheckboxDto(p)).ToList();

            // Iterate on all permissions and set role permissions to true
            foreach (var permission in allPermissions.Where(permission => roleClaims.Any(c => c.Value == permission.Name)))
            {
                permission.IsSelected = true;
            }

            // Create Permissions Dto
            var permissionDto = new PermissionsDto(role.Id, role.Name, allPermissions);

            // return result
            return permissionDto;
        }

        private async Task<List<string>> GeneratePermissionsClaims()
        {
            var allClaims = new List<string>();

            // Create get all modules query
            var getAllModulesQuery = new GetAllModulesQuery();
            var modules = (await _mediator.Send(getAllModulesQuery)).Value;

            // Iterate on modules to get each module permissions
            foreach (var module in modules)
            {
                // Create get module permissions query
                var getModulePermissionsQuery = new GetModulePermissionsQuery(module.Name);
                var permissionList = (await _mediator.Send(getModulePermissionsQuery)).Value;

                if (permissionList is not null && permissionList.Any())
                {
                    allClaims.AddRange(permissionList);
                }
            }

            // return result
            return allClaims;
        }
    }
}
