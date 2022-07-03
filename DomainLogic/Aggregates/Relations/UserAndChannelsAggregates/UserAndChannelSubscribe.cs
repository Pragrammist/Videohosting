using System;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndChannelSubscribe : UserAndChannel
    {
        protected UserAndChannelSubscribe() { }

        public UserAndChannelSubscribe(Guid id, Guid userId, Guid channelId): base(id, userId, channelId) { }
    }

    
}
