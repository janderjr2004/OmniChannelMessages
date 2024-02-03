using Microsoft.EntityFrameworkCore;
using OC.Entities;
using OC.Infra.Interfaces.DefaultRepositories;
using OC.Validations;
using OC.Validations.Errors;

namespace OC.Infra.Repositories.DefaultRepositores
{
    public class DefaultUpdateRepository<T> : IDefaultUpdateRepository<T> where T : BaseEntity
    {
        public async Task<Validation<T>> Execute(OCContext context, T entity)
        {
            try
            {
                T oldEntity = ((OCContext)context).Set<T>().Find(entity.Id);
                if (oldEntity != null)
                {
                    ((OCContext)context).Entry(oldEntity).State = EntityState.Detached;
                }

                DbSet<T> entitySet = ((OCContext)context).Set<T>();

                ((OCContext)context).Entry(entity).State = EntityState.Modified;

                entitySet.Update(entity);

                await ((OCContext)context).SaveChangesAsync();

                return Validation<T>.Succeeded(entity);
            }
            catch (Exception ex)
            {
                return Validation<T>.Failed(Error.Failure(ex.Source, ex.InnerException.Message));
            }
        }
    }
}