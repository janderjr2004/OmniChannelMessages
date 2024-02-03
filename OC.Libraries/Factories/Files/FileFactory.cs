using OC.Libraries.Classes;
using OC.Libraries.Enums;
using OC.Libraries.Interfaces;
using OC.Validations;
using OC.Validations.Errors;

namespace OC.Libraries.Factories.Files
{
    public static class FileFactory
    {
        private static Dictionary<FileTypes, Func<IFileOC>> _files =
            new Dictionary<FileTypes, Func<IFileOC>>()
            {
                { FileTypes.Ini, () => new IniFile() },
                { FileTypes.Text, () => new TextFile() }
            };


        public static Validation<bool> Write(FileClass fileClass)
        {
            try
            {
                _files[fileClass.FileType].Invoke().ExecuteWrite(fileClass);

                return Validation<bool>.Succeeded(true);
            }
            catch (Exception ex)
            {
                return Validation<bool>.Failed(Error.Validation());
            }
        }

        public static Validation<string> Get(FileClass fileClass)
        {
            try
            {
                var value = _files[fileClass.FileType].Invoke().ExecuteGet(fileClass);

                return Validation<string>.Succeeded(value);
            }
            catch (Exception ex)
            {
                return Validation<string>.Failed(Error.Validation());
            }
        }
    }
}
