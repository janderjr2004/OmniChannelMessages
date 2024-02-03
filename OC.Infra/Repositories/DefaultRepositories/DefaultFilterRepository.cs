using Microsoft.EntityFrameworkCore;
using OC.Entities;
using OC.Infra.Interfaces.DefaultRepositories;
using OC.Validations;
using OC.Validations.Errors;

namespace OC.Infra.Repositories.DefaultRepositores
{
    public class DefaultFilterRepository<T> : IDefaultFilterRepository<T> where T : BaseEntity
    {
        public async Task<Validation<List<T>>> Execute(OCContext context, Func<T, bool> condition)
        {
            try
            {
                DbSet<T> entitySet = ((OCContext)context).Set<T>();
                List<T> entities = await entitySet.ToListAsync();

                if (entities != null || entities.Count != 0)
                    return Validation<List<T>>.Succeeded(entities.Where(condition).ToList());

                else
                    return Validation<List<T>>.Failed(Error.Failure("", $"{nameof(T)} não encontrado."));
            }
            catch (Exception ex)
            {
                return Validation<List<T>>.Failed(Error.Failure(ex.Source, ex.InnerException.Message));
            }
        }
    }
}
