using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates.Relations
{
    public abstract class VideoAndPlaylist : AggregateRootGuid
    {

        protected VideoAndPlaylist() { }

        protected VideoAndPlaylist(Guid id, Guid playlistId, Guid videoId) : base(id)
        {
            PlaylistId = playlistId;
            VideoId = videoId;
        }

        public Guid PlaylistId { get; set; }

        public Guid VideoId { get; set; }
    
    }
}
