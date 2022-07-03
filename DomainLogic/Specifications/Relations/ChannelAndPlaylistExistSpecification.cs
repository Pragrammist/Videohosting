using DomainLogic.Aggregates.Relations;
using System;
using System.Linq.Expressions;

namespace DomainLogic.Specifications.Relations
{
    public class ChannelAndPlaylistExistSpecification<TVideoAndPlaylist> : ISpecification<TVideoAndPlaylist, Guid> where TVideoAndPlaylist : ChannelAndPlaylist
    {
        Guid _playlistId;

        Guid _channelId;
        public ChannelAndPlaylistExistSpecification(Guid playlistId, Guid channelId)
        {
            _playlistId = playlistId;
            _channelId = channelId;
        }
        public Expression<Func<TVideoAndPlaylist, bool>> ToExpression()
        {
            return i => i.ChannelId == _channelId && i.PlaylistId == _playlistId;
        }
    }
}
