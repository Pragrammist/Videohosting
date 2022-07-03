using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndPlaylistSaved : UserAndPlaylist
    {
        protected UserAndPlaylistSaved() { }
        public UserAndPlaylistSaved(Guid id, Guid playlistId, Guid userId) : base(id, playlistId, userId)
        {

        }
    }
}
