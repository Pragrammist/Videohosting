using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices;
using ApplicationServices.Dtos.Inputs;
using ApplicationServices.Dtos.Outputs;
using DomainLogic.Interfaces.Repositories;
using DomainLogic.DomainServices;
using DomainLogic.Aggregates;
using AutoMapper;
using DomainLogic.Interfaces;
using DomainLogic.Aggregates.Relations;
//using System.IO;
using DomainLogic.Specifications.Relations;
using DomainLogic.Specifications;
namespace ApplicationServicesImplemention
{
    public class ChannelAppService : IChannelAppService
    {
        //UserAndChannelSubscribe
        readonly IMapper _mapper;
        readonly IRepository<Channel, Guid> _channelRepository;
        readonly IRepository<User, Guid> _userRepository;
        readonly ChannelManager _channelManager;
        readonly IGuidGenerator _guidGenerator;
        readonly IRepository<UserAndChannelSubscribe, Guid> _subscribeRepository;
        
        public async Task<ChannelOutputDto> ChangeHeader(Guid channelId, Guid headerId)
        {
            throw new NotImplementedException();
        }

        public async Task<ChannelOutputDto> ChangeIcon(Guid channelId, Guid iconId)
        {
            throw new NotImplementedException();
        }

        public async Task<ChannelOutputDto> ChangeName(Guid channelId, string name)
        {
            var channel = await _channelRepository.GetByID(channelId);
            channel.SetChannelName(name);
            await _channelRepository.Update(channel);
            var resChannel = MapChannel(channel);
            return resChannel;
        }

        public async Task<ChannelOutputDto> CreateChannel(CreateChannelDto channelCreationData)
        {
            var id = _guidGenerator.GenerateGuid();
            var channel = new Channel(id, channelCreationData.Name, channelCreationData.Description, channelCreationData.HeadId, channelCreationData.FaceId, channelCreationData.CreaterId);
            
            channel = await _channelManager.CreateInstance(channel);
            await _channelRepository.Insert(channel);
            var res = MapChannel(channel);
            return res;
        }

        public async Task<ChannelOutputDto> DeleteChannel(Guid id)
        {
            var channel = await _channelRepository.GetByID(id);
            

            var res = MapChannel(channel);
            await _channelRepository.Delete(channel);
            return res;
        }

        //public async Task<ChannelOutputDto> DeleteTick(Guid id)
        //{
        //    var channel = await _channelRepository.GetByID(id);

        //    channel.sET

        //    var res = MapChannel(channel);
        //    throw new NotImplementedException();
        //}

        public async Task<ChannelOutputDto> Get(GetChannelDto channelGetCriteries)
        {
            var channel = await GetCommentById(channelGetCriteries);
            var res = MapChannel(channel);
            return res;
        }

        private async Task<Channel> GetCommentById(GetChannelDto channelGetCriteries)
         => await _channelRepository.GetByID(channelGetCriteries.Id);
            
        //private async Task<Channel> GetCommentByUserId(GetChannelDto channelGetCriteries)
        //{

        //}
        public async Task<ChannelOutputDto> SetTick(Guid id)
        {
            var channel = await _channelRepository.GetByID(id);

            channel.SetTicket();

            var res = MapChannel(channel);
            await _channelRepository.Update(channel);

            return res;
        }

        public async Task<ChannelOutputDto> Subscribe(Guid userId, Guid channelId)
        {
            var channel = await _channelRepository.GetByID(userId);
            var user = await _userRepository.GetByID(userId);
            var sub = await _channelManager.Subscribe(user, channel);
            await _subscribeRepository.Insert(sub);
            await _userRepository.Update(user);
            await _channelRepository.Update(channel);

            var res = MapChannel(channel);
            return res;
        }

        public async Task<ChannelOutputDto> UnSubscribe(Guid userId, Guid channelId)
        {
            var channel = await _channelRepository.GetByID(userId);
            var user = await _userRepository.GetByID(userId);
            var sub = await _channelManager.UnSubscribe(user, channel);
            await _subscribeRepository.Delete(sub);
            await _userRepository.Update(user);
            await _channelRepository.Update(channel);

            var res = MapChannel(channel);
            return res;
        }
        private ChannelOutputDto MapChannel(Channel channel) => _mapper.Map<Channel, ChannelOutputDto>(channel);
    }

