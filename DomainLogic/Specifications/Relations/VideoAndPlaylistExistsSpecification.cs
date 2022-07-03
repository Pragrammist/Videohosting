using DomainLogic.Aggregates.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Specifications.Relations
{
    public class VideoAndPlaylistExistsSpecificationn<TVideoAndPlaylist> : ISpecification<TVideoAndPlaylist, Guid> where TVideoAndPlaylist : VideoAndPlaylist
    {
        Guid _playlistId { get; set; }

        Guid _videoId { get; set; }
        public VideoAndPlaylistExistsSpecificationn(Guid playlistId, Guid videoId)
        {
            _playlistId = playlistId;
            _videoId = videoId;
        }
        public Expression<Func<TVideoAndPlaylist, bool>> ToExpression()
        {
            return i => i.VideoId == _videoId && i.PlaylistId == _playlistId;
        }
    }
}
