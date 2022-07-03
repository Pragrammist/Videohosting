using ApplicationServices.Dtos.Inputs;
using ApplicationServices.Dtos.Outputs;
using System;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public interface IPlaylistAppService
    {
        public Task<PlaylistOutputDto> Create(CreatePlaylistDto createPlaylistData);
        public Task<PlaylistOutputDto> Get(GetPlaylistDto getPlaylistCriteries);
        public Task<PlaylistOutputDto> Share(Guid playlistId, Guid userId);
        public Task<PlaylistOutputDto> SetName(Guid playlistId, string name);
        public Task<PlaylistOutputDto> AddToChannel(Guid playlistId, Guid channelId);
        public Task<PlaylistOutputDto> AddToUser(Guid playlistId, Guid userId);
        public Task<PlaylistOutputDto> AddVideos(params AddVideosToPlaylistDto[] data);
        public Task<PlaylistOutputDto> DeletePlaylist(DeletePlaylistDto deletePlaylistData);
        public Task<PlaylistOutputDto> DeleteVideoFromPlaylist(Guid playlistId, Guid videoId);
    }
}
