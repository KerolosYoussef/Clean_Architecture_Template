namespace Contracts.Authentication
{
    public record RegisterRequest(
        string DisplayName,
        string Email,
        string Password,
        string ConfirmPassword
    );
}
