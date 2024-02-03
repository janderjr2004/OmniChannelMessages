using OC.Libraries.Enums;

namespace OC.Libraries.Classes
{
    public class EncryptClass
    {
        public string Text { get; set; }
        public object? Key { get; set; }
        public CryptographyTypes Type { get; set; }


        public EncryptClass(string text, CryptographyTypes type, object key = null)
        {
            Text = text;
            Key = key;
            Type = type;
        }
    }
}
