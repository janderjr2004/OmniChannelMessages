using Microsoft.EntityFrameworkCore;
using OC.Entities;
using OC.Infra.Interfaces.DefaultRepositories;
using OC.Validations;
using OC.Validations.Errors;

namespace OC.Infra.Repositories.DefaultRepositores
{
    public class DefaultCreateRepository<T> : IDefaultCreateRepository<T> where T : BaseEntity
    {
        public async Task<Validation<T>> Execute(OCContext context, T entity)
        {
            try
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                T localEntity = ((OCContext)context).Set<T>().Local.FirstOrDefault(entity);

                if (localEntity != null)
                    ((OCContext)context).Entry(entity).State = EntityState.Detached;
                

                return Validation<T>.Succeeded(localEntity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    return Validation<T>.Failed(Error.Failure(ex.InnerException.Source, ex.InnerException.Message));
                else
                    return Validation<T>.Failed(Error.Failure(ex.Source, ex.InnerException.Message));
            }
        }
    }
}
