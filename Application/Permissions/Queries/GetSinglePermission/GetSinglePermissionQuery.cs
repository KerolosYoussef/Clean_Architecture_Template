using Application.Common.Interfaces.Sepcification;
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
    public record GetSinglePermissionQuery(ISpecification<Permission> PermissionSpecification) : IRequest<ErrorOr<Permission>> { }
}
