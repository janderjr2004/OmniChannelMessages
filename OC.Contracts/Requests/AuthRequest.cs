namespace OC.Contracts.Requests
{
    public record AuthRequest
    (
        string Login,
        string Password
    );
}
