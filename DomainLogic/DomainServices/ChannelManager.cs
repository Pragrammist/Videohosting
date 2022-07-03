using DomainLogic.Aggregates;
using DomainLogic.Interfaces.Repositories;
using System;
using System.Linq;
using DomainLogic.Interfaces;
using DomainLogic.Specifications.Relations;
using DomainLogic.Aggregates.Relations;
using System.Threading.Tasks;

namespace DomainLogic.DomainServices
{
    public class ChannelManager
    {
        IRepository<Channel, Guid> _channelRepository;
        IRepository<File, Guid> _fileRepository;
        IRepository<User, Guid> _userRepository;
        IRepository<UserAndChannelSubscribe, Guid> _userAndChannelSubscribeRepository;
        const string imageMime = "image";
        IGuidGenerator guidGenerator;
        public async Task<Channel> CreateInstance(Channel channel)
        {
            var userIsExist = await _userRepository.GetByID(channel.CreaterId) != null;

            if (!userIsExist)
                throw new Exception();

            var head = await _fileRepository.GetByID(channel.HeadId);
            if (head == null || !head.MimeType.Contains(imageMime))
                throw new Exception();

            var face = await _fileRepository.GetByID(channel.FaceId);
            if(face == null || !face.MimeType.Contains(imageMime))
                throw new Exception();

            

            return channel;
        }
        public async Task<UserAndChannelSubscribe> Subscribe(User user, Channel channel)
        {
            var userIsExist = _userRepository.GetByID(channel.CreaterId) != null;

            if (!userIsExist)
                throw new Exception();
            var channelIsExists = _channelRepository.GetByID(channel.Id) != null;


            if (!channelIsExists)
                throw new Exception();

            var isSubscribe = (await _userAndChannelSubscribeRepository.Get(new UserAndChannelExistSpecification<UserAndChannelSubscribe>(channel.Id, user.Id))).FirstOrDefault() != null;


            if (isSubscribe)
                return null;

            var subscribe = new UserAndChannelSubscribe(guidGenerator.GenerateGuid(), user.Id, channel.Id);
            channel.IncreaseSubscribers();


            return subscribe;
        }
        public async Task<UserAndChannelSubscribe> UnSubscribe(User user, Channel channel)
        {
            var userIsExist = _userRepository.GetByID(channel.CreaterId) != null;

            if (!userIsExist)
                throw new Exception();
            var channelIsExists = _channelRepository.GetByID(channel.Id) != null;


            if (!channelIsExists)
                throw new Exception();

            var isSubscribe = (await _userAndChannelSubscribeRepository.Get(new UserAndChannelExistSpecification<UserAndChannelSubscribe>(channel.Id, user.Id))).FirstOrDefault() != null;


            if (!isSubscribe)
                return null;

            var subscribe = new UserAndChannelSubscribe(guidGenerator.GenerateGuid(), user.Id, channel.Id);


            channel.IncreaseSubscribers();
            subscribe.DeleteRelation();

            return subscribe;
        }
    }
}

