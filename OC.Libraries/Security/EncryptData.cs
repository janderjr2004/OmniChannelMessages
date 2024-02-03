using OC.Libraries.Classes;
using OC.Libraries.Enums;
using OC.Libraries.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace OC.Libraries.Security
{
    public class EncryptData : IEncryptData
    {
        private static Dictionary<CryptographyTypes, Func<EncryptClass, string>> _encryptTypes = 
            new Dictionary<CryptographyTypes, Func<EncryptClass, string>>()
        {
            { CryptographyTypes.JC, (data) => EncryptJC(data)},
            { CryptographyTypes.MD5, (data) => EncryptMD5(data)},
            { CryptographyTypes.Base64, (data) => EncryptBase64(data)}
        };

        public string Execute(EncryptClass data)
        {
            return _encryptTypes[data.Type].Invoke(data);
        }

        private static string EncryptJC(EncryptClass data)
        {
            string charValues = "-çÇqQjJxXgGhHeEzZbBkKuUdDfFrRvVlLmMcCnNpPoOtTiIaAsSwWyY=:/\"?][´'@#$%&*()!123456789_; ";
            int key = (int)data.Key;

            string valueEncrypted = "";
            string randomValue = "";

            var appendKey = (key * 10);

            for(int i = 0; i <= appendKey; i++)
            {
                Random random = new Random();

                int indexChar = random.Next(1, 83);

                randomValue += charValues[indexChar];

                if (i == (appendKey / 2))
                    randomValue += "|";
            }

            var splitRandomValue = randomValue.Split("|");

            valueEncrypted = splitRandomValue[0];

            foreach (var caracter in data.Text.ToCharArray())
            {
                var baseIndex = charValues.IndexOf(caracter);

                var positionChar = baseIndex + key;
                int timesPassed = 0;

                if (positionChar > 83)
                {
                    timesPassed = positionChar / 83;
                    positionChar -= (timesPassed * 83);
                }

                valueEncrypted += charValues.Substring(positionChar, 1);
            }

            valueEncrypted += splitRandomValue[1];

            return valueEncrypted;
        }

        private static string EncryptMD5(EncryptClass data)
        {
            MD5 md5Hash = MD5.Create();

            byte[] md5Data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(data.Text));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < md5Data.Length; i++)
            {
                sBuilder.Append(md5Data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private static string EncryptBase64(EncryptClass data)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(data.Text);

            return Convert.ToBase64String(plainTextBytes);
        }
    }
}