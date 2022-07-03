using DomainLogic.Aggregates;
using DomainLogic.Interfaces.Repositories;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Specifications;

namespace DomainLogic.DomainServices
{

    //Method contains follow logic is if to keep class simple as it can be.For example, Channel dont have method to load video cause it always had in VideoManager Method CreateInstance

    public class UserMannager
    {
        public const string imageMime = "image";
        protected IRepository<User, Guid> _userRepository;
        protected IRepository<Channel, Guid> _channelRepository;
        protected IRepository<File, Guid> _fileRepository;

        public UserMannager(IRepository<User, Guid> userRepository, IRepository<Channel, Guid> channelRepository, IRepository<File, Guid> fileRepository)
        {
            _userRepository = userRepository;
            _channelRepository = channelRepository;
            _fileRepository = fileRepository;
        }
        public virtual User CreateInstance(User user)
        {
            var fUser = _userRepository.Get(new UserExistsSpecification(user.Id, user.UserName, user.Email, user.Phone)).FirstOrDefault();

            if (fUser != null)
                throw new Exception();

            return user;
        }
        public virtual void AttachOwnChannel(User user, Channel channel)
        {
            var channelExts = _channelRepository.GetByID(channel.Id) != null;
            if (!channelExts)
                throw new Exception();
            var userExts = _userRepository.GetByID(user.Id) != null;
            if (!userExts)
                throw new Exception();
            user.SetChannel(channel.Id);

        }
        public virtual void AttachAvatar(User user, File avatar)
        {

            var userExsts = _userRepository.GetByID(user.Id);
            if (userExsts == null)
                throw new Exception();

            var avatarExts = _fileRepository.GetByID(avatar.Id);
            if (avatarExts == null || !avatar.MimeType.Contains(imageMime))
                throw new Exception();

            userExsts.SetAvatar(avatarExts.Id);
            
        }
        
    }
}

