using Domain.UserAggregate;

namespace Application.Common.Interfaces.Presistance
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        Task<List<string>> GetUserRoles(string id);
        Task<User?> GetUserByEmail(string email);
    }
}
