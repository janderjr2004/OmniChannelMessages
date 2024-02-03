using OC.Application.Interfaces.Commands;
using OC.Application.Interfaces.Repositories;
using OC.Entities;
using OC.Validations;
using System.Collections.Generic;

namespace OC.Application.UseCases.TypeChannelCases.Commands
{
    public class LinkUserTypeChannelCommand : ILinkUserTypeChannelCommand
    {
        private readonly IUserTypeChannelRepository _userTypeChannelRepository;

        public LinkUserTypeChannelCommand(IUserTypeChannelRepository typeChannelRepository)
        {
            _userTypeChannelRepository = typeChannelRepository;
        }

        public async Task<Validation<List<UserTypeChannel>>> Execute(int userId, int[] typeChannelIds)
        {
            List<UserTypeChannel> list = new List<UserTypeChannel>();

            foreach (var id in typeChannelIds)
            {
                var userTypeChannel = new UserTypeChannel()
                {
                    Id = 0,
                    TypeChannelId = id,
                    UserId = userId
                };

                var result = await _userTypeChannelRepository.Link(userTypeChannel);

                if (result.Fail) return Validation<List<UserTypeChannel>>.Failed(result.Error);
            }

            return Validation<List<UserTypeChannel>>.Succeeded(list);
        }
    }
}
