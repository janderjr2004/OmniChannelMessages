using OC.Application.Interfaces.Repositories;
using OC.Entities;
using OC.Infra.Interfaces.DefaultRepositories;
using OC.Validations;

namespace OC.Infra.Repositories
{
    public class UserTypeChannelRepository : IUserTypeChannelRepository
    {
        private readonly IDefaultCreateRepository<UserTypeChannel> _createRepository;
        private readonly OCContext _context;

        public UserTypeChannelRepository(IDefaultCreateRepository<UserTypeChannel> createRepository, OCContext context)
        {
            _context = context;
            _createRepository = createRepository;
        }

        public async Task<Validation<UserTypeChannel>> Link(UserTypeChannel entity)
        {
            return await _createRepository.Execute(_context, entity);
        }
    }
}
