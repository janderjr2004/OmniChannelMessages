using OC.Validations;

namespace OC.Libraries.Interfaces
{
    public interface IConnectionString
    {
        Validation<string> Get();
    }
}
