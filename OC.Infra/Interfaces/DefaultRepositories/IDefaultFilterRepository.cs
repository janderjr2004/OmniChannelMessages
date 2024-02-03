using OC.Validations;

namespace OC.Infra.Interfaces.DefaultRepositories
{
    public interface IDefaultFilterRepository<T>
    {
        Task<Validation<List<T>>> Execute(OCContext context, Func<T, bool> condition);
    }
}