    public class CommentAppService : ICommentAppService
    {
        readonly IMapper _mapper;
        readonly IRepository<Comment, Guid> _commentRep;
        readonly IRepository<User, Guid> _userRep;
        readonly CommentManager _commentManager;
        readonly IGuidGenerator _guidGenerator;
        readonly IRepository<CommentAndAnswer, Guid> _answerRep;
        readonly IRepository<UserAndCommentDislike, Guid> _dislikesRep;
        readonly IRepository<UserAndCommentLike, Guid> _lileRep;
        
        public async Task<CommentOutputDto> AnswerComment(AnswerCommentDto answerCommentData)
        {
            var comment = await _commentRep.GetByID(answerCommentData.CommentId);
            var answer = new Comment(_guidGenerator.GenerateGuid(), answerCommentData.VideoId, answerCommentData.AuthorId, answerCommentData.Text);
            answer = await _commentManager.CreateInstance(answer);
            var relation = await _commentManager.AnswerToComment(comment, answer);
            await _commentRep.Insert(answer);
            await _answerRep.Insert(relation);
            
            var res = MapComment(answer);
            return res;
        }

        public async Task<CommentOutputDto> CreateComment(CreateCommentDto createCommentData)
        {
            var comment = new Comment(_guidGenerator.GenerateGuid(), createCommentData.VideoId, createCommentData.AuthorId, createCommentData.Text);
            comment = await _commentManager.CreateInstance(comment);
            await _commentRep.Insert(comment);
            var res = MapComment(comment);
            return res;
        }

        public async Task<CommentOutputDto> DeleteComment(Guid id)
        {
            var comment = await _commentRep.GetByID(id);
            await _commentRep.Delete(comment);

            return MapComment(comment);
        }

        public async Task<CommentOutputDto> Dislike(Guid userId, Guid commentId)
        {
            var user = await _userRep.GetByID(userId);
            var comment = await _commentRep.GetByID(commentId);
            var dislike = await _commentManager.DislikeComment(comment, user);
            await _userRep.Update(user);
            await _commentRep.Update(comment);
            await _dislikesRep.Insert(dislike);

            return MapComment(comment);
        }

        public async Task<IEnumerable<CommentOutputDto>> GetAnswers(Guid commentId, int page = 0)
        {
            var answers = await _answerRep.Get(new CommentAndAnswerExistsSpecification<CommentAndAnswer>(commentId), page:page);
            CommentOutputDto[] comments = new CommentOutputDto[answers.Count()];

            int i = 0;
            foreach(var answer in answers)
            {
                var id = answer.AnswerId;
                var comment = await _commentRep.GetByID(id);
                comments[i] = MapComment(comment);
                i++;
            }
            return comments;
        }

        public Task<CommentOutputDto> Get(GetCommentDto commentGetCreteries)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentOutputDto>> GetVideoComments(Guid videoId, int page = 0)
        {
            var videos = (await _commentRep.Get(new BaseSpecification<Comment, Guid>(c => c.VideoId == videoId), page: page)).Select(c => MapComment(c));

            return videos;
        }

        public async Task<CommentOutputDto> Like(Guid userId, Guid commentId)
        {
            var user = await _userRep.GetByID(userId);
            var comment = await _commentRep.GetByID(commentId);
            var like = await _commentManager.LikeComment(comment, user);
            await _commentRep.Update(comment);
            await _userRep.Update(user);
            await _lileRep.Insert(like);
            return MapComment(comment);
        }

        public Task<CommentOutputDto> RemoveDislike(Guid userId, Guid commentId)
        {
            throw new NotImplementedException();
        }

        public Task<CommentOutputDto> RemoveLike(Guid userId, Guid commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentOutputDto> SetText(string text, Guid commentId)
        {
            var comment = await _commentRep.GetByID(commentId);
            comment.SetText(text);
            await _commentRep.Update(comment);
            return MapComment(comment);
        }

        public Task<CommentOutputDto> Share(Guid userId, Guid commentId)
        {
            throw new NotImplementedException();
        }
        private CommentOutputDto MapComment(Comment comment) => _mapper.Map<Comment, CommentOutputDto>(comment);
    }

    public class FileAppSrvice : IFileAppService
    {
        IMapper _mapper;
        FileManager _fileManager;
        IRepository<File, Guid> _fileRep;
        IGuidGenerator _guidGenerator;
        IAppFileSytem _fileSytem;
        public async Task<FileOutputDto> CreateFile(FileCreateDto fileCreateData)
        {
            var file = new File(_guidGenerator.GenerateGuid(), fileCreateData.FilePath);
            file = await _fileManager.CreateInstance(file);
            await _fileRep.Insert(file);

            return MapFile(file);
        }

