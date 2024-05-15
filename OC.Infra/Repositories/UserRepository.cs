using OC.Application.Interfaces.Repositories;
using OC.Entities;
using OC.Infra.Interfaces.DefaultRepositories;
using OC.Validations;
using OC.Validations.Errors;

namespace OC.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDefaultCreateRepository<User> _createRepository;
        private readonly IDefaultUpdateRepository<User> _updateRepository;
        private readonly IDefaultGetRepository<User> _getRepository;
        private readonly IDefaultFilterRepository<User> _filterRepository;
        private readonly OCContext _context;

        public UserRepository(
            IDefaultCreateRepository<User> createRepository,
            IDefaultUpdateRepository<User> updateRepository,
            IDefaultGetRepository<User> getRepository,
            IDefaultFilterRepository<User> filterRepository,
            OCContext context)
        {
            _createRepository = createRepository;
            _updateRepository = updateRepository;
            _getRepository = getRepository;
            _filterRepository = filterRepository;
            _context = context;
        }

        public async Task<Validation<User>> Create(User entity)
        {
            return await _createRepository.Execute(_context, entity);
        }

        public async Task<Validation<List<User>>> Filter(Func<User, bool> func)
        {
            return await _filterRepository.Execute(_context, func);
        }

        public async Task<Validation<User>> Get(int id, bool tracking = false)
        {
            return await _getRepository.Execute(_context, id, tracking);
        }

        public async Task<Validation<User>> GetLoginCredentials(string login, string password)
        {
            var queryUser = (from u in _context.Users
                         where u.Login == login && u.Password == password
                         select u).FirstOrDefault();

            if (queryUser is null) return Validation<User>.Failed(Error.NotFound<User>());

            return Validation<User>.Succeeded(queryUser);
        }

        public async Task<Validation<User>> Update(User entity)
        {
            return await _updateRepository.Execute(_context, entity);
        }
    }
}
