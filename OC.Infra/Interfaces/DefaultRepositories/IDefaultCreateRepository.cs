using OC.Validations;

namespace OC.Infra.Interfaces.DefaultRepositories
{
    public interface IDefaultCreateRepository<T>
    {
        Task<Validation<T>> Execute(OCContext context, T entity);
    }
}
