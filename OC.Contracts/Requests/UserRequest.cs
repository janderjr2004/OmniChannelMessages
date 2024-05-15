namespace OC.Contracts.Requests
{
    public record UserRequest
    (
        int? Id,
        string Login,
        string Password,
        int[] Channels
    );
}
