using System;

namespace DomainLogic.Aggregates.Relations
{
    public class ChannelAndPlaylistSaved : ChannelAndPlaylist
    {
        protected ChannelAndPlaylistSaved() { }
        public ChannelAndPlaylistSaved(Guid id, Guid playlistId, Guid channelId) : base(id, playlistId, channelId) { }
    }
}

