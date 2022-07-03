using System;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndCommentDislike : UserAndComment
    {
        protected UserAndCommentDislike() { }

        public UserAndCommentDislike(Guid id, Guid userId, Guid commentId) : base(id, userId, commentId)
        {

        }
    }
}
