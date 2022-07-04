using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices;
using ApplicationServices.Dtos.Inputs;
using ApplicationServices.Dtos.Outputs;
using VideoWebApp.ViewModels.Channel;

namespace VideoWebApp.Controllers
{
    public class ChannelController : ControllerWithBaseLogic
    {

        public ChannelController()
        {
            
        }

        IChannelAppService _channelAppService;
        public async Task<IActionResult> CreateChannel([FromBody] CreateChannelDto createChannelDto)
        {
            var res = await _channelAppService.CreateChannel(createChannelDto);

            return Json(res);
        }

        public async Task<IActionResult> Videos(Guid id)
        {
            await InitViewBag(id);
            return View();
        }

        public async Task<IActionResult> Playlists(Guid id)
        {
            await InitViewBag(id);
            return View();
        }
        ShowChannelViewModel GetViewModel(ChannelOutputDto channelData) => new ShowChannelViewModel { HaveTicket = true, IconPath = imgChannelPath + "channel_Hello.png", HeadPath = "#", Name = "Hello", Subscribesrs = 10 };
        protected async Task InitViewBag(Guid id)
        {
            var channelInputData = new GetChannelDto { Id = id };
            var channel = await _channelAppService.Get(channelInputData);
            var model = GetViewModel(channel);
            ViewBag.ChannelData = model;
        }
        public async Task<IActionResult> Subscribe(Guid userId, Guid channeld)
        {
            var res = await _channelAppService.Subscribe(userId, channeld);

            return Json(res);
        }
        public async Task<IActionResult> ChangeName(Guid channelId, string name) // todo changes
        {
            var res = await _channelAppService.ChangeName(channelId, name);

            return Json(res);
        }
    }
}
