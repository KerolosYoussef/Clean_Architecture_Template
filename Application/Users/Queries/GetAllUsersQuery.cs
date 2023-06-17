using Domain.UserAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public record GetAllUsersQuery() : IRequest<ErrorOr<List<User>>> { }
    
}
