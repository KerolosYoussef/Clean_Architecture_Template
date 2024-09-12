using ErrorOr;

namespace Domain.Common.Errors
{
    public partial class Errors
    {
        public static Error PermissionNotFound => Error.NotFound(
            code: "Permissions.NotFound",
            description: "Permission Not Found" 
        );

    }
}
