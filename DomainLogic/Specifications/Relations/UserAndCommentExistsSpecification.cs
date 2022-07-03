using DomainLogic.Aggregates.Relations;
using System;
using System.Linq.Expressions;

namespace DomainLogic.Specifications.Relations
{
    public class UserAndCommentExistsSpecification<TUserAndComment> : ISpecification<TUserAndComment, Guid> where TUserAndComment : UserAndComment
    {

        Guid _userId;

        Guid _commentId;
        public UserAndCommentExistsSpecification(Guid userId, Guid commentId)
        {
            _userId = userId;
            _commentId = commentId;
        }
        public Expression<Func<TUserAndComment, bool>> ToExpression()
        {
            return i => i.CommentId == _commentId && i.UserId == _userId;
        }
    }
}
