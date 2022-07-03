using ApplicationServices.Dtos.Inputs;
using ApplicationServices.Dtos.Outputs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public interface IVideoAppService
    {
        public Task<VideoOutputDto> Create(CreateVideoDto createVideoData);
        public Task<VideoOutputDto> Delete(DeleteVideoDto deleteVideoDto);
        public Task<VideoOutputDto> Get(GetVideoDto getVideoCriteries);
        public Task<VideoOutputDto> SetDescription(Guid videoId, string description);
        public Task<VideoOutputDto> SetName(Guid videoId, string name);
        public Task<IEnumerable<VideoOutputDto>> GetRecommendedVideos(Guid userId, Guid? currentVideo = null);
        public Task<IEnumerable<VideoOutputDto>> GetPlaylistVideos(Guid playlistId);
        public Task<IEnumerable<VideoOutputDto>> GetChannelVideos(Guid channelId);
        public Task<IEnumerable<VideoOutputDto>> Like(Guid userId, Guid videoId);
        public Task<IEnumerable<VideoOutputDto>> Dislike(Guid userId, Guid videoId);
        public Task<IEnumerable<VideoOutputDto>> Share(Guid userId, Guid videoId);
    }
}
