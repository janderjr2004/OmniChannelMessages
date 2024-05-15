using OC.Application.UseCases.MessagesCases.Enums;

namespace OC.Contracts.Responses
{
    public record MessageResponse
    (
        string Message,
        ProviderType ProviderType,
        string Recipient
    );
}
