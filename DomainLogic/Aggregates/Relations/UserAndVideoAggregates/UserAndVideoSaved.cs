using System;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndVideoSaved : UserAndVideo
    {

        protected UserAndVideoSaved() { }

        public UserAndVideoSaved(Guid id, Guid videoId, Guid userId, Guid playlistId) : base(id, videoId, userId)
        {
            PlaylistId = playlistId;
            
        }
        public Guid PlaylistId { get; set; }
    }
    
}
