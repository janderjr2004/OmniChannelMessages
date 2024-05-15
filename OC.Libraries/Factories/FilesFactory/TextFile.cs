using OC.Libraries.Classes;
using OC.Libraries.Interfaces;

namespace OC.Libraries.Factories.Files
{
    public class TextFile : IFileOC
    {
        public void ExecuteWrite(FileClass fileClass)
        {
            using (StreamWriter sw = new StreamWriter(FileDirectory.Path + fileClass.File, true))
            {
                sw.WriteLine(fileClass.Value);
            };
        }

        public string ExecuteGet(FileClass fileClass)
        {
            string[] lines = File.ReadAllLines(FileDirectory.Path + fileClass.File);

            return "";
        }
    }
}
