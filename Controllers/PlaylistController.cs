using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices;
using ApplicationServices.Dtos.Inputs;
using VideoWebApp.ViewModels.Playlist;

namespace VideoWebApp.Controllers
{
    public class PlaylistController : Controller
    {
        IPlaylistAppService _playlistService;
        IChannelAppService _channelService;
        IFileAppService _fileService;

        public async Task<IActionResult> GetUserPlaylists(Guid userId)
        {
            var res = await _playlistService.Get(new GetPlaylistDto {UserId = userId });

            return Json(res);
        }
        public async Task<IActionResult> GetChannelPlaylists(Guid channelId)
        {
            var res = await _playlistService.Get(new GetPlaylistDto { ChannelId = channelId });

            return Json(res);            
        }
        public async Task<IActionResult> AddVideo(Guid videoId, Guid playlistId)
        {
            var res =  await _playlistService.AddVideos(new AddVideosToPlaylistDto {PlaylistId = playlistId, VideoId = videoId });

            return Json(res);
        }
        public async Task<IActionResult> DeleteVideo(Guid videoId, Guid playlistId)
        {
            var res = await _playlistService.DeleteVideoFromPlaylist(playlistId, videoId);

            return Json(res);
        }
        public async Task<IActionResult> ShowPlaylist(Guid playlistId)
        {
            var model = await GetViewModel(playlistId);

            return View(model);
        }
        public async Task<IActionResult> SetName(Guid playlistId, string name)
        {
            var res = await _playlistService.SetName(playlistId, name);

            return Json(res);
        }
        public async Task<IActionResult> AddToChannel(Guid playlistId, Guid channelId)
        {
            var res = await _playlistService.AddToChannel(playlistId, channelId);

            return Json(res);
        }
        public async Task<IActionResult> Share(Guid playlistId, [FromHeader]Guid userId)
        {
            var res = await _playlistService.Share(playlistId, userId);
            return Json(res);
        }
        private async Task<ShowPlaylistViewModel> GetViewModel(Guid playlistId)
        {
            var playlist = await _playlistService.Get(new GetPlaylistDto { Id = playlistId });
            var channelOwner = await _channelService.Get(new GetChannelDto { Id = playlist.ChannelIdCreated.Value });
            var previewPath = (await _fileService.GetFile(new GetFileDto {Id = playlist.PlaylistPreviewId.Value })).FilePath;
            var iconPath = (await _fileService.GetFile(new GetFileDto {Id = channelOwner.FaceId.Value })).FilePath; 
            var model = new ShowPlaylistViewModel {ChannelName = channelOwner.Name, FirstVideoPreviewPath = previewPath, IconChannelPath = iconPath, PlaylistName = playlist.PlaylistName };



            return model;
        }
    }
}
