namespace OC.Contracts.Requests
{
    public record SmtpConfigurationRequest
    (
        string Server,
        int Port,
        string Password,
        bool EnableSSL,
        bool IsHtml
    );
}
