using OC.Application.Interfaces.Commands;
using OC.Contracts.Requests;
using OC.Contracts.Responses;
using OC.Validations;

namespace OC.Application.UseCases.MessagesCases.Commands
{
    public class SendMessageCommand : ISendMessageCommand
    {
        public Task<Validation<MessageResponse>> Execute(SendMessageRequest request)
        {
            return null;
        }
    }
}
