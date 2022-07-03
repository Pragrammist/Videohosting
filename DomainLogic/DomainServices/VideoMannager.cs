using DomainLogic.Aggregates;
using DomainLogic.Interfaces.Repositories;
using System;
using System.Linq;
using DomainLogic.Interfaces;
using DomainLogic.Specifications.Relations;
using DomainLogic.Aggregates.Relations;

namespace DomainLogic.DomainServices
{
    public class VideoMannager
    {
        const string videoMime = "video";
        const string imgMime = "image";
        protected IRepository<User, Guid> _userRepository;
        protected IRepository<Channel, Guid> _channelRepository;
        protected IRepository<File, Guid> _fileRepository;
        protected IRepository<Video, Guid> _videoRepository;
        protected IGuidGenerator _guidGenerator;
        protected IRepository<UserAndVideoLike, Guid> _userLikesReporsitory;
        protected IRepository<UserAndVideoDislike, Guid> _userDislikesReporsitory;
        protected IRepository<UserAndVideoShared, Guid> _userSharedRepository;

        public VideoMannager(IRepository<User, Guid> userRepository, IRepository<Channel, Guid> channelRepository, 
            IRepository<File, Guid> fileRepository, IRepository<Video, Guid> videoRepository, 
            IGuidGenerator guidGenerator, IRepository<UserAndVideoLike, Guid> userLikesReporsitory, 
            IRepository<UserAndVideoDislike, Guid> userDislikesReporsitory, IRepository<UserAndVideoShared, Guid> userSharedRepository)
        {
            _userRepository = userRepository;
            _channelRepository = channelRepository;
            _fileRepository = fileRepository;
            _videoRepository = videoRepository;
            _guidGenerator = guidGenerator;
            _userLikesReporsitory = userLikesReporsitory;
            _userDislikesReporsitory = userDislikesReporsitory;
            _userSharedRepository = userSharedRepository;
        }

        public virtual Video CreateInstance(Video video)
        {
            var channel = _channelRepository.GetByID(video.ChannelId);
            if (channel == null)
                throw new Exception();

            var preview = _fileRepository.GetByID(video.PreviewId);
            if (preview == null || !preview.MimeType.Contains(imgMime))
                throw new Exception();

            var videofile = _fileRepository.GetByID(video.VideoFileId);
            if (videofile == null || !preview.MimeType.Contains(videoMime))
                throw new Exception();



            
            return video;
        }
        

        public virtual UserAndVideoLike ToLike(Video video, User user)
        {
            var videoExst = _videoRepository.GetByID(video.Id); // check an exists
            var userExsts = _userRepository.GetByID(user.Id);

            if (videoExst == null || userExsts == null) // throw exception cause it shouldn't be
                throw new Exception();

            var userLike = _userLikesReporsitory.Get(new UserAndVideoExistsSpecification<UserAndVideoLike>(user.Id, video.Id)).FirstOrDefault(); // find like by video and user

            if (userLike != null) //if u liked some video you cant like it again
                return null;

            UserAndVideoLike userAndVideoLikes = new UserAndVideoLike(_guidGenerator.GenerateGuid(), video.Id, user.Id); // create like

            video.IncreaseLikes(); // increase likes
            
            return userAndVideoLikes; // return entity to Insert it
        }
        public virtual UserAndVideoLike ToUnlike(Video video, User user)
        {
            var videoExst = _videoRepository.GetByID(video.Id); // checks
            var userExsts = _userRepository.GetByID(user.Id);


            if (videoExst == null || userExsts == null)
                throw new Exception();

            var userLike = _userLikesReporsitory.Get(new UserAndVideoExistsSpecification<UserAndVideoLike>(user.Id, video.Id)).FirstOrDefault(); // find likes



            if (userLike == null)//it logic error if it get null that must be fixed
                return null;


            userLike.DeleteRelation(); // delete relation

            video.DecreaseLikes();
            return userLike;
        }


        public virtual UserAndVideoDislike ToDislike(Video video, User user)
        {
            // i won't repeat, it's all like above
            var videoExst = _videoRepository.GetByID(video.Id);
            var userExsts = _userRepository.GetByID(user.Id);

            if (videoExst == null || userExsts == null)
                throw new Exception();


            var userDislike = _userDislikesReporsitory.Get(new UserAndVideoExistsSpecification<UserAndVideoDislike>(user.Id, video.Id)).FirstOrDefault();


            if (userDislike != null)
                return null;
            

            UserAndVideoDislike userAndVideoDislike = new UserAndVideoDislike(_guidGenerator.GenerateGuid(), video.Id, user.Id);


            video.IncreaseDislikes();

            return userAndVideoDislike;
        }
        public virtual UserAndVideoDislike ToUnDislike(Video video, User user) // don't shame for method name :)
        {
            var videoExst = _videoRepository.GetByID(video.Id);
            var userExsts = _userRepository.GetByID(user.Id);


            if (videoExst == null || userExsts == null)
                throw new Exception();

            var userDislike = _userDislikesReporsitory.Get(new UserAndVideoExistsSpecification<UserAndVideoDislike>(user.Id, video.Id)).FirstOrDefault();

            if (userDislike == null)
                return null;

            userDislike.DeleteRelation();
            video.DecreaseDislikes();

            return userDislike;
        }


        public virtual UserAndVideoShared ToShared(Video video, User user)
        {
            var videoExst = _videoRepository.GetByID(video.Id);
            var userExsts = _userRepository.GetByID(user.Id);

            if (videoExst == null || userExsts == null)
                throw new Exception();

            var userShared = _userSharedRepository.Get(new UserAndVideoExistsSpecification<UserAndVideoShared>(user.Id, video.Id)).FirstOrDefault();



            if (userShared != null)
                return null;
            


            UserAndVideoShared userAndVideoShared = new UserAndVideoShared(_guidGenerator.GenerateGuid(), video.Id, user.Id);

            video.IncreaseShared();

            return userAndVideoShared;
        }


        
    }
}

