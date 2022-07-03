using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates.Relations
{
    public abstract class UserAndVideo : AggregateRootGuid 
    {

        protected UserAndVideo() { }

        protected UserAndVideo(Guid id, Guid userId, Guid videoId): base(id) 
        {
            UserId = userId;
            VideoId = videoId;
        }

        public void DeleteRelation()
        {
            UserId = Guid.Empty;
            VideoId = Guid.Empty;
        }
        public Guid UserId { get; set; }

        public Guid VideoId { get; set; }

    }
}
