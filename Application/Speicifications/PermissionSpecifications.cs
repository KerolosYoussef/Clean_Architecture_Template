using Application.Permissions.Common;
using Application.Specifications;
using Domain.PermissionAggregate;
using Domain.PermissionAggregate.ValueObjects;
using Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Speicifications
{
    public class PermissionSpecifications
    {
        public static BaseSpecification<Permission> GetPermissionsSpecs(PermissionParams permissionParams)
        {
            return new BaseSpecification<Permission>(x
                => (string.IsNullOrEmpty(permissionParams.PermissionName)
                    || x.Name.Contains(permissionParams.PermissionName))
                    && (string.IsNullOrEmpty(permissionParams.ModuleName) || x.Module.Contains(permissionParams.ModuleName)));
        }

        public static BaseSpecification<Permission> GetPermissionByIdSpec(Guid id)
        {
            return new BaseSpecification<Permission>(x => x.Id == PermissionId.Create(id));
        }
    }
}
