using OC.Application.Interfaces.Commands;
using OC.Application.Interfaces.Factories;
using OC.Application.Validations;
using OC.Contracts.Requests;
using OC.Contracts.Responses;
using OC.Libraries.Classes;
using OC.Libraries.Classes.AuxiliaryClasses;
using OC.Validations;

namespace OC.Application.UseCases.MessagesCases.Commands
{
    public class SendMessageCommand : ISendMessageCommand
    {
        private readonly IProviderFactory _providerFactory;

        public SendMessageCommand(IProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;
        }

        public async Task<Validation<MessageResponse>> Execute(SendMessageRequest request)
        {
            var resultValidation = await ValidateMessageRequest.Execute(request);

            if (resultValidation.Fail)
                return Validation<MessageResponse>.Failed(resultValidation.Error);

            SendMessageClass sendMessageClass = new SendMessageClass()
            {
                MessageObject = new MessageObject()
                {
                    Message = request.MessageObject.Message,
                    Subject = request.MessageObject.Subject
                },
                SmtpConfiguration = new SmtpConfiguration()
                {
                     Server = request.SmtpConfiguration.Server,
                     Port = request.SmtpConfiguration.Port,
                     Password = request.SmtpConfiguration.Password,
                     EnableSSL = request.SmtpConfiguration.EnableSSL,
                     IsHtml = request.SmtpConfiguration.IsHtml
                },
                ProviderType = request.ProviderType,
                Recipient = request.Recipient,
                Sender = request.Sender
            };

            var result = await _providerFactory.SendMessage(sendMessageClass);

            if (result.Fail)
                return Validation<MessageResponse>.Failed(result.Error);

            return Validation<MessageResponse>.Succeeded(new MessageResponse("Mensagem enviada com sucesso!"));
        }
    }
}
