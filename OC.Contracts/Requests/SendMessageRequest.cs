using OC.Application.UseCases.MessagesCases.Enums;

namespace OC.Contracts.Requests
{
    public record SendMessageRequest
    (
        string Message,
        ProviderType ProviderType,
        string Recipient
    );
}
