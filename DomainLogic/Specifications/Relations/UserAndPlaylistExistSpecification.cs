using DomainLogic.Aggregates.Relations;
using System;
using System.Linq.Expressions;

namespace DomainLogic.Specifications.Relations
{
    public class UserAndPlaylistExistSpecification<TUserAndVideo> : ISpecification<TUserAndVideo, Guid> where TUserAndVideo : UserAndPlaylist
    {
        Guid _userId;
        Guid _playlistId;
        public UserAndPlaylistExistSpecification(Guid userId, Guid playlistId)
        {
            _userId = userId;
            _playlistId = playlistId;
        }

        public Expression<Func<TUserAndVideo, bool>> ToExpression()
        {
            return i => i.UserId == _userId && i.PlaylistId == _playlistId;
        }

    }
}
