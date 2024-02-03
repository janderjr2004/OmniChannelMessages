using OC.Libraries.Enums;

namespace OC.Libraries.Classes
{
    public class FileClass
    {
        public FileTypes FileType { get; set; }
        public Dictionary<string, Dictionary<string, string>> IniValue { get; set; }
        public string Value { get; set; }
        public string File { get; set; }

        public FileClass(
            FileTypes fileType, 
            string value, 
            Dictionary<string, Dictionary<string, string>> iniValue, 
            string file
        )
        {
            FileType = fileType;
            Value = value;
            IniValue = iniValue;
            File = file;
        }
    }
}
