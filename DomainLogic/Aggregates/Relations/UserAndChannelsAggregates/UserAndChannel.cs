using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates.Relations
{
    public abstract class UserAndChannel : AggregateRootGuid
    {
        protected UserAndChannel() { }
        protected UserAndChannel(Guid id, Guid userId, Guid channelId) : base(id)
        {
            UserId = userId;
            ChannelId = channelId;
        }
        public Guid UserId { get; set; }
        public Guid ChannelId { get; set; }
        public void DeleteRelation()
        {
            UserId = Guid.Empty;
            ChannelId = Guid.Empty;
        }
    }

    
}
