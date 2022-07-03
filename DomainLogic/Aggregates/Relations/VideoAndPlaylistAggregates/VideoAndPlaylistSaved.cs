using System;

namespace DomainLogic.Aggregates.Relations
{
    public class VideoAndPlaylistSaved : VideoAndPlaylist
    {
        protected VideoAndPlaylistSaved() { }

        public VideoAndPlaylistSaved(Guid id, Guid playlistId, Guid videoId): base(id, playlistId, videoId) { }
    }
}
