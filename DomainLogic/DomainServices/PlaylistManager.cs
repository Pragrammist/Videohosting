using DomainLogic.Aggregates;
using DomainLogic.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using DomainLogic.Interfaces;
using DomainLogic.Specifications.Relations;
using DomainLogic.Aggregates.Relations;
using System.Threading.Tasks;

namespace DomainLogic.DomainServices
{
    public class PlaylistManager
    {
        IRepository<Playlist, Guid> _playlistRepository;
        IRepository<Channel, Guid> _channelRepository;
        IRepository<User, Guid> _userRepository;
        IRepository<Video, Guid> _videoRepository;
        IGuidGenerator _guidGenerator;
        IRepository<VideoAndPlaylistSaved, Guid> _videoAndPlaylistSavedRepository;
        IRepository<UserAndPlaylistSaved, Guid> _userAndPlaylistSavedRepository;
        IRepository<ChannelAndPlaylistSaved, Guid> _channelAndPlaylistSavedRepository;
        IRepository<UserAndPlaylistShared, Guid> _userAndPlaylistSharedRepository;

        public PlaylistManager(IRepository<Playlist, Guid> playlistRepository,
        IRepository<Channel, Guid> channelRepository, IRepository<User, Guid> userRepository, IRepository<Video, Guid> videoRepository, 
        IGuidGenerator guidGenerator, IRepository<VideoAndPlaylistSaved, Guid> videoAndPlaylistSavedRepository,
        IRepository<UserAndPlaylistSaved, Guid> userAndPlaylistSavedRepository, IRepository<ChannelAndPlaylistSaved, Guid> channelAndPlaylistSavedRepository,
        IRepository<UserAndPlaylistShared, Guid> userAndPlaylistSharedRepository)
        {
            _playlistRepository = playlistRepository;
            _channelRepository = channelRepository;
            _userRepository = userRepository;
            _videoRepository = videoRepository;
            _guidGenerator = guidGenerator;
            _videoAndPlaylistSavedRepository = videoAndPlaylistSavedRepository;
            _userAndPlaylistSavedRepository = userAndPlaylistSavedRepository;
            _channelAndPlaylistSavedRepository = channelAndPlaylistSavedRepository;
            _userAndPlaylistSharedRepository = userAndPlaylistSharedRepository;
        }

        public async Task<Playlist> CreateInstance(Playlist playlist)
        {
            var plId = playlist.Id;

            

            var user = await _userRepository.GetByID(plId);

            if (user == null)
                throw new Exception();

            if (playlist.ChannelIdCreated.HasValue)
            {
                var channel = await _channelRepository.GetByID(playlist.ChannelIdCreated.Value);

                if (channel == null)
                    throw new Exception();
            }


            

            return playlist;
        }
        public async Task<IEnumerable<VideoAndPlaylistSaved>> AddVideos(Playlist playlist, params Video[] videos)
        {
            var plIsExist = (await _playlistRepository.GetByID(playlist.Id)) != null;

            if (!plIsExist)
                throw new Exception();

            var length = videos.Length;
            VideoAndPlaylistSaved[] res = new VideoAndPlaylistSaved[videos.Length];


            for (int i = 0; i < length; i++)
            {
                var video = videos[i]; // get video

                var isExist = (await _videoRepository.GetByID(video.Id)) != null; // if video exists

                if (!isExist)
                    throw new Exception();

                var isNotExist = (await _videoAndPlaylistSavedRepository.Get(new VideoAndPlaylistExistsSpecificationn<VideoAndPlaylistSaved>(playlist.Id, video.Id))) == null;  //if not in playlist

                if(!isNotExist)
                    throw new Exception();

                
                //if checks done than it adds to result

                var saved = new VideoAndPlaylistSaved(_guidGenerator.GenerateGuid(), playlist.Id, video.Id);
                res[i] = saved;
            }
            return res;
        }

        public async Task<UserAndPlaylistSaved> Save(User user, Playlist playlist)
        {
            var isUserExist = (await _userRepository.GetByID(user.Id)) != null;
            if (!isUserExist)
                throw new Exception();

            var isPlaylistExist = (await _playlistRepository.GetByID(playlist.Id)) != null;
            if (!isPlaylistExist)
                throw new Exception();

            var isPlaylistNotAlreadyAdded = (await _userAndPlaylistSavedRepository.Get(new UserAndPlaylistExistSpecification<UserAndPlaylistSaved>(user.Id, playlist.Id))) == null;

            if (!isPlaylistNotAlreadyAdded)
                throw new Exception();

            UserAndPlaylistSaved saved = new UserAndPlaylistSaved(_guidGenerator.GenerateGuid(), playlist.Id, user.Id);
            return saved;
        }

        public async Task<UserAndPlaylistShared> Share(User user, Playlist playlist)
        {
            var isUserExist = (await _userRepository.GetByID(user.Id)) != null;
            if (!isUserExist)
                throw new Exception();

            var isPlaylistExist = (await _playlistRepository.GetByID(playlist.Id)) != null;
            if (!isPlaylistExist)
                throw new Exception();

            var isPlaylistShared = (await _userAndPlaylistSharedRepository.Get(new UserAndPlaylistExistSpecification<UserAndPlaylistShared>(user.Id, playlist.Id))) == null;

            if (!isPlaylistShared)
                throw new Exception();

            UserAndPlaylistShared shared = new UserAndPlaylistShared(_guidGenerator.GenerateGuid(), playlist.Id, user.Id);
            return shared;
        }

        public async Task<ChannelAndPlaylistSaved> Save(Channel channel, Playlist playlist)
        {
            var isChannelExist = (await _channelRepository.GetByID(channel.Id)) != null;
            if (!isChannelExist)
                throw new Exception();

            var isPlaylistExist = (await _playlistRepository.GetByID(playlist.Id)) != null;
            if (!isPlaylistExist)
                throw new Exception();

            var isPlaylistNotAlreadyAdded = (await _channelAndPlaylistSavedRepository.Get(new ChannelAndPlaylistExistSpecification<ChannelAndPlaylistSaved>(playlist.Id, channel.Id))) == null;

            if (!isPlaylistNotAlreadyAdded)
                throw new Exception();

            ChannelAndPlaylistSaved saved = new ChannelAndPlaylistSaved(_guidGenerator.GenerateGuid(), playlist.Id, channel.Id);
            return saved;
        }
    }
}

