using OC.Libraries.Classes;
using OC.Libraries.Interfaces;

namespace OC.Libraries.Factories.Files
{
    public class IniFile : IFileOC
    {
        private Dictionary<string, Dictionary<string, string>> _iniData;

        private void IniFileDatas(string filePath)
        {
            _iniData = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                string currentSection = null;
                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();

                    if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                    {
                        currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                        _iniData[currentSection] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    }
                    else if (!string.IsNullOrWhiteSpace(trimmedLine) && currentSection != null)
                    {
                        int equalIndex = trimmedLine.IndexOf('=');
                        if (equalIndex > 0)
                        {
                            string key = trimmedLine.Substring(0, equalIndex).Trim();
                            string value = trimmedLine.Substring(equalIndex + 1).Trim();
                            _iniData[currentSection][key] = value;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine($"Erro ao ler o arquivo INI: {ex.Message}");
            }
        }

        public void ExecuteWrite(FileClass fileClass)
        {
            using (StreamWriter sw = new StreamWriter(FileDirectory.Path + fileClass.File, true))
            {
                foreach (var iniSection in fileClass.IniValue)
                {
                    foreach (var iniKeyValue in iniSection.Value)
                    {
                        sw.WriteLine($"[{iniSection.Key}]");
                        sw.WriteLine($"{iniKeyValue.Key}={iniKeyValue.Value}");
                        sw.WriteLine();
                    }
                }
            };
        }

        public string ExecuteGet(FileClass fileClass)
        {
            IniFileDatas(FileDirectory.Path + fileClass.File);

            foreach (var iniSection in fileClass.IniValue)
            {
                foreach (var iniKeyValue in iniSection.Value)
                {
                    if (_iniData.TryGetValue(iniSection.Key, out var sectionData) &&
                            sectionData.TryGetValue(iniKeyValue.Key, out var value))
                    {
                        return value;
                    }
                }
            }

            return null;
        }
    }
}
