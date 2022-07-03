using System;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndVideoDislike : UserAndVideo
    {

        protected UserAndVideoDislike() { }

        public UserAndVideoDislike(Guid id, Guid videoId, Guid userId) : base(id, videoId, userId)
        {

        }
    }
    
}
