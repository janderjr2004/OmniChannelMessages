using OC.Contracts.Requests;
using OC.Entities;
using OC.Validations;

namespace OC.Application.Interfaces.Commands
{
    public interface ICreateUserCommand
    {
        Task<Validation<User>> Execute(UserRequest request);
    }
}
