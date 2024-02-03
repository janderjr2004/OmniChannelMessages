using Microsoft.EntityFrameworkCore;
using OC.Entities;
using OC.Infra.Interfaces.DefaultRepositories;
using OC.Validations;
using OC.Validations.Errors;

namespace OC.Infra.Repositories.DefaultRepositores
{
    public class DefaultGetRepository<T> : IDefaultGetRepository<T> where T : BaseEntity
    {
        public async Task<Validation<T>> Execute(OCContext context, int id, bool tracking)
        {
            try
            {
                var query = context.Set<T>();

                T entity = tracking ? 
                    query.Where(c => c.Id == id).FirstOrDefault() :
                    query.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

                if (entity is null)
                    return Validation<T>.Failed(Error.Failure("EntityFramework.Default", $"{nameof(T)} cannot be found!"));

                return Validation<T>.Succeeded(entity);
            }
            catch (Exception ex)
            {
                return Validation<T>.Failed(Error.Failure(ex.Source, ex.InnerException.Message));
            }
        }
    }
}
