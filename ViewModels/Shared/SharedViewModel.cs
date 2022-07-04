using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoWebApp.ViewModels.Shared
{
    public class SharedViewModel
    {
        public UserSharedViewModel User { get; set; }
        public IEnumerable<ChannelSharedViewModel> Subcribes { get; set; }
        public IEnumerable<PlaylistSharedViewModel> UsersPlaylists { get; set; }
    }
}