        public async Task<FileOutputDto> DeleteFile(DeleteFile deleteFileCriteries)
        {
            var file = await _fileRep.GetByID(deleteFileCriteries.Id);
            await _fileRep.Delete(file);
            return MapFile(file);
        }

        public async Task<FileOutputDto> GetFile(GetFileDto getFileCriteries)
        {
            var file = await _fileRep.GetByID(getFileCriteries.Id);
            return MapFile(file);
        }

        public async Task<System.IO.Stream> GetFileStream(Guid fileId)
        {
            var file = await _fileRep.GetByID(fileId);
            var stream = _fileSytem.GetStream(file?.FilePath);

            return stream;
        }

        public Task<FileOutputDto> UpdateName(UpdateNameDto updateNameData)
        {
            throw new NotImplementedException();
        }
        
        private FileOutputDto MapFile(File file) => _mapper.Map<File, FileOutputDto>(file);
    }

    public class PlaylistAppService : IPlaylistAppService
    {
        IMapper _mapper;
        PlaylistManager _playlistManager;
        IRepository<Playlist, Guid> _playlistRep;
        IRepository<Channel, Guid> _channelRep;
        IRepository<ChannelAndPlaylistSaved, Guid> _savesRep;
        public async Task<PlaylistOutputDto> AddToChannel(Guid playlistId, Guid channelId)
        {
            var playlist = await _playlistRep.GetByID(playlistId);
            var channel = await _channelRep.GetByID(channelId);
            var save = await _playlistManager.Save(channel, playlist);
            await _savesRep.Insert(save);
            await _channelRep.Update(channel);
            await _playlistRep.Update(playlist);

            return MapPlaylists(playlist);
        }

        public Task<PlaylistOutputDto> AddToUser(Guid playlistId, Guid userId)
        {

            throw new NotImplementedException();
        }

        public async Task<PlaylistOutputDto> AddVideos(params AddVideosToPlaylistDto[] data)
        {
            

            throw new NotImplementedException();
        }

        public Task<PlaylistOutputDto> Create(CreatePlaylistDto createPlaylistData)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistOutputDto> DeletePlaylist(DeletePlaylistDto deletePlaylistData)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistOutputDto> DeleteVideoFromPlaylist(Guid playlistId, Guid videoId)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistOutputDto> Get(GetPlaylistDto getPlaylistCriteries)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistOutputDto> SetName(Guid playlistId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistOutputDto> Share(Guid playlistId, Guid userId)
        {
            throw new NotImplementedException();
        }

        private PlaylistOutputDto MapPlaylists(Playlist playlist) => _mapper.Map<Playlist, PlaylistOutputDto>(playlist);
    }

    public class UserAppService : IUserAppService
    {
        public Task<UserOutputDto> ChangeName(Guid userId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<UserOutputDto> Create(CreateUserDto createUserData)
        {
            throw new NotImplementedException();
        }

        public Task<UserOutputDto> Delete(DeleteUserDto deleteUserCriteries)
        {
            throw new NotImplementedException();
        }

        public Task<UserOutputDto> Get(GetUserDto getUserCriteries)
        {
            throw new NotImplementedException();
        }

        public Task<UserOutputDto> SetRole(Guid userId, string role)
        {
            throw new NotImplementedException();
        }
    }

    public class VideoAppService : IVideoAppService
    {
        public Task<VideoOutputDto> Create(CreateVideoDto createVideoData)
        {
            throw new NotImplementedException();
        }

        public Task<VideoOutputDto> Delete(DeleteVideoDto deleteVideoDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoOutputDto>> Dislike(Guid userId, Guid videoId)
        {
            throw new NotImplementedException();
        }

        public Task<VideoOutputDto> Get(GetVideoDto getVideoCriteries)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoOutputDto>> GetChannelVideos(Guid channelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoOutputDto>> GetPlaylistVideos(Guid playlistId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoOutputDto>> GetRecommendedVideos(Guid userId, Guid? currentVideo = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoOutputDto>> Like(Guid userId, Guid videoId)
        {
            throw new NotImplementedException();
        }

        public Task<VideoOutputDto> SetDescription(Guid videoId, string description)
        {
            throw new NotImplementedException();
        }

        public Task<VideoOutputDto> SetName(Guid videoId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoOutputDto>> Share(Guid userId, Guid videoId)
        {
            throw new NotImplementedException();
        }
    }
}
