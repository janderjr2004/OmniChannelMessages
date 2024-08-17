using OC.Application.UseCases.MessagesCases.Enums;
using OC.Contracts.Requests;
using OC.Contracts.Responses;
using OC.Validations;
using OC.Validations.Errors;

namespace OC.Application.Validations
{
    public static class ValidateMessageRequest
    {
        public static async Task<Validation<SendMessageRequest>> Execute(SendMessageRequest request)
        {
            if (string.IsNullOrEmpty(request.Sender))
                return Validation<SendMessageRequest>.Failed(ErrorSendMessage.EmptySender);

            if (string.IsNullOrEmpty(request.Recipient))
                return Validation<SendMessageRequest>.Failed(ErrorSendMessage.EmptyRecipient);            
            
            //if (request.ProviderType is null)
            //    return Validation<SendMessageRequest>.Failed(ErrorSendMessage.EmptyProviderType);
                        
            if (request.MessageObject is null || string.IsNullOrEmpty(request.MessageObject.Message))
                return Validation<SendMessageRequest>.Failed(ErrorSendMessage.EmptyMessage);

            
            if (request.ProviderType is ProviderType.Email) {
                if (string.IsNullOrEmpty(request.MessageObject.Subject))
                    return Validation<SendMessageRequest>.Failed(ErrorSendMessage.EmptySubject);

                if (request.SmtpConfiguration is null)
                    return Validation<SendMessageRequest>.Failed(ErrorSendMessage.EmptySmtpConfiguration);
            }

            return Validation<SendMessageRequest>.Succeeded(request);
        }
    }
}
