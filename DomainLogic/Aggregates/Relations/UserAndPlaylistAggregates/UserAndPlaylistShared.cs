using System;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndPlaylistShared : UserAndPlaylist
    {
        protected UserAndPlaylistShared() { }
        public UserAndPlaylistShared(Guid id, Guid playlistId, Guid userId) : base(id, playlistId, userId)
        {

        }
    }
}
