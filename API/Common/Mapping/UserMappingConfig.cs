using Application.Common.Interfaces.Presistance;
using Contracts.User;
using Domain.UserAggregate;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace API.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        private IUserRepository _userRepository;

#pragma warning disable CS8618
        public UserMappingConfig() {}
#pragma warning restore CS8618

        public UserMappingConfig(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserResponse>()
                .Map(dest => dest.Roles, src => _userRepository.GetUserRoles(src.Id).GetAwaiter().GetResult());
        }
    }
}
