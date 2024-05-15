using OC.Contracts.Requests;
using OC.Contracts.Responses;
using OC.Validations;

namespace OC.Application.Interfaces.Commands
{
    public interface ISendMessageCommand
    {
        Task<Validation<MessageResponse>> Execute(SendMessageRequest request);
    }
}
