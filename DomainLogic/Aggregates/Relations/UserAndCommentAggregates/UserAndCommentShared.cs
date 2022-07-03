using System;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndCommentShared : UserAndComment
    {
        protected UserAndCommentShared() { }

        public UserAndCommentShared(Guid id, Guid userId, Guid commentId) : base(id, userId, commentId)
        {

        }
    }
}
