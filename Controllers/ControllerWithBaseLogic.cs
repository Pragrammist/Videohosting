using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VideoWebApp.ViewModels.Shared;

namespace VideoWebApp.Controllers
{
    public abstract class ControllerWithBaseLogic : Controller
    {
        protected const string imagesPath = @"\images\";
        protected const string userIconPath = @"\images\shared\user\";
        protected const string sharedImagesPath = @"\images\shared\";
        protected const string imgChannelPath = @"\images\shared\channels\";
        protected ControllerWithBaseLogic() 
        {
            Constructor();
        }
        private void Constructor()
        {
            ViewBag.SharedModel = GetSharedViewModel();
        }
        protected SharedViewModel GetSharedViewModel () //imitation, that i got view model from db
        {
            SharedViewModel model = new SharedViewModel();

            model.User = new UserSharedViewModel { IconPath = userIconPath + @"userIcon.png", Id = GetId(), Name = "Milk"};
            model.Subcribes = new List<ChannelSharedViewModel>()
            {
                new ChannelSharedViewModel {IconPath = imgChannelPath + "channel_Hello.png", Id = GetId(), Name = "Hello", },
                new ChannelSharedViewModel {IconPath = imgChannelPath + "channel_Max.png", Id = GetId(), Name =  "Max", },
                new ChannelSharedViewModel {IconPath = imgChannelPath + "channel_Per.png", Id = GetId(), Name = "Per", },
                new ChannelSharedViewModel {IconPath = imgChannelPath + "channel_Sup.png",  Id= GetId(), Name= "Sup", }
            };
            model.UsersPlaylists = new List<PlaylistSharedViewModel>()
            {
                new PlaylistSharedViewModel{Id = GetId(), Name = "музыка"},
                new PlaylistSharedViewModel{Id = GetId(), Name = "муызка2"},
                new PlaylistSharedViewModel{Id = GetId(), Name = "любимое"},
                new PlaylistSharedViewModel{Id = GetId(), Name = "полезное"},
            };

            return model;
        }
        protected Guid GetId() => Guid.NewGuid();

        protected Guid GetCurrentUserId() => GetId();
    }

    
}
