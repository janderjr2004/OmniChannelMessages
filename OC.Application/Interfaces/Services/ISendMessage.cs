using OC.Libraries.Classes;
using OC.Validations;

namespace OC.Application.Interfaces.Services
{
    public interface ISendMessage
    {
        Task<Validation<string>> Execute(SendMessageClass sendMessageClass);
    }
}
