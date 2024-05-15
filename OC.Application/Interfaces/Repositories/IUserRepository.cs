using OC.Entities;
using OC.Validations;

namespace OC.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Validation<User>> Create(User entity);
        Task<Validation<User>> Update(User entity);
        Task<Validation<User>> Get(int id, bool tracking = false);
        Task<Validation<List<User>>> Filter(Func<User, bool> func);
        Task<Validation<User>> GetLoginCredentials(string login, string password);
    }
}
