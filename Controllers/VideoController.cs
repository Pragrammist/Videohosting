using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoWebApp.ViewModels;
using VideoWebApp.ViewModels.Video;
using ApplicationServices;
using ApplicationServices.Dtos.Inputs;
namespace VideoWebApp.Controllers
{
    public class VideoController : ControllerWithBaseLogic
    {
        IVideoAppService _videoServive;
        IPlaylistAppService _playlistService;
        IChannelAppService _channelService;
        IFileAppService _fileSrvice;

        public VideoController()
        {
            
        }
        
        public async Task <IActionResult> ShowVideo(Guid videoId)
        {
            var model = await GetVideoModel(videoId);
            
            
            return View(model);
        }

        public async Task<IActionResult> ShowVideoFromPlaylist(Guid videoId, Guid playlistId)
        {
            var model = await GetVideoModel(videoId, playlistId);
            

            return View(model);
        }

        public async Task<IActionResult> GetPlaylistVideos(Guid playlistId)
        {
            var videos = await _videoServive.GetPlaylistVideos(playlistId);

            return Json(videos);
        }

        public async Task<IActionResult> GetChannelVideos(Guid channelId)
        {
            var videos = await _videoServive.GetChannelVideos(channelId);

            return Json(videos);
        }
        
        public async Task<IActionResult> GetRecommendedVideos(Guid? videoId = null)
        {

            var currentUser = GetCurrentUserId();

            var videos = await _videoServive.GetRecommendedVideos(currentUser, videoId);

            return Json(videos);
        }

        public async Task<IActionResult> Like(Guid videoId, Guid userId)
        {
            var res = await _videoServive.Like(userId, videoId);

            return Json(res);
        }

        public async Task<IActionResult> Dislike(Guid videoId, Guid userId)
        {
            var res = await _videoServive.Dislike(userId, videoId);

            return Json(res);
        }

        public async Task<IActionResult> Share(Guid videoId, Guid userId)
        {
            var res = await _videoServive.Share(userId, videoId);
            return Json(res);
        }

        public async Task<IActionResult> SaveToPlaylist(Guid videoId, Guid playlistId)
        {
            var res = await _playlistService.AddVideos(new AddVideosToPlaylistDto {PlaylistId = playlistId, VideoId = videoId });
            return Json(res);
        }

        public async Task<IActionResult> SetName(Guid videoId, string name)
        {
            var res = await _videoServive.SetName(videoId, name);

            return Json(res);
        }

        public async Task<IActionResult> SetDescription(Guid videoId, string description)
        {
            var res = await _videoServive.SetDescription(videoId, description);

            return Json(res);
        }

        public async Task<IActionResult> UploadVideo([FromBody]CreateVideoDto video)
        {
            var res = await _videoServive.Create(video);

            return View(res);
        }

        public async Task<IActionResult> DeleteVideo(Guid videoId)
        {
            var res = await _videoServive.Delete(new DeleteVideoDto {Id = videoId });


            return Json(res);
        }

        private async Task<ShowVideoViewModel> GetVideoModel(Guid videoId)
        {
            ShowVideoViewModel model = new ShowVideoViewModel();

            {
                GetVideoDto inptData = new GetVideoDto { Id = videoId };
                var video = await _videoServive.Get(inptData);
                var channel = await _channelService.Get(new GetChannelDto { Id = video.ChannelId.Value });
                var channelIconPath = (await _fileSrvice.GetFile(new GetFileDto { Id = channel.FaceId.Value })).FilePath;

                model.Channel = new DisplayedChannelViewModel { HaveTicket = channel.HaveTicket, IconPath = channelIconPath, Id = channel.Id, Name = channel.Name, Subescribers = channel.CountOfSubscribers }; //todo automaping
                model.Video = new DisplayedVideoViewModel { DateUpload = video.DateUpload, Description = video.Description, Dislikes = video.Dislikes }; //todo automaping
            }

            model.Channel = new DisplayedChannelViewModel { HaveTicket = true, Id = Guid.Empty, Name = "SomeName", Subescribers = 100, IconPath = @"\pathtoicon" };
            model.Video = new DisplayedVideoViewModel { DateUpload = DateTime.Now, Name = "swa", Description = "very long description", Dislikes = 10, Id = videoId, Likes = 10, Tags = "#wqwe #ewq", Views = 10 };
            

            return model;
        }

        private async Task<ShowVideoFromPlaylist> GetVideoModel(Guid videoId, Guid playlistId)
        {
            //var video = await _videoServive.Get(new GetVideoDto { Id = videoId });
            var playlist = await _playlistService.Get(new GetPlaylistDto { Id = playlistId });
            var model = new ShowVideoFromPlaylist();
            var videoModel = await GetVideoModel(videoId);
            var channelOwner = await _channelService.Get(new GetChannelDto {Id = playlistId });
            


            model.Channel = videoModel.Channel;
            model.Video = videoModel.Video;
            model.Playlist = new DisplayedPlaylistViewModel { ChannelOwner = channelOwner.Name, Name = playlist.PlaylistName, CountVideos = playlist.CountVideos };
            return model;
        }
    }
}
