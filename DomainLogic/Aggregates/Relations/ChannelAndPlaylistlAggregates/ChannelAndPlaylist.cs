using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates.Relations
{
    public abstract class ChannelAndPlaylist : AggregateRootGuid
    {
        protected ChannelAndPlaylist() { }
        protected ChannelAndPlaylist(Guid id, Guid playlistId, Guid channelId) : base(id)
        {
            PlaylistId = playlistId;
            ChannelId = channelId;
        }
        public Guid PlaylistId { get; set; }
        public Guid ChannelId { get; set; }
    }
}

