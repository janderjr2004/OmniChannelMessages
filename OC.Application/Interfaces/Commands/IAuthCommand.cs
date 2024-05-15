using OC.Contracts.Requests;
using OC.Contracts.Responses;
using OC.Validations;

namespace OC.Application.Interfaces.Commands
{
    public interface IAuthCommand
    {
        Task<Validation<AuthResponse>> Execute(AuthRequest request);
    }
}
