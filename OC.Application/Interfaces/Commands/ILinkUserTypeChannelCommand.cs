using OC.Entities;
using OC.Validations;

namespace OC.Application.Interfaces.Commands
{
    public interface ILinkUserTypeChannelCommand
    {
        Task<Validation<List<UserTypeChannel>>> Execute(int userId, int[] typeChannelId);
    }
}
