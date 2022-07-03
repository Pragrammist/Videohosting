using DomainLogic.Aggregates.Relations;
using System;
using System.Linq.Expressions;

namespace DomainLogic.Specifications.Relations
{
    public class UserAndChannelExistSpecification<TUserAndChannel> : ISpecification<TUserAndChannel, Guid> where TUserAndChannel : UserAndChannel
    {
        Guid _user;

        Guid _channelId;
        public UserAndChannelExistSpecification(Guid channelId, Guid userId)
        {
            _user = userId;
            _channelId = channelId;
        }
        public Expression<Func<TUserAndChannel, bool>> ToExpression()
        {
            return i => i.ChannelId == _channelId && i.UserId == _user;
        }
    }
}
