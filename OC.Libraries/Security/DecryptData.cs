using OC.Libraries.Classes;
using OC.Libraries.Enums;
using OC.Libraries.Interfaces;
using OC.Validations;

namespace OC.Libraries.Security
{
    public class DecryptData : IDecryptData
    {

        private static Dictionary<CryptographyTypes, Func<EncryptClass, string>> _decryptTypes = new Dictionary<CryptographyTypes, Func<EncryptClass, string>>()
        {
            { CryptographyTypes.JC, (data) => DecryptJc(data)}
        };

        public string Execute(EncryptClass data)
        {
            return _decryptTypes[data.Type].Invoke(data);
        }

        private static string DecryptJc(EncryptClass data)
        {
            string charValues = "- ;_987654321!)(*&%$#@'´[]?\"/:=YyWwSsAaIiTtOoPpNnCcMmLlVvRrFfDdUuKkBbZzEeHhGgXxJjQqÇç";

            int key = (int)data.Key;

            string valueDecrypted = "";

            int appendKey = (key * 10);
            int valueSubstringKey = appendKey / 2;
            int rangeValue = data.Text.Count() - appendKey;

            string value = data.Text.Substring(valueSubstringKey + 1, rangeValue - 1);

            foreach (var caracter in value.ToCharArray())
            {
                var baseIndex = charValues.IndexOf(caracter);

                var positionChar = baseIndex + key;
                int timesPassed = 0;

                if (positionChar > 83)
                {
                    timesPassed = positionChar / 83;
                    positionChar -= (timesPassed * 83);
                }

                valueDecrypted += charValues.Substring(positionChar, 1);
            }

            return valueDecrypted;
        }
    }
}
