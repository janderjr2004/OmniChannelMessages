using OC.Application.UseCases.MessagesCases.Enums;

namespace OC.Contracts.Requests
{
    public record SendMessageRequest
    (
        MessageObjectRequest MessageObject,
        ProviderType ProviderType,
        string Recipient,
        string Sender,
        SmtpConfigurationRequest SmtpConfiguration
    );
}
