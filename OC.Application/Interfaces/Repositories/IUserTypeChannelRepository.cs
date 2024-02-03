using OC.Entities;
using OC.Validations;

namespace OC.Application.Interfaces.Repositories
{
    public interface IUserTypeChannelRepository
    {
        Task<Validation<UserTypeChannel>> Link(UserTypeChannel entity);
    }
}
