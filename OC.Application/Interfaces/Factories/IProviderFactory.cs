using OC.Libraries.Classes;
using OC.Validations;

namespace OC.Application.Interfaces.Factories
{
    public interface IProviderFactory
    {
        Task<Validation<string>> SendMessage(SendMessageClass sendMessageClass);
    }
}
