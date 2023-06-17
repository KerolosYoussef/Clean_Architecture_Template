using Application.Common.Interfaces.Presistance;
using Domain.UserAggregate;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Presistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public List<User> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<List<string>> GetUserRoles(string id)
        {
            // get user
            var user = await _userManager.FindByIdAsync(id);
            // get user roles
            var roles = await _userManager.GetRolesAsync(user);
            // return roles
            return roles.ToList();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }
    }
}
