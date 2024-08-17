using OC.Application.Interfaces.Factories;
using OC.Application.Interfaces.Services;
using OC.Application.UseCases.MessagesCases.Enums;
using OC.Infra.Services;
using OC.Libraries.Classes;
using OC.Validations;

namespace OC.Libraries.Factories.MessagesFactory
{
    public class ProviderFactory : IProviderFactory
    {
        private Dictionary<ProviderType, Func<ISendMessage>> _dicProviders =
            new Dictionary<ProviderType, Func<ISendMessage>>()
            {
                { ProviderType.Email, () => new Email() }/*,*/
                //{ ProviderType.Whatsapp, () => () },
                //{ ProviderType.SMS, () => ()}
            };

        public async Task<Validation<string>> SendMessage(SendMessageClass sendMessageClass)
        {
            var providerFactory = _dicProviders[sendMessageClass.ProviderType].Invoke();

            var result = await providerFactory.Execute(sendMessageClass);

            if (result.Fail)
                return Validation<string>.Failed(result.Error);

            return Validation<string>.Succeeded();
        }
    }
}
