using OC.Validations;

namespace OC.Infra.Interfaces.DefaultRepositories
{
    public interface IDefaultUpdateRepository<T>
    {
        Task<Validation<T>> Execute(OCContext context, T entity);
    }
}
