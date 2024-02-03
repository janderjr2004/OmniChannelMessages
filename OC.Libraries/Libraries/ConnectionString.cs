using OC.Libraries.Classes;
using OC.Libraries.Enums;
using OC.Libraries.Factories.Files;
using OC.Libraries.Interfaces;
using OC.Validations;
using OC.Validations.Errors;

namespace OC.Libraries.Libraries
{
    public class ConnectionString : IConnectionString
    {
        private readonly IDecryptData _decryptData;

        public ConnectionString(IDecryptData decryptData)
        {
            _decryptData = decryptData;
        }

        public Validation<string> Get()
        {
            var iniData = new Dictionary<string, Dictionary<string, string>>()
            {
                { "ExtraDatas", new Dictionary<string, string>()
                {
                        { "ConnectionString", "" }
                    }
                }
            };

            var value = FileFactory.Get(new FileClass(FileTypes.Ini, null, iniData, "OC.Config.ini"));

            if (value.Fail) return Validation<string>.Failed(ErrorConnectionString.ConnectionStringUnableToRetrieve);

            var encryptData = new EncryptClass(value.GetValue(), CryptographyTypes.JC, 9);

            return Validation<string>.Succeeded(_decryptData.Execute(encryptData));
        }
    }
}
