using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Presistance;
using Domain.Common.Errors;
using Domain.UserAggregate;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;

        public LoginQueryHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository, SignInManager<User> signInManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _signInManager = signInManager;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            // Check if user doesn't exists or wrong password
            var user = await _userRepository.GetUserByEmail(query.Email);
            var isPasswordValid = user is not null
                ? (await _signInManager.CheckPasswordSignInAsync(user, query.Password, false)).Succeeded
                : false;
            if (user is null || !isPasswordValid)
                return Errors.Authentication.InvalidCredentials;

            // Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
