using Microsoft.AspNetCore.Identity;

namespace Domain.UserAggregate
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; } = null!;
    }
}
