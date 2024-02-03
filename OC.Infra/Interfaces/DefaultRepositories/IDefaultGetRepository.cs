using OC.Validations;

namespace OC.Infra.Interfaces.DefaultRepositories
{
    public interface IDefaultGetRepository<T>
    {
        Task<Validation<T>> Execute(OCContext context, int id, bool tracking);
    }
}
