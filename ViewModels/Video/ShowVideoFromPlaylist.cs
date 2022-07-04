using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoWebApp.ViewModels.Video
{
    public class ShowVideoFromPlaylist
    {
        public DisplayedChannelViewModel Channel { get; set; }

        public DisplayedVideoViewModel Video { get; set; }

        public DisplayedPlaylistViewModel Playlist { get; set; }
    }
    public class DisplayedPlaylistViewModel
    {
        public string Name { get; set; }
        
        public string ChannelOwner { get; set; }

        public int CountVideos { get; set; }
    }
}
