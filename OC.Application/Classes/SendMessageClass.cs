using OC.Application.UseCases.MessagesCases.Enums;
using OC.Libraries.Classes.AuxiliaryClasses;

namespace OC.Libraries.Classes
{
    public class SendMessageClass
    {
        public MessageObject MessageObject { get; set; }
        public ProviderType ProviderType { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; }
        public SmtpConfiguration SmtpConfiguration { get; set; }
    }
}
