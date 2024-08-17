namespace OC.Contracts.Requests
{
    public record LinkUserRequest
    (
        int UserId,
        int[] TypeChannelIds
    );
}
