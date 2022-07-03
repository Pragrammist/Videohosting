using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates.Relations
{
    public abstract class UserAndPlaylist : AggregateRootGuid // not have constructor for orm, because it just for aggregates struct
    {
        protected UserAndPlaylist() { }
        protected UserAndPlaylist(Guid id, Guid userId, Guid playlistId) : base(id)
        {
            UserId = userId;
            PlaylistId = playlistId;
        }
        public Guid UserId { get; set; }
        public Guid PlaylistId { get; set; }
    }
}
