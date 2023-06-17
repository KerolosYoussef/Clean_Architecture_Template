using Application.Common.Interfaces.Presistance;
using Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Application.Users.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ErrorOr<List<User>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // get users
            var users = _userRepository.GetAllUsers();
            return users;
        }
    }
}
