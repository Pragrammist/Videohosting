using System;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndVideoShared : UserAndVideo
    {

        protected UserAndVideoShared() { }

        public UserAndVideoShared(Guid id, Guid videoId, Guid userId) : base(id, videoId, userId)
        {

        }
    }

}
