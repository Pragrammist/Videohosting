using System;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndCommentLike : UserAndComment
    {
        protected UserAndCommentLike() { }

        public UserAndCommentLike(Guid id, Guid userId, Guid commentId) : base(id, userId, commentId)
        {

        }
    }
}
