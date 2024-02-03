using OC.Libraries.Classes;

namespace OC.Libraries.Interfaces
{
    public interface IFileOC
    {
        void ExecuteWrite(FileClass fileClass);
        string ExecuteGet(FileClass fileClass);
    }
}
