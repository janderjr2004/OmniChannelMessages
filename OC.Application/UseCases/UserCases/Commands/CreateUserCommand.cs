using OC.Application.Interfaces.Commands;
using OC.Application.Interfaces.Repositories;
using OC.Contracts.Requests;
using OC.Entities;
using OC.Libraries.Classes;
using OC.Libraries.Enums;
using OC.Libraries.Interfaces;
using OC.Validations;

namespace OC.Application.UseCases.UserCases.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly ILinkUserTypeChannelCommand _linkUserTypeChannelCommand;
        private readonly IEncryptData _encryptData;

        public CreateUserCommand(IUserRepository userRepository, IEncryptData encryptData, 
            ILinkUserTypeChannelCommand linkUserTypeChannelCommand)
        {
            _userRepository = userRepository;
            _encryptData = encryptData;
            _linkUserTypeChannelCommand = linkUserTypeChannelCommand;
        }

        public async Task<Validation<User>> Execute(UserRequest request)
        {
            var encryptDataClass = new EncryptClass(request.Password, CryptographyTypes.MD5);

            var passwordEncrypted = _encryptData.Execute(encryptDataClass);

            User user = new User() 
            { 
                Id = 0, 
                Login = request.Login, 
                Password = passwordEncrypted
            };

            var result = await _userRepository.Create(user);

            if (result.Fail) 
                return Validation<User>.Failed(result.Error);

            var resultLinkUserTypeChannel = await _linkUserTypeChannelCommand.Execute(user.Id, request.Channels);

            if (resultLinkUserTypeChannel.Fail)
                return Validation<User>.Failed(resultLinkUserTypeChannel.Error);
            
            return Validation<User>.Succeeded(result.GetValue());
        }
    }
}
